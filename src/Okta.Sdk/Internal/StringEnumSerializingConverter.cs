// <copyright file="StringEnumSerializingConverter.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
