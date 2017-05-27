using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// A JsonConverter for JSON.NET that will deserialize objects into <see cref="ChangeTrackingDictionary"/>.
    /// Nested objects are recursively deserialized as nested dictionaries.
    /// </summary>
    public sealed class ChangeTrackingDictionaryConverter : CustomCreationConverter<ChangeTrackingDictionary>
    {
        public override ChangeTrackingDictionary Create(Type objectType)
            => new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase);

        public override bool CanConvert(Type objectType)
            // We want to handle explicit objects (dictionaries) and
            // also nested objects (which might be dictionaries)
            => objectType == typeof(object) || base.CanConvert(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Deserialize nested objects as dictionaries
            var isObject = reader.TokenType == JsonToken.StartObject || reader.TokenType == JsonToken.Null;
            if (isObject) return base.ReadJson(reader, objectType, existingValue, serializer);

            // If not, fall back to standard deserialization (for numbers, etc)
            return serializer.Deserialize(reader);
        }
    }
}
