// <copyright file="PagedCollectionActionManager.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Enumerates an Okta API collection using the defined paging contract.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.</remarks>
    public static class PagedCollectionActionManager
    {
        /// <summary>
        /// Lists the users asynchronous.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="dataStore">The data store.</param>
        /// <param name="request">The request.</param>
        /// <param name="context">The context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// list of type {T}
        /// </returns>
        public static async Task<PageOfResults<T>> GetPageOfResultsAsync<T>(
            IDataStore dataStore,
            HttpRequest request,
            RequestContext context,
            CancellationToken cancellationToken)
            where T : Resource, new()
        {
            var currentPage = await dataStore.GetArrayAsync<T>(
                request,
                context,
                cancellationToken).ConfigureAwait(false);

            var nextRequest = GetNextLink(currentPage);

            string serializedNextRequest = JsonConvert.SerializeObject(nextRequest);
            return new PageOfResults<T>()
            {
                Results = currentPage.Payload,
                ContinuationToken = serializedNextRequest,
            };
        }

        private static HttpRequest GetNextLink(HttpResponse response)
        {
            var linkHeaders = response
                .Headers
                .Where(kvp => kvp.Key.Equals("Link", StringComparison.OrdinalIgnoreCase))
                .Select(kvp => kvp.Value);
            var nextUri = LinkHeaderParser
                .Parse(linkHeaders.SelectMany(x => x))
                .Where(x => x.Relation == "next")
                .SingleOrDefault()
                .Target;
            return string.IsNullOrEmpty(nextUri)
                ? null
                : new HttpRequest { Uri = nextUri };
        }
    }
}
