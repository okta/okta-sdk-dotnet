// <copyright file="DefaultSerializer.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Okta.Sdk.Internal
{
    public sealed class DefaultSerializer : ISerializer
    {
        private const string EmptyObject = "{ }";
        private readonly JsonSerializer _serializer;

        public DefaultSerializer()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new RecursiveDictionaryConverter());
        }

        public IDictionary<string, object> Deserialize(string json)
            => Deserialize<IDictionary<string, object>>(json);

        public IEnumerable<IDictionary<string, object>> DeserializeArray(string json)
            => Deserialize<IDictionary<string, object>[]>(json);

        public string Serialize(object model)
        {
            using (var writer = new StringWriter())
            {
                _serializer.Serialize(writer, model);
                writer.Flush();
                return writer.ToString();
            }
        }

        private T Deserialize<T>(string input)
        {
            var json = string.IsNullOrEmpty(input)
                ? EmptyObject
                : input;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
