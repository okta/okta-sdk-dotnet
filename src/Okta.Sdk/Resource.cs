// <copyright file="Resource.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public class Resource
    {
        private readonly ResourceFactory _resourceFactory;
        private readonly ResourceDictionaryType _dictionaryType;
        private IDictionary<string, object> _data;

        public Resource()
            : this(ResourceDictionaryType.Default)
        {
        }

        public Resource(ResourceDictionaryType dictionaryType)
        {
            _resourceFactory = new ResourceFactory();
            _dictionaryType = dictionaryType;
            Initialize(null);
        }

        internal ResourceDictionaryType DictionaryType => _dictionaryType;

        internal void Initialize(IDictionary<string, object> data)
        {
            _data = data ?? _resourceFactory.NewDictionary(_dictionaryType, null);
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
            get => GetPropertyOrNull(key);
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
            where T : class, new() // forces value types to be Nullable<T>
        {
            if (typeof(T) == typeof(object))
            {
                return (T)GetPropertyOrNull(key);
            }

            if (typeof(T) == typeof(string))
            {
                return GetStringProperty(key) as T;
            }

            if (typeof(T) == typeof(bool?))
            {
                return GetBooleanProperty(key) as T;
            }

            if (typeof(T) == typeof(int?))
            {
                return GetIntProperty(key) as T;
            }

            if (typeof(T) == typeof(long?))
            {
                return GetLongProperty(key) as T;
            }

            if (typeof(T) == typeof(DateTimeOffset?))
            {
                return GetDateTimeProperty(key) as T;
            }

            if (typeof(T) == typeof(DateTime?))
            {
                throw new InvalidOperationException("Use DateTimeOffset instead.");
            }

            var propertyData = GetPropertyOrNull(key);
            if (propertyData == null)
            {
                return null;
            }

            if (propertyData is IDictionary<string, object> nestedResourceData)
            {
                return _resourceFactory.CreateFromExistingData<T>(nestedResourceData);
            }
        }

        private object GetPropertyOrNull(string key)
        {
            _data.TryGetValue(key, out var value);
            return value;
        }

        private void SetProperty(string key, object value)
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

        protected int? GetIntProperty(string key)
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

        protected T GetResourceProperty<T>(string key)
            where T : Resource, new()
        {
            var nestedData = GetPropertyOrNull(key) as IDictionary<string, object>;
            return _resourceFactory.CreateFromExistingData<T>(nestedData);
        }
    }
}
