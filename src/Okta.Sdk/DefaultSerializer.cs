using Newtonsoft.Json;
using Okta.Sdk.Abstractions;
using System.Collections.Generic;
using System.IO;
using System;

namespace Okta.Sdk
{
    public sealed class DefaultSerializer : ISerializer
    {
        private const string EmptyObject = "{ }";
        private readonly JsonSerializer _serializer;

        public DefaultSerializer()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(
                new RecursiveDictionaryConverter(() => new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)));
        }

        public IDictionary<string, object> Deserialize(string json)
            => Deserialize<IDictionary<string, object>>(json);

        public IEnumerable<IDictionary<string, object>> DeserializeArray(string json)
            => Deserialize<IDictionary<string, object>[]>(json);

        public string Serialize(object model)
        {
            throw new NotImplementedException();
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
