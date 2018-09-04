// <copyright file="ICollectionClient{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

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
    public interface ICollectionClient<T> : IAsyncEnumerable<T>
        where T : IResource
    {
        /// <summary>
        /// Returns an enumerator that can be used to retrieve items from an Okta collection page-by-page.
        /// Use this only if you need to enumerate collections manually; otherwise, use LINQ.
        /// </summary>
        /// <remarks>
        /// /// See <a href="https://developer.okta.com/docs/api/getting_started/design_principles.html#pagination">the API documentation on pagination</a>.
        /// </remarks>
        /// <returns>An enumerator that retrieves items from an Okta collection page-by-page.</returns>
        IPagedCollectionEnumerator<T> GetPagedEnumerator();
    }
}
