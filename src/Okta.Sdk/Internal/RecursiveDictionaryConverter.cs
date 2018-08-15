// <copyright file="RecursiveDictionaryConverter.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A JSON.NET converter that will deserialize objects into dictionaries.
    /// Nested objects are recursively deserialized as nested dictionaries.
    /// </summary>
    public sealed class RecursiveDictionaryConverter : CustomCreationConverter<IDictionary<string, object>>
    {
        /// <inheritdoc/>
        public override IDictionary<string, object> Create(Type objectType)
            => new Dictionary<string, object>(StringComparer.Ordinal);

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
            // We want to handle explicit objects and
            // also nested objects (which might be dictionaries)
            => objectType == typeof(object);

        /// <inheritdoc/>
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
                    var listObject = reader.TokenType == JsonToken.StartObject
                        ? base.ReadJson(reader, objectType, existingValue, serializer)
                        : serializer.Deserialize(reader);

                    list.Add(listObject);
                }

                return list;
            }

            // If not, fall back to standard deserialization (for numbers, etc)
            return serializer.Deserialize(reader);
        }
    }
}
