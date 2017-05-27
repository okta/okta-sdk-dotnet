using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public sealed class ChangeTrackingDictionary : IEnumerable<KeyValuePair<string, object>>
    {
        private readonly ChangeTrackingDictionary _parent;
        private readonly string _parentKey;

        private readonly IReadOnlyDictionary<string, object> _initialData;
        private readonly IEqualityComparer<string> _keyComparer;

        private IDictionary<string, object> _data;
        private IList<string> _dirtyKeys;

        public ChangeTrackingDictionary(
            IDictionary<string, object> initialData = null,
            IEqualityComparer<string> keyComparer = null)
            : this(null, null, initialData, keyComparer)
        {
        }

        public ChangeTrackingDictionary(
            ChangeTrackingDictionary parent,
            string parentKey,
            IDictionary<string, object> initialData = null,
            IEqualityComparer<string> keyComparer = null)
        {
            if (parent != null)
            {
                if (string.IsNullOrEmpty(parentKey)) throw new ArgumentNullException(nameof(parent), $"Both {nameof(parent)} and {nameof(parentKey)} must be specified.");

                _parent = parent;
                _parentKey = parentKey;
            }

            _keyComparer = keyComparer ?? EqualityComparer<string>.Default;

            _initialData = initialData == null
                ? new Dictionary<string, object>(_keyComparer)
                : DeepCopy(initialData);

            ResetChanges();
        }

        private Dictionary<string, object> DeepCopy(IEnumerable<KeyValuePair<string, object>> original)
        {
            if (original == null) return new Dictionary<string, object>(_keyComparer);

            return original.Select(kvp =>
            {
                bool isNested = kvp.Value.GetType() == typeof(ChangeTrackingDictionary);

                var value = isNested
                    ? new ChangeTrackingDictionary(this, kvp.Key, DeepCopy(kvp.Value as IEnumerable<KeyValuePair<string, object>>), _keyComparer)
                    : kvp.Value;

                return new KeyValuePair<string, object>(kvp.Key, value);
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);
        }

        public void ResetChanges()
        {
            _data = DeepCopy(_initialData);
            _dirtyKeys = new List<string>(_data.Count);
            _parent?.MarkClean(_parentKey);
        }

        public IDictionary<string, object> ModifiedData
            => _data
                .Where(kvp => _dirtyKeys.Contains(kvp.Key))
                .Select(kvp =>
                {
                    bool isNested = kvp.Value.GetType() == typeof(ChangeTrackingDictionary);

                    var value = isNested
                        ? (kvp.Value as ChangeTrackingDictionary).ModifiedData
                        : kvp.Value;

                    return new KeyValuePair<string, object>(kvp.Key, value);
                })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);

        private void MarkDirty(string key)
        {
            if (!_dirtyKeys.Contains(key)) _dirtyKeys.Add(key);
            _parent?.MarkDirty(_parentKey);
        }

        private void MarkClean(string key)
        {
            _dirtyKeys?.Remove(key);
        }

        public object this[string key]
        {
            get => _data[key];

            set
            {
                MarkDirty(key);
                _data[key] = value;
            }
        }

        public void Add(string key, object value)
        {
            MarkDirty(key);
            _data.Add(key, value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            MarkDirty(item.Key);
            _data.Add(item);
        }

        //public void Clear()
        //{
        //    ResetChanges();

        //    foreach (var key in _initialData.Keys)
        //    {
        //        MarkDirty(key);
        //        _data[key] = default(TValue);
        //    }
        //}

        public bool Remove(string key)
        {
            MarkDirty(key);
            return _data.Remove(key);
        }

        public ICollection<string> Keys => _data.Keys;

        public ICollection<object> Values => _data.Values;

        public int Count => _data.Count;

        public bool ContainsKey(string key) => _data.ContainsKey(key);

        public bool TryGetValue(string key, out object value) => _data.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
