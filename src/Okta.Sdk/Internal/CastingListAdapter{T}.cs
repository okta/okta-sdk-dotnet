// <copyright file="CastingListAdapter{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Wraps a generic <c>List&lt;object&gt;</c> and casts the items to the destination type.
    /// </summary>
    /// <typeparam name="T">The destination type.</typeparam>
    public sealed class CastingListAdapter<T> : IList<T>
    {
        private readonly IList<object> _genericList;
        private readonly ResourceFactory _resourceFactory;
        private readonly TypeInfo _targetTypeInfo;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastingListAdapter{T}"/> class.
        /// </summary>
        /// <param name="genericList">The generic list to wrap.</param>
        /// <param name="resourceFactory">The resource factory</param>
        /// <param name="logger">The logging interface.</param>
        public CastingListAdapter(IList<object> genericList, ResourceFactory resourceFactory, ILogger logger)
        {
            _targetTypeInfo = typeof(T).GetTypeInfo();
            _resourceFactory = resourceFactory;
            _genericList = genericList;
            _logger = logger;
        }

        private T Cast(object item)
        {
            var isResource = Resource.ResourceTypeInfo.IsAssignableFrom(_targetTypeInfo);
            if (isResource)
            {
                var nestedData = item as IDictionary<string, object>;
                return _resourceFactory.CreateFromExistingData<T>(nestedData);
            }

            var isStringEnum = StringEnum.TypeInfo.IsAssignableFrom(_targetTypeInfo);
            if (isStringEnum)
            {
                return StringEnum.Create<T>(item?.ToString());
            }

            // Fall back to primitive conversion
            try
            {
                if (!(item is IConvertible))
                {
                    return (T)item;
                }

                return (T)Convert.ChangeType(item, typeof(T));
            }
            catch (InvalidCastException ice)
            {
                _logger.LogWarning($"Tried to access type '{item.GetType().Name}' in an array of type '{typeof(T).Name}'; returning default value. Value: '{item}'. Exception: {ice.Message}");
                return default(T);
            }
        }

        /// <inheritdoc />
        public T this[int index]
        {
            get => Cast(_genericList[index]);
            set => _genericList[index] = value;
        }

        /// <inheritdoc />
        public int Count => _genericList.Count;

        /// <inheritdoc />
        public bool IsReadOnly => _genericList.IsReadOnly;

        /// <inheritdoc />
        public void Add(T item) => _genericList.Add(item);

        /// <inheritdoc />
        public void Clear() => _genericList.Clear();

        /// <inheritdoc />
        public bool Contains(T item)
        {
            var casted = _genericList
                .Select(Cast)
                .ToArray();
            return casted.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
            => _genericList.Select(Cast).ToArray().CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _genericList)
            {
                yield return Cast(item);
            }
        }

        /// <inheritdoc />
        public int IndexOf(T item) => _genericList.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, T item) => _genericList.Insert(index, item);

        /// <inheritdoc />
        public bool Remove(T item) => _genericList.Remove(item);

        /// <inheritdoc />
        public void RemoveAt(int index) => _genericList.RemoveAt(index);

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
