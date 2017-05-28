using Okta.Sdk.Abstractions;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public class Resource
    {
        private readonly IDeltaDictionary<string, object> _data;
        private readonly ResourceFactory _resourceFactory;

        public Resource(IDeltaDictionary<string, object> data)
        {
            _resourceFactory = new ResourceFactory();
            _data = data ?? _resourceFactory.NewDictionary();
        }

        public IDictionary<string, object> GetModifiedData()
            => _data.ModifiedData;

        public object GetProperty(string key)
        {
            _data.TryGetValue(key, out var value);
            return value;
        }

        public void SetProperty(string key, object value)
            => _data[key] = value;

        public string GetStringProperty(string key)
            => GetProperty(key)?.ToString();

        public bool? GetBooleanProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null) return null;
            return bool.Parse(raw);
        }

        public T GetProperty<T>(string key)
            where T : Resource
        {
            var nestedData = GetProperty(key) as IDeltaDictionary<string, object>;
            return _resourceFactory.Create<T>(nestedData);
        }
    }
}
