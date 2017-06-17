// <copyright file="Resource.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    public class Resource
    {
        private static readonly TypeInfo ResourceTypeInfo = typeof(Resource).GetTypeInfo();

        private readonly ResourceDictionaryType _dictionaryType;
        private IDataStore _dataStore;
        private ResourceFactory _resourceFactory;
        private ILogger _logger;
        private IDictionary<string, object> _data;

        public Resource()
            : this(ResourceDictionaryType.Default)
        {
        }

        public Resource(ResourceDictionaryType dictionaryType)
        {
            _dictionaryType = dictionaryType;
            Initialize(null, null, null, null);
        }

        internal ResourceDictionaryType DictionaryType => _dictionaryType;

        internal void Initialize(
            IDataStore dataStore,
            ResourceFactory resourceFactory,
            IDictionary<string, object> data,
            ILogger logger)
        {
            _dataStore = dataStore;
            _resourceFactory = resourceFactory ?? new ResourceFactory(dataStore, logger);
            _data = data ?? _resourceFactory.NewDictionary(_dictionaryType, null);
            _logger = logger ?? NullLogger.Instance;
        }

        protected IDataStore GetDataStore()
        {
            return _dataStore ?? throw new InvalidOperationException("Only resources retrieved or saved through a Client object can call server-side methods.");
        }

        public IDictionary<string, object> GetModifiedData()
        {
            switch (_data)
            {
                case DefaultChangeTrackingDictionary changeTrackingDictionary:
                    return (IDictionary<string, object>)changeTrackingDictionary.Difference;
                default:
                    return _data;
            }
        }

        public object this[string key]
        {
            get => GetProperty<object>(key);
            set => SetProperty(key, value);
        }

        /// <summary>
        /// Gets a property from the API resource.
        /// </summary>
        /// <remarks>In derived classes, use the more specific methods such as <see cref="GetStringProperty(string)"/> and <see cref="GetIntProperty(string)"/> instead.</remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="key">The property name.</param>
        /// <returns>The strongly-typed property value, or <c>null</c>.</returns>
        public T GetProperty<T>(string key)
        {
            if (typeof(T) == typeof(object))
            {
                return (T)GetPropertyOrNull(key);
            }

            if (typeof(T) == typeof(string))
            {
                return (T)(object)GetStringProperty(key);
            }

            if (typeof(T) == typeof(bool?))
            {
                return (T)(object)GetBooleanProperty(key);
            }

            if (typeof(T) == typeof(int?))
            {
                return (T)(object)GetIntegerProperty(key);
            }

            if (typeof(T) == typeof(long?))
            {
                return (T)(object)GetLongProperty(key);
            }

            if (typeof(T) == typeof(DateTimeOffset?))
            {
                return (T)(object)GetDateTimeProperty(key);
            }

            if (typeof(T) == typeof(DateTime?))
            {
                throw new InvalidOperationException("Use DateTimeOffset instead.");
            }

            if (ResourceTypeInfo.IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                return (T)(object)GetResourcePropertyInternal<T>(key);
            }

            var propertyData = GetPropertyOrNull(key);
            if (propertyData == null)
            {
                return default(T);
            }

            throw new NotImplementedException(); // todo
        }

        private object GetPropertyOrNull(string key)
        {
            _data.TryGetValue(key, out var value);
            return value;
        }

        public void SetProperty(string key, object value)
        {
            switch (value)
            {
                case Resource resource:
                    SetProperty(key, resource?._data);
                    break;

                default:
                    _data[key] = value;
                    break;
            }
        }

        protected string GetStringProperty(string key)
            => GetPropertyOrNull(key)?.ToString();

        protected bool? GetBooleanProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null)
            {
                return null;
            }

            return bool.Parse(raw);
        }

        protected int? GetIntegerProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null)
            {
                return null;
            }

            return int.Parse(raw);
        }

        protected long? GetLongProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null)
            {
                return null;
            }

            return long.Parse(raw);
        }

        protected DateTimeOffset? GetDateTimeProperty(string key)
        {
            var raw = GetStringProperty(key);
            if (raw == null)
            {
                return null;
            }

            return DateTimeOffset.Parse(raw);
        }

        public IList<T> GetArrayProperty<T>(string key)
        {
            var genericList = GetPropertyOrNull(key) as IList<object>;
            if (genericList == null)
            {
                return null;
            }

            return new CastingListAdapter<T>(genericList, _logger);
        }

        protected T GetResourceProperty<T>(string key)
            where T : Resource, new()
            => GetResourcePropertyInternal<T>(key);

        private T GetResourcePropertyInternal<T>(string key)
        {
            var nestedData = GetPropertyOrNull(key) as IDictionary<string, object>;
            return _resourceFactory.CreateFromExistingData<T>(nestedData);
        }
    }
}
