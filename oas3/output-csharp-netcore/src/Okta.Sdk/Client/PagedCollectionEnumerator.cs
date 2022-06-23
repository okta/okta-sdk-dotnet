using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk.Client
{
    public class PagedCollectionEnumerator<T>
    {
        private readonly ApiResponse<List<T>> _currentApiResponse;
        private RequestOptions _nextRequest;
        private IAsynchronousClient _client;
        private string _nextPath;
        private readonly CancellationToken _cancellationToken;
        private readonly IReadableConfiguration _configuration;

        public PagedCollectionEnumerator(ApiResponse<List<T>> currentResponse, IAsynchronousClient client, IReadableConfiguration configuration, CancellationToken cancellationToken = default)
        {
            _currentApiResponse = currentResponse;
            _client = client;
            _cancellationToken = cancellationToken;
            _nextPath = GetNextLink(currentResponse).Target;
            _configuration = configuration;
            _nextRequest = new RequestOptions();

            _nextRequest = new Okta.Sdk.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Okta.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                _nextRequest.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Okta.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                _nextRequest.HeaderParameters.Add("Accept", localVarAccept);
            }

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(_configuration.GetApiKeyWithPrefix("Authorization")))
            {
                _nextRequest.HeaderParameters.Add("Authorization", _configuration.GetApiKeyWithPrefix("Authorization"));
            }
            // authentication (OAuth_2.0) required
            // oauth required
            if (!string.IsNullOrEmpty(_configuration.AccessToken) && !_nextRequest.HeaderParameters.ContainsKey("Authorization"))
            {
                _nextRequest.HeaderParameters.Add("Authorization", "Bearer " + _configuration.AccessToken);
            }
        }
        private static WebLink GetNextLink(ApiResponse<List<T>> response)
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

        public CollectionPage<T> CurrentPage { get; private set; }

        public async Task<bool> MoveNextAsync()
        {
            if (string.IsNullOrEmpty(_nextPath))
            {
                return false;
            }

            var response = await _client.GetAsync<List<T>>(_nextPath, _nextRequest, null, _cancellationToken).ConfigureAwait(false);


            var items = response?.Data ?? new List<T>();

            CurrentPage = new CollectionPage<T>
            {
                Items = items,
                Response = response,
                NextLink = GetNextLink(response)
            };

            _nextPath = null;
            if (!string.IsNullOrEmpty(CurrentPage.NextLink?.Target))
            {
                _nextPath = CurrentPage.NextLink.Target;
            }

            return true;
        }
    }

    public class CollectionPage<T>
    {
        /// <summary>
        /// Gets or sets the items in this page.
        /// </summary>
        /// <value>
        /// The items in this page.
        /// </value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response returned from the Okta API when fetching this page.
        /// </summary>
        /// <value>
        /// The HTTP response returned from the Okta API when fetching this page.
        /// </value>
        public ApiResponse<List<T>> Response { get; set; }

        /// <summary>
        /// Gets or sets the link to get the next page of results, if any.
        /// </summary>
        /// <value>
        /// The link to get the next page of results. If there is no next page, this will be <c>null</c>.
        /// </value>
        public WebLink NextLink { get; set; }
    }
}
