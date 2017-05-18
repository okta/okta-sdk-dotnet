// <copyright file="ResourceFactory.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public sealed class ResourceFactory
    {
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
            where T : Resource, new()
        {
            var resource = new T();
            resource.Initialize(data);
            return resource;
        }

        public T CreateNew<T>(IDictionary<string, object> data)
            where T : Resource, new()
        {
            var resource = new T();
            var dictionary = NewDictionary(resource.DictionaryType, data);
            resource.Initialize(dictionary);
            return resource;
        }
    }
}
