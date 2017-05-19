using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public abstract class AbstractResource
    {
        private readonly IResourceFactory _resourceFactory;

        private readonly IReadOnlyDictionary<string, object> _originalData;
        private readonly Dictionary<string, object> _updatedData;

        public AbstractResource(
            IReadOnlyDictionary<string, object> data,
            IResourceFactory resourceFactory)
        {
            if (resourceFactory == null)
            {
                // TODO - new only mode
            }

            _resourceFactory = resourceFactory;
            _originalData = data;
            _updatedData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        private object GetData(string key)
        {
            if (_updatedData.TryGetValue(key, out var updatedValue))
            {
                return updatedValue;
            }

            _originalData.TryGetValue(key, out var value);
            return value;
        }

        public void SetValue(string key, object value)
            => _updatedData[key] = value;

        public string GetString(string key)
            => GetData(key)?.ToString();

        public bool? GetBoolean(string key)
        {
            var raw = GetString(key);
            if (raw == null) return null;
            return bool.Parse(raw);
        }

        public T GetResource<T>(string key)
            => _resourceFactory.Create<T>(GetData(key) as IReadOnlyDictionary<string, object>);
    }
}
