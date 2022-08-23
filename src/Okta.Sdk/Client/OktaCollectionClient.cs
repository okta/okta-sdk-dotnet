﻿/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// A collection of Okta resources that can be enumerated asynchronously.
    /// </summary>
    /// <remarks>
    /// Using this object with LINQ will automatically enumerate a paginated Okta collection.
    /// See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.
    /// </remarks>
    /// <typeparam name="T">The resource's type in the collection.</typeparam>
    public interface IOktaCollectionClient<T> : IAsyncEnumerable<T>
    {
        /// <summary>
        /// Returns an enumerator that can be used to retrieve items from an Okta collection page-by-page.
        /// Use this only if you need to enumerate collections manually; otherwise, use LINQ.
        /// </summary>
        /// <remarks>
        /// /// See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.
        /// </remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An enumerator that retrieves items from an Okta collection page-by-page.</returns>
        IOktaPagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default);
    }

    /// <inheritdoc/>
    public class OktaCollectionClient<T> : IOktaCollectionClient<T>
    {
        private RequestOptions _initialRequest;
        private string _initialPath;
        private IAsynchronousClient _client;
        private IReadableConfiguration _configuration;
        private IOAuthTokenProvider _oAuthTokenProvider;
        
        public OktaCollectionClient(RequestOptions initialRequest, string initialPath, IAsynchronousClient client, IReadableConfiguration configuration = null, IOAuthTokenProvider oAuthTokenProvider = null)
        {
            _initialRequest = initialRequest;
            _client = client;
            _initialPath = initialPath;
            _configuration = configuration ?? Configuration.GetConfigurationOrDefault();
            _oAuthTokenProvider = oAuthTokenProvider;
        }
        
        /// <inheritdoc/>
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new OktaCollectionAsyncEnumerator<T>(_initialRequest, _initialPath, _client, cancellationToken, _configuration, _oAuthTokenProvider);
        
        /// <inheritdoc/>
        public IOktaPagedCollectionEnumerator<T> GetPagedEnumerator(CancellationToken cancellationToken = default)
            => new OktaPagedCollectionEnumerator<T>(_initialRequest, _initialPath, _client, cancellationToken, _configuration, _oAuthTokenProvider);
    }
}
