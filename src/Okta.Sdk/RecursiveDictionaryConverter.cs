using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// A JsonConverter for JSON.NET that will deserialize objects into immutable, key-case-insensitive dictionaries.
    /// Nested objects are recursively deserialized as nested dictionaries.
    /// </summary>
    public sealed class RecursiveDictionaryConverter : CustomCreationConverter<IDictionary<string, object>>
    {
        private readonly Func<IDictionary<string, object>> _dictionaryFactory;

        public RecursiveDictionaryConverter(Func<IDictionary<string, object>> dictionaryFactory)
        {
            _dictionaryFactory = dictionaryFactory;
        }

        public override IDictionary<string, object> Create(Type objectType)
            => _dictionaryFactory();

        public override bool CanConvert(Type objectType)
            // We want to handle explicit IReadOnlyDictionaries and
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
