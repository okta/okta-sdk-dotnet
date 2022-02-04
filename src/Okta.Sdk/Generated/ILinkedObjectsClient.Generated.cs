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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface ILinkedObjectsClient
    {
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of ILinkedObject</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ILinkedObject> AddLinkedObjectDefinitionAsync(ILinkedObject body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="linkedObjectName"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteLinkedObjectDefinitionAsync(string linkedObjectName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="linkedObjectName"></param>
        ///  <returns>Task of ILinkedObject</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ILinkedObject> GetLinkedObjectDefinitionAsync(string linkedObjectName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// A collection of <see cref="ILinkedObjectsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ILinkedObject> ListLinkedObjectDefinitions();
    }
}

