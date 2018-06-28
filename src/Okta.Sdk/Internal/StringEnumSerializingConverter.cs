using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Okta.Sdk.Internal
{
    public sealed class StringEnumSerializingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        => StringEnum.TypeInfo.IsAssignableFrom(objectType.GetTypeInfo());

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stringEnum = value as StringEnum;
            if (value == null)
            {
                new JObject().WriteTo(writer);
                return;
            }

            serializer.Serialize(writer, stringEnum.Value);
        }
    }
}
