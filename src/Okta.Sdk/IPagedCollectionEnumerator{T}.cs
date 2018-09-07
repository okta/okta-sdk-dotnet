// <copyright file="IPagedCollectionEnumerator{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>
    /// Enumerates an Okta collection by retrieving pages of results.
    /// </summary>
    /// <remarks>See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.</remarks>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public interface IPagedCollectionEnumerator<T>
        where T : IResource
    {
        /// <summary>
        /// Gets the current page of items, or <c>null</c> if <see cref="MoveNextAsync(CancellationToken)"/> has not yet been called.
        /// </summary>
        /// <value>
        /// The current page of items, if any.
        /// </value>
        CollectionPage<T> CurrentPage { get; }

        /// <summary>
        /// Asynchronously retrieves the next page of results and updates <see cref="CurrentPage"/>. If there are no more pages, this method returns <see langword="false"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// <see langword="true"/> if <see cref="CurrentPage"/> has been updated with new items, <see langword="false"/> if the collection has been exhausted.
        /// </returns>
        Task<bool> MoveNextAsync(CancellationToken cancellationToken = default);
    }
}
