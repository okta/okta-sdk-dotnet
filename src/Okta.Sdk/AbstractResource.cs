using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public abstract class AbstractResource
    {
        private readonly IReadOnlyDictionary<string, object> _originalData;
        private readonly IResourceFactory _resourceFactory;

        public AbstractResource(
            IReadOnlyDictionary<string, object> data,
            IResourceFactory resourceFactory)
        {
            _originalData = data ?? new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            _resourceFactory = resourceFactory ?? throw new ArgumentNullException(nameof(resourceFactory));
        }

        private object GetData(string key)
        {
            _originalData.TryGetValue(key, out var value);
            return value;
        }

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
