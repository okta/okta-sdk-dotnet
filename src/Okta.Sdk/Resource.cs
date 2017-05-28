using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public class Resource
    {
        private readonly ChangeTrackingDictionary _data;
        private readonly IResourceFactory _resourceFactory;

        public Resource(ChangeTrackingDictionary data, IResourceFactory resourceFactory)
        {
            _data = data;
            _resourceFactory = resourceFactory;
        }

        public IDictionary<string, object> ModifiedData
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
            where T : Resource, new()
        {
            var nestedData = GetProperty(key) as ChangeTrackingDictionary;
            return _resourceFactory.Create<T>(nestedData);
        }
    }
}
