﻿/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 5.1.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk.Client
{
    public interface IOktaPagedCollectionEnumerator<T>
    {
        /// <summary>
        /// Gets the current page of items, or <c>null</c> if <see cref="MoveNextAsync()"/> has not yet been called.
        /// </summary>
        /// <value>
        /// The current page of items, if any.
        /// </value>
        OktaCollectionPage<T> CurrentPage { get; }

        /// <summary>
        /// Asynchronously retrieves the next page of results and updates <see cref="CurrentPage"/>. If there are no more pages, this method returns <see langword="false"/>.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if <see cref="CurrentPage"/> has been updated with new items, <see langword="false"/> if the collection has been exhausted.
        /// </returns>
        Task<bool> MoveNextAsync();
    }
    
    /// <inheritdoc/>
    public class OktaPagedCollectionEnumerator<T> : IOktaPagedCollectionEnumerator<T>
    {
        private RequestOptions _nextRequest;
        private IAsynchronousClient _client;
        private string _nextPath;
        private readonly CancellationToken _cancellationToken;
        private readonly IReadableConfiguration _configuration;
        private readonly IOAuthTokenProvider _oAuthTokenProvider;
        private Okta.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Okta.Sdk.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        public OktaPagedCollectionEnumerator(RequestOptions initialRequest, string path, IAsynchronousClient client, IReadableConfiguration configuration, IOAuthTokenProvider oAuthTokenProvider, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "Path cannot be null or empty");
            }

            _nextRequest = initialRequest ?? throw new ArgumentNullException(nameof(initialRequest));
            _nextPath = path;
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _cancellationToken = cancellationToken;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _oAuthTokenProvider = oAuthTokenProvider ?? throw new ArgumentNullException(nameof(oAuthTokenProvider));
            ExceptionFactory = Okta.Sdk.Client.Configuration.DefaultExceptionFactory;
        }
        
        private WebLink GetNextLink(ApiResponse<IEnumerable<T>> response)
        {
            if (response?.Headers == null)
            {
                return null;
            }

            var linkHeaders = response
                .Headers
                .Where(kvp => kvp.Key.Equals("Link", StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Value);

            var nextLink = ClientUtils
                .Parse(linkHeaders.SelectMany(x => x))
                .Where(x => x.Relation == "next")
                .FirstOrDefault();

            return nextLink;
        }
        
        /// <inheritdoc/>
        public OktaCollectionPage<T> CurrentPage { get; private set; }

        /// <inheritdoc/>
        public async Task<bool> MoveNextAsync()
        {
            if (_nextPath == null)
            {
                return false;
            }
            
            if (Okta.Sdk.Client.Configuration.IsPrivateKeyMode(_configuration))
            {
                var accessToken = await _oAuthTokenProvider.GetAccessTokenAsync(cancellationToken: _cancellationToken);
                _nextRequest.HeaderParameters.Remove("Authorization");
                _nextRequest.HeaderParameters.Add("Authorization", $"Bearer {accessToken}");
            }
            
            var response = await _client.GetAsync<IEnumerable<T>>(_nextPath, _nextRequest, _configuration, _cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("OktaPagedCollectionEnumerator", response);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            var items = response?.Data ?? Array.Empty<T>();

            CurrentPage = new OktaCollectionPage<T>
            {
                Items = items,
                Response = response,
                NextLink = GetNextLink(response)
            };

            _nextPath = null;
            if (!string.IsNullOrEmpty(CurrentPage.NextLink?.Target))
            {
                _nextPath = CurrentPage.NextLink.Target;
                _nextRequest = new RequestOptions
                {
                    HeaderParameters = _nextRequest.HeaderParameters, 
                    PathParameters = _nextRequest.PathParameters
                };
            }

            return true;
        }
    }
}
