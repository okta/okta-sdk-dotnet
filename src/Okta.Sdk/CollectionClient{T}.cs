﻿// <copyright file="CollectionClient{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>
    /// A remote collection of <see cref="Resource">Resources</see> that can be enumerated asynchronously.
    /// </summary>
    /// <typeparam name="T">The <see cref="Resource"/> type in the collection.</typeparam>
    public sealed class CollectionClient<T> : IAsyncEnumerable<T>
        where T : Resource, new()
    {
        private readonly IDataStore _dataStore;
        private readonly HttpRequest _initialRequest;
        private readonly RequestContext _requestContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionClient{T}"/> class.
        /// </summary>
        /// <param name="dataStore">The <see cref="IDataStore">DataStore</see>.</param>
        /// <param name="initialRequest">The initial HTTP request options.</param>
        /// <param name="requestContext">The request context.</param>
        public CollectionClient(
            IDataStore dataStore,
            HttpRequest initialRequest,
            RequestContext requestContext)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _initialRequest = initialRequest ?? throw new ArgumentNullException(nameof(initialRequest));
            _requestContext = requestContext;
        }

        /// <inheritdoc/>
        public IAsyncEnumerator<T> GetEnumerator()
            => new CollectionAsyncEnumerator<T>(_dataStore, _initialRequest, _requestContext);
    }
}
