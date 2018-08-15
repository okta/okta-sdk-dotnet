// <copyright file="DefaultSerializer.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// The default implementation of <see cref="ISerializer"/> that uses JSON.NET.
    /// </summary>
    public sealed class DefaultSerializer : ISerializer
    {
        private const string EmptyObject = "{ }";
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSerializer"/> class.
        /// </summary>
        public DefaultSerializer()
        {
            _serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver(),
            };

            _serializer.Converters.Add(new RecursiveDictionaryConverter());
            _serializer.Converters.Add(new ResourceSerializingConverter());
            _serializer.Converters.Add(new StringEnumSerializingConverter());
        }

        /// <inheritdoc/>
        public IDictionary<string, object> Deserialize(string json)
            => Deserialize<IDictionary<string, object>>(json);

        /// <inheritdoc/>
        public IEnumerable<IDictionary<string, object>> DeserializeArray(string json)
            => Deserialize<IDictionary<string, object>[]>(json);

        /// <inheritdoc/>
        public string Serialize(object model)
        {
            if (model == null)
            {
                return null;
            }

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
