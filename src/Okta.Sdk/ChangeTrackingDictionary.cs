using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public class ChangeTrackingDictionary : IEnumerable<KeyValuePair<string, object>>
    {
        private readonly IReadOnlyDictionary<string, object> _initialData;
        private readonly IEqualityComparer<string> _keyComparer;

        private IDictionary<string, object> _data;
        private IList<string> _dirtyKeys;

        public ChangeTrackingDictionary(
            IDictionary<string, object> initialData = null,
            IEqualityComparer<string> keyComparer = null)
        {
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
                    ? new ChangeTrackingDictionary(DeepCopy(kvp.Value as IEnumerable<KeyValuePair<string, object>>), _keyComparer)
                    : kvp.Value;

                return new KeyValuePair<string, object>(kvp.Key, value);
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);
        }

        public void ResetChanges()
        {
            _data = DeepCopy(_initialData);
            _dirtyKeys = new List<string>(_data.Count);

        }

        //private IDictionary<TKey, TValue> CombinedData
        //    => _dictionaryFactory(_data
        //        .Concat(_initialData.Where(kvp => !_data.ContainsKey(kvp.Key)))
        //        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

        public IDictionary<string, object> ModifiedData
            => _data
                .Where(kvp => _dirtyKeys.Contains(kvp.Key))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);

        //public IDictionary<TKey, TValue> OriginalData
        //    => _dictionaryFactory(_initialData);

        public virtual void MarkDirty(string key)
        {
            _dirtyKeys.Add(key);
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
