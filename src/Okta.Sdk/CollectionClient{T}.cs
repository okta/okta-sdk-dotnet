// <copyright file="CollectionClient{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>
    /// A collection of <see cref="Resource">Resources</see> that can be enumerated asynchronously.
    /// </summary>
    /// <remarks>
    /// Using this object with LINQ will automatically enumerate a paginated Okta collection.
    /// See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.
    /// </remarks>
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

        /// <summary>
        /// Returns an enumerator that can be used to retrieve items from an Okta collection page-by-page.
        /// Use this only if you need to enumerate collections manually; otherwise, use LINQ.
        /// </summary>
        /// <remarks>
        /// /// See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.
        /// </remarks>
        /// <returns>An enumerator that retrieves items from an Okta collection page-by-page.</returns>
        public PagedCollectionEnumerator<T> GetPagedEnumerator()
            => new PagedCollectionEnumerator<T>(_dataStore, _initialRequest, _requestContext);
    }
}
