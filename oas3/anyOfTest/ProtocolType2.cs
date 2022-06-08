/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template: AnyOf
    /// ProtocolType2
    /// </summary>
    [JsonConverter(typeof(ProtocolType2JsonConverter))]
    [DataContract(Name = "ProtocolType2")]
    public partial class ProtocolType2 : AbstractOpenAPISchema, IEquatable<ProtocolType2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolType2" /> class
        /// with the <see cref="Object" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of Object.</param>
        public ProtocolType2(Object actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProtocolType2" /> class
        /// with the <see cref="ProtocolType2AnyOf" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of ProtocolType2AnyOf.</param>
        public ProtocolType2(ProtocolType2AnyOf actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            //this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(Object))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(ProtocolType2AnyOf))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: Object, ProtocolType2AnyOf");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `Object`. If the actual instance is not `Object`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of Object</returns>
        public Object GetObject()
        {
            return (Object)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `ProtocolType2AnyOf`. If the actual instance is not `ProtocolType2AnyOf`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of ProtocolType2AnyOf</returns>
        public ProtocolType2AnyOf GetProtocolType2AnyOf()
        {
            return (ProtocolType2AnyOf)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProtocolType2 {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, ProtocolType2.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of ProtocolType2
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of ProtocolType2</returns>
        public static ProtocolType2 FromJson(string jsonString)
        {
            ProtocolType2 newProtocolType2 = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newProtocolType2;
            }

            try
            {
                newProtocolType2 = new ProtocolType2(JsonConvert.DeserializeObject<Object>(jsonString, ProtocolType2.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newProtocolType2;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into Object: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newProtocolType2 = new ProtocolType2(JsonConvert.DeserializeObject<ProtocolType2AnyOf>(jsonString, ProtocolType2.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newProtocolType2;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into ProtocolType2AnyOf: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ProtocolType2);
        }

        /// <summary>
        /// Returns true if ProtocolType2 instances are equal
        /// </summary>
        /// <param name="input">Instance of ProtocolType2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProtocolType2 input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
                return hashCode;
            }
        }

    }

    /// <summary>
    /// Custom JSON converter for ProtocolType2
    /// </summary>
    public class ProtocolType2JsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(ProtocolType2).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return ProtocolType2.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
