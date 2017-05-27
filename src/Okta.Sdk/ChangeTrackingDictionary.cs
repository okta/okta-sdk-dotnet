using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public class ChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IReadOnlyDictionary<TKey, TValue> _initialData;
        private readonly IEqualityComparer<TKey> _keyComparer;

        private IDictionary<TKey, TValue> _data;
        private IList<TKey> _dirtyKeys;

        public ChangeTrackingDictionary(
            IDictionary<TKey, TValue> initialData = null,
            IEqualityComparer<TKey> keyComparer = null)
        {
            _keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;

            _initialData = initialData == null
                ? new Dictionary<TKey, TValue>(_keyComparer)
                : CopyDictionary(initialData);

            ResetChanges();
        }

        private Dictionary<TKey, TValue> CopyDictionary(IDictionary<TKey, TValue> original)
        {
            if (original == null) return new Dictionary<TKey, TValue>(_keyComparer);
            return new Dictionary<TKey, TValue>(original, _keyComparer);
        }

        private Dictionary<TKey, TValue> CopyDictionary(IReadOnlyDictionary<TKey, TValue> original)
        {
            if (original == null) return new Dictionary<TKey, TValue>(_keyComparer);
            return original.ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);
        }

        public void ResetChanges()
        {
            _data = CopyDictionary(_initialData);
            _dirtyKeys = new List<TKey>(_data.Count);

        }

        //private IDictionary<TKey, TValue> CombinedData
        //    => _dictionaryFactory(_data
        //        .Concat(_initialData.Where(kvp => !_data.ContainsKey(kvp.Key)))
        //        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

        public IDictionary<TKey, TValue> ModifiedData
            => _data
                .Where(kvp => _dirtyKeys.Contains(kvp.Key))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);

        //public IDictionary<TKey, TValue> OriginalData
        //    => _dictionaryFactory(_initialData);

        public virtual void MarkDirty(TKey key)
        {
            _dirtyKeys.Add(key);
        }

        public TValue this[TKey key]
        {
            get => _data[key];

            set
            {
                MarkDirty(key);
                _data[key] = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            MarkDirty(key);
            _data.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            MarkDirty(item.Key);
            _data.Add(item);
        }

        public void Clear()
        {
            ResetChanges();

            foreach (var key in _initialData.Keys)
            {
                MarkDirty(key);
                _data[key] = default(TValue);
            }
        }

        public bool Remove(TKey key)
        {
            MarkDirty(key);
            return _data.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            MarkDirty(item.Key);
            return _data.Remove(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public ICollection<TKey> Keys => _data.Keys;

        public ICollection<TValue> Values => _data.Values;

        public int Count => _data.Count;

        public bool IsReadOnly => _data.IsReadOnly;

        public bool Contains(KeyValuePair<TKey, TValue> item) => _data.Contains(item);

        public bool ContainsKey(TKey key) => _data.ContainsKey(key);

        public bool TryGetValue(TKey key, out TValue value) => _data.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
