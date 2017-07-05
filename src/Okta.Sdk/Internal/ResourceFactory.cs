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
    /// <summary>
    /// Constructs <see cref="Resource"/>s based on deserialized dictionaries.
    /// </summary>
    public sealed class ResourceFactory
    {
        private static readonly TypeInfo ResourceTypeInfo = typeof(Resource).GetTypeInfo();

        private readonly IOktaClient _client;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceFactory"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="logger">The logging interface.</param>
        public ResourceFactory(IOktaClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new dictionary with the specified behavior.
        /// </summary>
        /// <param name="behaviorType">The resource behavior type.</param>
        /// <param name="existingData">The initial dictionary data.</param>
        /// <returns>A new dictionary with the specified behavior.</returns>
        public IDictionary<string, object> NewDictionary(ResourceBehavior behaviorType, IDictionary<string, object> existingData)
        {
            var initialData = existingData ?? new Dictionary<string, object>();

            switch (behaviorType)
            {
                case ResourceBehavior.Default: return new Dictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase);
                case ResourceBehavior.ChangeTracking: return new DefaultChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase);
            }

            throw new ArgumentException($"Unknown resource dictionary type {behaviorType}");
        }

        /// <summary>
        /// Creates a new <see cref="Resource"/> from an existing dictionary.
        /// </summary>
        /// <typeparam name="T">The <see cref="Resource"/> type.</typeparam>
        /// <param name="existingDictionary">The existing dictionary.</param>
        /// <returns>The created <see cref="Resource"/>.</returns>
        public T CreateFromExistingData<T>(IDictionary<string, object> existingDictionary)
        {
            if (!ResourceTypeInfo.IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new InvalidOperationException("Resources must inherit from the Resource class.");
            }

            var resource = Activator.CreateInstance<T>() as Resource;
            resource.Initialize(_client, this, existingDictionary, _logger);
            return (T)(object)resource;
        }

        /// <summary>
        /// Creates a new <see cref="Resource"/> with the specified data.
        /// </summary>
        /// <typeparam name="T">The <see cref="Resource"/> type.</typeparam>
        /// <param name="data">The initial data.</param>
        /// <returns>The created <see cref="Resource"/>.</returns>
        public T CreateNew<T>(IDictionary<string, object> data)
        {
            if (!ResourceTypeInfo.IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new InvalidOperationException("Resources must inherit from the Resource class.");
            }

            var resource = Activator.CreateInstance<T>() as Resource;
            var dictionary = NewDictionary(resource.DictionaryType, data);
            resource.Initialize(_client, this, dictionary, _logger);
            return (T)(object)resource;
        }
    }
}
