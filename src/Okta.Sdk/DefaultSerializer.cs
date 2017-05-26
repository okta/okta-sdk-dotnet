using Newtonsoft.Json;
using Okta.Sdk.Abstractions;
using System.Collections.Generic;
using System.IO;

namespace Okta.Sdk
{
    public sealed class DefaultSerializer : ISerializer
    {
        private const string EmptyObject = "{ }";
        private readonly JsonSerializer _serializer;

        public DefaultSerializer()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new RecursiveImmutableDictionaryConverter());
        }

        public IReadOnlyDictionary<string, object> Deserialize(string json)
            => Deserialize<IReadOnlyDictionary<string, object>>(json);

        public IEnumerable<IReadOnlyDictionary<string, object>> DeserializeArray(string json)
            => Deserialize<IReadOnlyDictionary<string, object>[]>(json);

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
