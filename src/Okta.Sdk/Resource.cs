using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public class Resource
    {
        private IReadOnlyDictionary<string, object> _originalData;
        private Dictionary<string, object> _updatedData;

        public Resource()
        {
            _originalData = DictionaryFactory.NewCaseInsensitiveDictionary();
            ResetModifications();
        }

        private void ResetModifications()
        {
            _updatedData = DictionaryFactory.NewCaseInsensitiveDictionary();
        }

        public void ResetWithData(IReadOnlyDictionary<string, object> data)
        {
            _originalData = data?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value, StringComparer.OrdinalIgnoreCase)
                ?? DictionaryFactory.NewCaseInsensitiveDictionary();

            ResetModifications();
        }

        public object GetProperty(string key)
        {
            if (_updatedData.TryGetValue(key, out var updatedValue))
            {
                return updatedValue;
            }

            object value = null;
            _originalData?.TryGetValue(key, out value);
            return value;
        }

        public void SetProperty(string key, object value)
            => _updatedData[key] = value;

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
            var nestedData = GetProperty(key) as IReadOnlyDictionary<string, object>;
            return ResourceFactory.Create<T>(nestedData);
        }
    }
}
