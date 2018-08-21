// <copyright file="CollectionPage{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents a page of resources in an Okta API collection.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.</remarks>
    /// <typeparam name="T">The resource type of this collection.</typeparam>
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
        public HttpResponse<IEnumerable<T>> Response { get; set; }

        /// <summary>
        /// Gets or sets the link to get the next page of results, if any.
        /// </summary>
        /// <value>
        /// The link to get the next page of results. If there is no next page, this will be <c>null</c>.
        /// </value>
        public WebLink NextLink { get; set; }
    }
}
