using System.Collections;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public sealed class ChangeTrackingDictionary : IDictionary<string, object>
    {
        private readonly IDictionary<string, object> _dictionary;
        private readonly ChangeTrackingDictionary _parent;
        private readonly string _parentKey;

        public ChangeTrackingDictionary(
            IDictionary<string, object> dictionary,
            ChangeTrackingDictionary parent,
            string parentKey)
        {
            _dictionary = dictionary;
            _parent = parent;
            _parentKey = parentKey;
        }

        private void MarkDirty(string key)
        {
            throw new KeyNotFoundException();
        }

        public object this[string key]
        {
            get => _dictionary[key];

            set
            {
                _parent?.MarkDirty(_parentKey);
                _dictionary[key] = value;
            }
        }

        public void Add(string key, object value)
        {
            _parent?.MarkDirty(_parentKey);
            _dictionary.Add(key, value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _parent?.MarkDirty(_parentKey);
            _dictionary.Add(item);
        }

        public void Clear()
        {
            _parent?.MarkDirty(_parentKey);
            _dictionary.Clear();
        }

        public bool Remove(string key)
        {
            _parent?.MarkDirty(_parentKey);
            return _dictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            _parent?.MarkDirty(_parentKey);
            return _dictionary.Remove(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        public ICollection<string> Keys => _dictionary.Keys;

        public ICollection<object> Values => _dictionary.Values;

        public int Count => _dictionary.Count;

        public bool IsReadOnly => _dictionary.IsReadOnly;

        public bool Contains(KeyValuePair<string, object> item) => _dictionary.Contains(item);

        public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

        public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();
    }
}
