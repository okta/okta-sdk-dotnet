// <copyright file="ResourceFactory.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Okta.Sdk.Internal
{
    public sealed class ResourceFactory
    {
        private static readonly TypeInfo ResourceTypeInfo = typeof(Resource).GetTypeInfo();

        private readonly IDataStore _dataStore;
        private readonly ILogger _logger;

        public ResourceFactory(IDataStore dataStore = null, ILogger logger = null)
        {
            _dataStore = dataStore;
            _logger = logger ?? NullLogger.Instance;
        }

        public IDictionary<string, object> NewDictionary(ResourceDictionaryType type, IDictionary<string, object> existingData)
        {
            var initialData = existingData ?? new Dictionary<string, object>();

            switch (type)
            {
                case ResourceDictionaryType.Default: return new Dictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase);
                case ResourceDictionaryType.ChangeTracking: return new DefaultChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase);
            }

            throw new ArgumentException($"Unknown resource dictionary type {type}");
        }

        public T CreateFromExistingData<T>(IDictionary<string, object> data)
        {
            if (!ResourceTypeInfo.IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new InvalidOperationException("Resources must inherit from the Resource class.");
            }

            var resource = Activator.CreateInstance<T>() as Resource;
            resource.Initialize(_dataStore, this, data, _logger);
            return (T)(object)resource;
        }

        public T CreateNew<T>(IDictionary<string, object> data)
        {
            if (!ResourceTypeInfo.IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new InvalidOperationException("Resources must inherit from the Resource class.");
            }

            var resource = Activator.CreateInstance<T>() as Resource;
            var dictionary = NewDictionary(resource.DictionaryType, data);
            resource.Initialize(_dataStore, this, dictionary, _logger);
            return (T)(object)resource;
        }
    }
}
