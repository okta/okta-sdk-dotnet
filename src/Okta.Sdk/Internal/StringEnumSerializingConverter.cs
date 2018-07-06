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
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumValue = (value as StringEnum)?.Value ?? string.Empty;

            serializer.Serialize(writer, enumValue);
        }
    }
}
