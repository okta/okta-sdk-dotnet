/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.06.1
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
using System.Reflection;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Template" ModelOneOf
    /// AppUserUpdateRequest
    /// </summary>
    [JsonConverter(typeof(AppUserUpdateRequestJsonConverter))]
    [DataContract(Name = "AppUserUpdateRequest")]
    public partial class AppUserUpdateRequest : AbstractOpenAPISchema, IEquatable<AppUserUpdateRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppUserUpdateRequest" /> class
        /// with the <see cref="AppUserCredentialsRequestPayload" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of AppUserCredentialsRequestPayload.</param>
        public AppUserUpdateRequest(AppUserCredentialsRequestPayload actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppUserUpdateRequest" /> class
        /// with the <see cref="AppUserProfileRequestPayload" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of AppUserProfileRequestPayload.</param>
        public AppUserUpdateRequest(AppUserProfileRequestPayload actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
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
                if (value.GetType() == typeof(AppUserCredentialsRequestPayload))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(AppUserProfileRequestPayload))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: AppUserCredentialsRequestPayload, AppUserProfileRequestPayload");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `AppUserCredentialsRequestPayload`. If the actual instance is not `AppUserCredentialsRequestPayload`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of AppUserCredentialsRequestPayload</returns>
        public AppUserCredentialsRequestPayload GetAppUserCredentialsRequestPayload()
        {
            return (AppUserCredentialsRequestPayload)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `AppUserProfileRequestPayload`. If the actual instance is not `AppUserProfileRequestPayload`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of AppUserProfileRequestPayload</returns>
        public AppUserProfileRequestPayload GetAppUserProfileRequestPayload()
        {
            return (AppUserProfileRequestPayload)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AppUserUpdateRequest {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, AppUserUpdateRequest.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of AppUserUpdateRequest
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of AppUserUpdateRequest</returns>
        public static AppUserUpdateRequest FromJson(string jsonString)
        {
            AppUserUpdateRequest newAppUserUpdateRequest = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newAppUserUpdateRequest;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(AppUserCredentialsRequestPayload).GetProperty("AdditionalProperties") == null)
                {
                    newAppUserUpdateRequest = new AppUserUpdateRequest(JsonConvert.DeserializeObject<AppUserCredentialsRequestPayload>(jsonString, AppUserUpdateRequest.SerializerSettings));
                }
                else
                {
                    newAppUserUpdateRequest = new AppUserUpdateRequest(JsonConvert.DeserializeObject<AppUserCredentialsRequestPayload>(jsonString, AppUserUpdateRequest.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("AppUserCredentialsRequestPayload");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into AppUserCredentialsRequestPayload: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(AppUserProfileRequestPayload).GetProperty("AdditionalProperties") == null)
                {
                    newAppUserUpdateRequest = new AppUserUpdateRequest(JsonConvert.DeserializeObject<AppUserProfileRequestPayload>(jsonString, AppUserUpdateRequest.SerializerSettings));
                }
                else
                {
                    newAppUserUpdateRequest = new AppUserUpdateRequest(JsonConvert.DeserializeObject<AppUserProfileRequestPayload>(jsonString, AppUserUpdateRequest.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("AppUserProfileRequestPayload");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into AppUserProfileRequestPayload: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + matchedTypes);
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newAppUserUpdateRequest;
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AppUserUpdateRequest);
        }

        /// <summary>
        /// Returns true if AppUserUpdateRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of AppUserUpdateRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AppUserUpdateRequest input)
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
    /// Custom JSON converter for AppUserUpdateRequest
    /// </summary>
    public class AppUserUpdateRequestJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(AppUserUpdateRequest).GetMethod("ToJson").Invoke(value, null)));
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
                return AppUserUpdateRequest.FromJson(JObject.Load(reader).ToString(Formatting.None));
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
