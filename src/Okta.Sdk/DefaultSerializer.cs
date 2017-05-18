using Newtonsoft.Json;
using Okta.Sdk.Abstractions;
using System.Collections.Generic;
using System.IO;

namespace Okta.Sdk
{
    public sealed class DefaultSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        public DefaultSerializer()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new RecursiveImmutableDictionaryConverter());
        }

        public IReadOnlyDictionary<string, object> Deserialize(string json)
        {
            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<IReadOnlyDictionary<string, object>>(jsonReader);
            }
        }
    }
}
