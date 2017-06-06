// <copyright file="RecursiveDictionaryConverter.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Okta.Sdk
{
    /// <summary>
    /// A JSON.NET converter that will deserialize objects into dictionaries.
    /// Nested objects are recursively deserialized as nested dictionaries.
    /// </summary>
    public sealed class RecursiveDictionaryConverter : CustomCreationConverter<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Create(Type objectType)
            => new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        public override bool CanConvert(Type objectType)
            // We want to handle explicit objects and
            // also nested objects (which might be dictionaries)
            => objectType == typeof(object); // || base.CanConvert(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Deserialize nested objects as dictionaries
            var isObject = reader.TokenType == JsonToken.StartObject || reader.TokenType == JsonToken.Null;
            if (isObject)
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }

            // Deserialize arrays as List<object>
            var isArray = reader.TokenType == JsonToken.StartArray;
            if (isArray)
            {
                var list = new List<object>();

                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                {
                    list.Add(serializer.Deserialize(reader));
                }

                return list;
            }

            // If not, fall back to standard deserialization (for numbers, etc)
            return serializer.Deserialize(reader);
        }
    }
}
