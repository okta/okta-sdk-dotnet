// <copyright file="ResourceSerializingConverter.cs" company="Okta, Inc">
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
    /// This class provides special serialization for <see cref="Resource"/> types.
    /// </summary>
    public sealed class ResourceSerializingConverter : JsonConverter
    {
        private static readonly TypeInfo ResourceTypeInfo = typeof(Resource).GetTypeInfo();

        /// <inheritdoc/>
        public override bool CanRead => false;

        /// <inheritdoc/>
        public override bool CanWrite => true;

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
            => ResourceTypeInfo.IsAssignableFrom(objectType.GetTypeInfo());

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var resource = value as Resource;
            if (value == null)
            {
                new JObject().WriteTo(writer);
                return;
            }

            var token = JToken.FromObject(resource.GetData(), serializer);
            token = RemoveEmptyChildren(token);
            token.WriteTo(writer);
        }

        private static JToken RemoveEmptyChildren(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                var copy = new JObject();
                foreach (var prop in token.Children<JProperty>())
                {
                    var child = prop.Value;

                    if (child.HasValues)
                    {
                        child = RemoveEmptyChildren(child);
                    }

                    if (!IsNull(child))
                    {
                        copy.Add(prop.Name, child);
                    }
                }

                return copy;
            }

            return token;
        }

#pragma warning disable SA1503 // Braces must not be omitted
        private static bool IsNull(JToken token)
        {
            if (token.Type == JTokenType.Object) return !token.HasValues;
            if (token.Type == JTokenType.Null) return true;

            return false;
        }
#pragma warning restore SA1503 // Braces must not be omitted
    }
}
