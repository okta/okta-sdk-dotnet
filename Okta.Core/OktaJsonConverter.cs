using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using System.Reflection;
using Okta.Core.Models;

namespace Okta.Core
{
    /// <summary>
    /// The custom serialier and deserializer for <see cref="ApiObject"/>s
    /// </summary>
    public class OktaJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type type)
        {
            bool isApiObject = typeof(ApiObject).IsAssignableFrom(type);
            return isApiObject;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Instantiate the JSON converter
            var oktaConverter = new OktaJsonConverter();

            // If we're deserializing a single object
            if (reader.TokenType == JsonToken.StartObject)
            {
                // Get the JSON for that object
                JObject jsonObject = JObject.Load(reader);

                // Find the properties that can't be deserialized by starting with all possible properties
                var unDeserializable = jsonObject.Properties().ToDictionary(x => (x as JProperty).Name.ToString(), y => y);

                // Start building our own object
                var newObject = Activator.CreateInstance(objectType);

                // Loop through all the properties of our desired type
                foreach (PropertyInfo p in objectType.GetProperties())
                {
                    // If member is serializable
                    var jsonAttribute = System.Attribute.GetCustomAttribute(p, typeof(JsonPropertyAttribute));
                    if (jsonAttribute != null)
                    {
                        // Get the mapped attribute name for a field or property
                        var attributeName = (jsonAttribute as JsonPropertyAttribute).PropertyName.ToString();

                        // Get the value from our jsonObject
                        JProperty prop = jsonObject.Properties().FirstOrDefault(x => x.Name == attributeName);
                        if (prop == null)
                        {
                            continue;
                        }
                        JToken value = prop.Value;

                        // Convert the value to it's relevant type
                        object v;

                        // Handle the ApiObject case
                        if (typeof(ApiObject).IsAssignableFrom(p.PropertyType))
                        {
                            v = Utils.DeserializeObject(value.ToString(), p.PropertyType);
                        }

                        // Handle the Link dictionary case
                        else if (typeof(Dictionary<string, List<Link>>).IsAssignableFrom(p.PropertyType))
                        {
                            var linkDictionary = new Dictionary<string, List<Link>>();

                            // Loop through each of the named links
                            foreach (JToken jt in value.Children())
                            {
                                // Get the first value of the named link
                                var linkJTokenName = ((JProperty)jt).Name;
                                var linkJTokenValue = ((JProperty)jt).Value;

                                // Deserialize that value into something we can use
                                List<Link> linkList;
                                if (linkJTokenValue.Type == JTokenType.Array)
                                {
                                    linkList = Utils.Deserialize<List<Link>>(linkJTokenValue.ToString());
                                }
                                else
                                {
                                    var linkValue = Utils.Deserialize<Link>(linkJTokenValue.ToString());
                                    linkList = new List<Link> { linkValue };
                                }

                                // Add it to our dictionary
                                linkDictionary.Add(linkJTokenName, linkList);

                            }
                            v = linkDictionary;
                        }

                        // Handle lists and objects
                        else if (value.Type == JTokenType.Array || value.Type == JTokenType.Object)
                        {
                            v = Utils.DeserializeObject(value.ToString(), p.PropertyType);
                        }

                        // Handle everything else
                        else
                        {
                            if (p.PropertyType == typeof(DateTime) && value.Type == JTokenType.Null || value.Type == JTokenType.None)
                            {
                                unDeserializable.Remove(attributeName);
                                continue;
                            }
                            else
                            {
                                v = Convert.ChangeType(value, p.PropertyType, null);
                            }
                        }

                        // Set the property on the object we're building
                        p.SetValue(newObject, v, null);

                        unDeserializable.Remove(attributeName);
                    }
                }

                // Add all the properties that weren't serialized
                (newObject as ApiObject).UnmappedProperties = unDeserializable;

                return newObject;
            }

            // If we're deserializing an array
            else if (reader.TokenType == JsonToken.StartArray)
            {
                JToken jsonToken = JArray.ReadFrom(reader);
                List<JToken> jsonTokens = jsonToken.ToList();

                var resultObjects = new List<ApiObject>();

                foreach (JToken arrayToken in jsonTokens)
                {
                    ApiObject resultElement = Utils.DeserializeObject(
                        arrayToken.ToString(), objectType) as ApiObject;

                    resultObjects.Add(resultElement);
                }

                return resultObjects;
            }

            throw new NotImplementedException("Can't deserialize");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                return;
            }

            Type t = value.GetType();
            
            var walkedObject = WalkObject(value);

            if (walkedObject != null)
            {
                walkedObject.WriteTo(writer);
            }
            else
            {
                new JObject().WriteTo(writer);
            }
        }

        private JToken WalkObject(object value)
        {
            if (value == null)
            {
                return null;
            }

            // Start building our own token
            var builtToken = new JObject();
            var objectType = value.GetType();;

            foreach (PropertyInfo member in objectType.GetProperties())
            {
                // If member is serializable
                var jsonAttribute = System.Attribute.GetCustomAttribute(member, typeof(JsonPropertyAttribute));
                if (jsonAttribute != null)
                {
                    // Get the mapped attribute name for a field or property
                    var attributeName = (jsonAttribute as JsonPropertyAttribute).PropertyName.ToString();

                    // Add the member to our object
                    JToken resultToken = JToken.Parse("null");
                    var p = (PropertyInfo)member;
                    var v = p.GetValue(value, null);

                    if (v == null)
                    {
                        continue;
                    }

                    if (typeof(ApiObject).IsAssignableFrom(p.PropertyType))
                    {
                        resultToken = WalkObject(v);
                    }

                    // Handle DateTime case
                    else if (typeof(DateTime).IsAssignableFrom(p.PropertyType))
                    {
                        var dateTimeValue = (DateTime)v;
                        if (dateTimeValue != default(DateTime))
                        {
                            resultToken = JToken.FromObject(v);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    // Handle the Link dictionary case
                    else if (typeof(Dictionary<string, List<Link>>).IsAssignableFrom(p.PropertyType))
                    {
                        continue;
                    }

                    else
                    {
                        resultToken = JToken.FromObject(v);
                    }

                    if (resultToken != null && resultToken.Type != JTokenType.Null)
                    {
                        builtToken.Add(attributeName, resultToken);
                    }
                }
            }

            // Add fields that weren't serialized
            foreach (JProperty property in (value as ApiObject).UnmappedProperties.Values)
            {
                if (property.Value.Type != JTokenType.Null)
                {
                    builtToken.Add(property);
                }
            }

            if (builtToken.Properties().Count() > 0)
            {
                return builtToken;
            }
            else
            {
                return null;
            }
        }
    }
}
