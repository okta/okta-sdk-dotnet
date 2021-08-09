// <copyright file="ILinkedObjectsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta LinkedObject resources.</summary>
    public partial interface ILinkedObjectsClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <returns>A collection of <see cref="ILinkedObject"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ILinkedObject> ListLinkedObjectDefinitions();

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="linkedObject">The <see cref="ILinkedObject"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ILinkedObject"/> response.</returns>
        Task<ILinkedObject> AddLinkedObjectDefinitionAsync(ILinkedObject linkedObject, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="linkedObjectName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ILinkedObject"/> response.</returns>
        Task<ILinkedObject> GetLinkedObjectDefinitionAsync(string linkedObjectName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="linkedObjectName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteLinkedObjectDefinitionAsync(string linkedObjectName, CancellationToken cancellationToken = default(CancellationToken));

    }
}
