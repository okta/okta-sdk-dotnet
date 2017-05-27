using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public class Resource
    {
        private IDictionary<string, object> _data;

        public Resource()
        {
            _data = new ChangeTrackingDictionary<string, object>(keyComparer: StringComparer.OrdinalIgnoreCase);
        }

        public void ResetWithData(IDictionary<string, object> data)
        {
            _data = new ChangeTrackingDictionary<string, object>(data, StringComparer.OrdinalIgnoreCase);
        }

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
            var nestedData = GetProperty(key) as IDictionary<string, object>;
            return ResourceFactory.Create<T>(nestedData);
        }
    }
}
