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
    /// <summary>
    /// Represents a resource in the Okta API.
    /// </summary>
    public class Resource
    {
        private static readonly TypeInfo ResourceTypeInfo = typeof(Resource).GetTypeInfo();
        private static readonly TypeInfo StringEnumTypeInfo = typeof(StringEnum).GetTypeInfo();

        private readonly ResourceBehavior _dictionaryType;
        private IOktaClient _client;
        private ResourceFactory _resourceFactory;
        private ILogger _logger;
        private IDictionary<string, object> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// </summary>
        /// <remarks>Uses the default dictionary type (non-change tracking).</remarks>
        public Resource()
            : this(ResourceBehavior.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// </summary>
        /// <param name="dictionaryType">The dictionary type to use.</param>
        public Resource(ResourceBehavior dictionaryType)
        {
            _dictionaryType = dictionaryType;
            Initialize(null, null, null, null);
        }

        internal ResourceBehavior DictionaryType => _dictionaryType;

        internal void Initialize(
            IOktaClient client,
            ResourceFactory resourceFactory,
            IDictionary<string, object> data,
            ILogger logger)
        {
            _client = client;
            _resourceFactory = resourceFactory ?? new ResourceFactory(client, logger);
            _data = data ?? _resourceFactory.NewDictionary(_dictionaryType, null);
            _logger = logger ?? NullLogger.Instance;
        }

        protected IOktaClient GetClient()
        {
            return _client ?? throw new InvalidOperationException("Only resources retrieved or saved through a Client object cna call server-side methods.");
        }

        /// <summary>
        /// Gets the underlying data backing this resource.
        /// </summary>
        /// <returns>The data backing this resource.</returns>
        /// <remarks>
        /// If the resource is initialized with dictionary type <see cref="ResourceBehavior.ChangeTracking"/>, this returns any updates merged with the original data.
        /// </remarks>
        public IDictionary<string, object> GetData()
            => _resourceFactory.NewDictionary(_dictionaryType, _data);

        /// <summary>
        /// Gets any data that has been modified since the resource was retrieved.
        /// </summary>
        /// <remarks>This has no effect (behaves the same as <see cref="GetData"/>) unless the resource was initialized with dictionary type <see cref="ResourceBehavior.ChangeTracking"/>.</remarks>
        /// <returns></returns>
        public IDictionary<string, object> GetModifiedData()
        {
            if (_data is DefaultChangeTrackingDictionary changeTrackingDictionary)
            {
                return (IDictionary<string, object>)changeTrackingDictionary.Difference;
            }

            return GetData();
        }

        /// <summary>
        /// Gets or sets a resource proprety by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value, or<c>null</c>.</returns>
        public object this[string name]
        {
            get => GetProperty<object>(name);
            set => SetProperty(name, value);
        }

        /// <summary>
        /// Gets a resource property by name.
        /// </summary>
        /// <remarks>In derived classes, use the more specific methods such as <see cref="GetStringProperty(string)"/> and <see cref="GetIntegerProperty(string)"/> instead.</remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>The strongly-typed property value, or <c>null</c>.</returns>
        public T GetProperty<T>(string name)
        {
            var typeInfo = typeof(T).GetTypeInfo();

            if (ResourceTypeInfo.IsAssignableFrom(typeInfo))
            {
                return GetResourcePropertyInternal<T>(name);
            }

            if (StringEnumTypeInfo.IsAssignableFrom(typeInfo))
            {
                return GetEnumPropertyInternal<T>(name);
            }

            if (typeof(T) == typeof(object))
            {
                return (T)GetPropertyOrNull(name);
            }

            if (typeof(T) == typeof(string))
            {
                return (T)(object)GetStringProperty(name);
            }

            if (typeof(T) == typeof(bool?))
            {
                return (T)(object)GetBooleanProperty(name);
            }

            if (typeof(T) == typeof(int?))
            {
                return (T)(object)GetIntegerProperty(name);
            }

            if (typeof(T) == typeof(long?))
            {
                return (T)(object)GetLongProperty(name);
            }

            if (typeof(T) == typeof(DateTimeOffset?))
            {
                return (T)(object)GetDateTimeProperty(name);
            }

            if (typeof(T) == typeof(DateTime?))
            {
                throw new InvalidOperationException("Use DateTimeOffset instead.");
            }

            var propertyData = GetPropertyOrNull(name);
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

        internal void SetProperty(string name, object value)
        {
            switch (value)
            {
                case Resource resource:
                    SetProperty(name, resource?._data);
                    break;

                case StringEnum @enum:
                    SetProperty(name, @enum?.Value);
                    break;

                default:
                    _data[name] = value;
                    break;
            }
        }

        /// <summary>
        /// Gets a <see cref="string"/> property from the resource by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value as a <see cref="string"/>, or <c>null</c>.</returns>
        protected string GetStringProperty(string name)
            => GetPropertyOrNull(name)?.ToString();

        /// <summary>
        /// Gets a <see cref="bool"/> property from the resource by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value as a <see cref="bool"/>, or <c>null</c>.</returns>
        /// <exception cref="FormatException">The value is not equal to the value of the <see cref="bool.TrueString"/> or <see cref="bool.FalseString"/> field.</exception>
        protected bool? GetBooleanProperty(string name)
        {
            var raw = GetStringProperty(name);
            if (raw == null)
            {
                return null;
            }

            return bool.Parse(raw);
        }

        /// <summary>
        /// Gets an <see cref="int"/> property from the resource by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value as an <see cref="int"/>, or <c>null</c>.</returns>
        /// <exception cref="FormatException">The value is not in the correct format.</exception>
        /// <exception cref="OverflowException">The value represents a number less than <see cref="int.MinValue"/> or greater than <see cref="int.MaxValue"/>.</exception>
        protected int? GetIntegerProperty(string name)
        {
            var raw = GetStringProperty(name);
            if (raw == null)
            {
                return null;
            }

            return int.Parse(raw);
        }

        /// <summary>
        /// Gets a <see cref="long"/> property from the resource by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value as a <see cref="long"/>, or <c>null</c>.</returns>
        /// <exception cref="FormatException">The value is not in the correct format.</exception>
        /// <exception cref="OverflowException">The value represents a number less than <see cref="long.MinValue"/> or greater than <see cref="long.MaxValue"/>.</exception>
        protected long? GetLongProperty(string name)
        {
            var raw = GetStringProperty(name);
            if (raw == null)
            {
                return null;
            }

            return long.Parse(raw);
        }

        /// <summary>
        /// Gets a datetime property from the resource by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value as a <see cref="DateTimeOffset"/>, or <c>null</c>.</returns>
        /// <exception cref="ArgumentException">The offset is greater than 14 hours or less than -14 hours.</exception>
        /// <exception cref="FormatException">
        /// The value does not contain a valid string representation of a date and time, or the value
        /// contains the string representation of an offset value without a date or time.
        /// </exception>
        protected DateTimeOffset? GetDateTimeProperty(string name)
        {
            var raw = GetStringProperty(name);
            if (raw == null)
            {
                return null;
            }

            return DateTimeOffset.Parse(raw);
        }

        /// <summary>
        /// Gets a list or array property from the resource by name.
        /// </summary>
        /// <typeparam name="T">The type of items contained in the list or array.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>A <see cref="IList{T}">list</see> that can be enumerated to obtain the property items.</returns>
        public IList<T> GetArrayProperty<T>(string name)
        {
            var genericList = GetPropertyOrNull(name) as IList<object>;
            if (genericList == null)
            {
                return null;
            }

            return new CastingListAdapter<T>(genericList, _logger);
        }

        /// <summary>
        /// Gets a string enum property from the resource by name.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>The property value wrapped in the specified enum type, or <c>null</c>.</returns>
        /// <exception cref="OktaException">The enum type could not be created.</exception>
        protected TEnum GetEnumProperty<TEnum>(string name)
            where TEnum : StringEnum
            => GetEnumPropertyInternal<TEnum>(name);

        private TEnum GetEnumPropertyInternal<TEnum>(string name)
        {
            var raw = GetStringProperty(name);
            if (raw == null)
            {
                return default(TEnum); // null
            }

            try
            {
                return (TEnum)Activator.CreateInstance(typeof(TEnum), raw);
            }
            catch (Exception ex)
            {
                throw new OktaException($"Could not create an enum of type {typeof(TEnum).Name}. See the inner exception for details.", ex);
            }
        }

        /// <summary>
        /// Gets an embedded resource property by name.
        /// </summary>
        /// <typeparam name="T">The type of the embedded resource.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>The embedded resource, or <c>null</c>.</returns>
        protected T GetResourceProperty<T>(string name)
            where T : Resource, new()
            => GetResourcePropertyInternal<T>(name);

        private T GetResourcePropertyInternal<T>(string key)
        {
            var nestedData = GetPropertyOrNull(key) as IDictionary<string, object>;
            return _resourceFactory.CreateFromExistingData<T>(nestedData);
        }
    }
}
