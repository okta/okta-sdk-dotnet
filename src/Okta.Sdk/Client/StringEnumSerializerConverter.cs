
using System;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Abstractions;
using JsonException = Newtonsoft.Json.JsonException;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace Okta.Sdk.Model
{
    /// <summary>
    /// This class provides special serialization for <see cref="StringEnum"/> types.
    /// </summary>
    public sealed class StringEnumSerializingConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
            => StringEnum.TypeInfo.IsAssignableFrom(objectType.GetTypeInfo());

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            var stringEnum = Activator.CreateInstance(objectType, reader.Value) as StringEnum;

            return stringEnum;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumValue = (value as StringEnum)?.Value ?? string.Empty;

            serializer.Serialize(writer, enumValue);
        }
    }
}
