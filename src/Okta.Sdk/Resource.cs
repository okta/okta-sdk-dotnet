using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public class Resource
    {
        private readonly IChangeTrackingDictionary<string, object> _data;
        private readonly ResourceFactory _resourceFactory;

        public Resource(IChangeTrackingDictionary<string, object> data)
        {
            _resourceFactory = new ResourceFactory();
            _data = data ?? _resourceFactory.NewDictionary();
        }

        public IDictionary<string, object> GetModifiedData()
            => (IDictionary<string, object>)_data.Difference;

        public void SetProperty(string key, object value)
            => _data[key] = value;

        public void SetResourceProperty<T>(string key, T value)
            where T : Resource
            => SetProperty(key, value?._data);

        public object GetProperty(string key)
        {
            _data.TryGetValue(key, out var value);
            return value;
        }

        public string GetStringProperty(string key)
            => GetProperty(key)?.ToString();

        public bool? GetBooleanProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null) return null;
            return bool.Parse(raw);
        }

        public int? GetIntProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null) return null;
            return int.Parse(raw);
        }

        public long? GetLongProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null) return null;
            return long.Parse(raw);
        }

        public DateTimeOffset? GetDateTimeProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null) return null;
            return DateTimeOffset.Parse(raw);
        }

        public IList<T> GetListProperty<T>(string key)
        {
            throw new NotImplementedException();
        }

        public T GetProperty<T>(string key)
            where T : Resource
        {
            var nestedData = GetProperty(key) as IChangeTrackingDictionary<string, object>;
            return _resourceFactory.Create<T>(nestedData);
        }
    }
}
