// <copyright file="DefaultChangeTrackingDictionary.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// An implementation of <see cref="IChangeTrackingDictionary{TKey, TValue}"/>.
    /// </summary>
    public sealed class DefaultChangeTrackingDictionary : IChangeTrackingDictionary<string, object>
    {
        private readonly IChangeTrackable _parent;
        private readonly string _parentKey;

        private readonly IReadOnlyDictionary<string, object> _initialData;
        private readonly IEqualityComparer<string> _keyComparer;

        private IDictionary<string, object> _data;
        private IList<string> _dirtyKeys;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultChangeTrackingDictionary"/> class.
        /// </summary>
        /// <param name="initialData">The initial dictionary state.</param>
        /// <param name="keyComparer">The key comparer to use.</param>
        public DefaultChangeTrackingDictionary(
            IDictionary<string, object> initialData = null,
            IEqualityComparer<string> keyComparer = null)
            : this(null, null, initialData, keyComparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultChangeTrackingDictionary"/> class.
        /// </summary>
        /// <param name="parent">The parent object, if any.</param>
        /// <param name="parentKey">The parent key, if any.</param>
        /// <param name="initialData">The initial dictionary state.</param>
        /// <param name="keyComparer">The key comparer to use.</param>
        public DefaultChangeTrackingDictionary(
            IChangeTrackable parent,
            string parentKey,
            IDictionary<string, object> initialData = null,
            IEqualityComparer<string> keyComparer = null)
        {
            if (parent != null)
            {
                if (string.IsNullOrEmpty(parentKey))
                {
                    throw new ArgumentNullException(nameof(parent), $"Both {nameof(parent)} and {nameof(parentKey)} must be specified.");
                }

                _parent = parent;
                _parentKey = parentKey;
            }

            _keyComparer = keyComparer ?? EqualityComparer<string>.Default;

            _initialData = initialData == null
                ? new Dictionary<string, object>(_keyComparer)
                : DeepCopy(initialData);

            Reset();
        }

        private Dictionary<string, object> DeepCopy(IEnumerable<KeyValuePair<string, object>> original)
        {
            if (original == null)
            {
                return new Dictionary<string, object>(_keyComparer);
            }

            return original.Select(kvp =>
            {
                if (kvp.Value is IDictionary<string, object> || kvp.Value is IReadOnlyDictionary<string, object>)
                {
                    var nestedCopy = new DefaultChangeTrackingDictionary(this, kvp.Key, DeepCopy(kvp.Value as IEnumerable<KeyValuePair<string, object>>), _keyComparer);
                    return new KeyValuePair<string, object>(kvp.Key, nestedCopy);
                }

                return kvp;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);
        }

        /// <inheritdoc/>
        public void MarkDirty(string key)
        {
            if (!_dirtyKeys.Contains(key))
            {
                _dirtyKeys.Add(key);
            }

            _parent?.MarkDirty(_parentKey);
        }

        /// <inheritdoc/>
        public void MarkClean(string key)
        {
            _dirtyKeys?.Remove(key);
        }

        /// <inheritdoc/>
        public void Reset()
        {
            _data = DeepCopy(_initialData);
            _dirtyKeys = new List<string>(_data.Count);
            _parent?.MarkClean(_parentKey);
        }

        /// <inheritdoc/>
        public object Difference
            => _data
                .Where(kvp => _dirtyKeys.Contains(kvp.Key, _keyComparer))
                .Select(kvp => kvp.Value is IChangeTrackingDictionary<string, object> nested
                    ? new KeyValuePair<string, object>(kvp.Key, nested.Difference)
                    : kvp)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value, _keyComparer);

        /// <inheritdoc/>
        public object this[string key]
        {
            get => _data[key];

            set
            {
                MarkDirty(key);
                _data[key] = value;
            }
        }

        /// <inheritdoc/>
        public void Add(string key, object value)
        {
            MarkDirty(key);
            _data.Add(key, value);
        }

        /// <inheritdoc/>
        public void Add(KeyValuePair<string, object> item)
        {
            MarkDirty(item.Key);
            _data.Add(item);
        }

        /// <inheritdoc/>
        public bool Remove(string key)
        {
            MarkDirty(key);
            return _data.Remove(key);
        }

        /// <inheritdoc/>
        public bool Remove(KeyValuePair<string, object> item)
        {
            MarkDirty(item.Key);
            return _data.Remove(item);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ICollection<string> Keys => _data.Keys;

        /// <inheritdoc/>
        public ICollection<object> Values => _data.Values;

        /// <inheritdoc/>
        public int Count => _data.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => _data.IsReadOnly;

        /// <inheritdoc/>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public bool Contains(KeyValuePair<string, object> item) => _data.Contains(item);

        /// <inheritdoc/>
        public bool ContainsKey(string key) => _data.ContainsKey(key);

        /// <inheritdoc/>
        public bool TryGetValue(string key, out object value) => _data.TryGetValue(key, out value);

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _data.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
