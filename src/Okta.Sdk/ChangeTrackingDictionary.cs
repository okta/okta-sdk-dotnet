using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public class ChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Func<IDictionary<TKey, TValue>, IDictionary<TKey, TValue>> _dictionaryFactory;
        private readonly IDictionary<TKey, TValue> _initialData;
        private IDictionary<TKey, TValue> _modifiedData;

        public ChangeTrackingDictionary(
            Func<IDictionary<TKey, TValue>, IDictionary<TKey, TValue>> dictionaryFactory,
            IDictionary<TKey, TValue> initialData = null)
        {
            _dictionaryFactory = dictionaryFactory;

            // Use the factory to create either a new blank dictionary, or a dictionary using the given initial data
            _initialData = initialData == null
                ? _dictionaryFactory(null)
                : _dictionaryFactory(initialData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

            ResetChanges();
        }

        private IDictionary<TKey, TValue> CombinedData
            => _dictionaryFactory(_modifiedData
                .Concat(_initialData.Where(kvp => !_modifiedData.ContainsKey(kvp.Key)))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

        public IDictionary<TKey, TValue> ModifiedData
            => _dictionaryFactory(_modifiedData);

        public IDictionary<TKey, TValue> OriginalData
            => _dictionaryFactory(_initialData);

        public void ResetChanges()
        {
            _modifiedData = _dictionaryFactory(null);
        }

        public virtual void MarkDirty(TKey key)
        {
            // Noop
        }

        public TValue this[TKey key]
        {
            get
            {
                if (_modifiedData.TryGetValue(key, out TValue value))
                {
                    return value;
                }

                _initialData.TryGetValue(key, out value);
                return value;
            }

            set
            {
                MarkDirty(key);
                _modifiedData[key] = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            MarkDirty(key);
            _modifiedData.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            MarkDirty(item.Key);
            _modifiedData.Add(item);
        }

        public void Clear()
        {
            ResetChanges();

            foreach (var key in _initialData.Keys)
            {
                MarkDirty(key);
                _modifiedData[key] = default(TValue);
            }
        }

        public bool Remove(TKey key)
        {
            MarkDirty(key);
            return _modifiedData.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            MarkDirty(item.Key);
            return _modifiedData.Remove(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            CombinedData.CopyTo(array, arrayIndex);
        }

        public ICollection<TKey> Keys => CombinedData.Keys;

        public ICollection<TValue> Values => CombinedData.Values;

        public int Count => CombinedData.Count;

        public bool IsReadOnly => _modifiedData.IsReadOnly;

        public bool Contains(KeyValuePair<TKey, TValue> item) => CombinedData.Contains(item);

        public bool ContainsKey(TKey key) => CombinedData.ContainsKey(key);

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_modifiedData.TryGetValue(key, out value)) return true;

            return _initialData.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => CombinedData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => CombinedData.GetEnumerator();
    }
}
