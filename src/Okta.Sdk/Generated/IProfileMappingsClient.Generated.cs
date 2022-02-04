// <copyright file="IProfileMappingsClient.Generated.cs" company="Okta, Inc">
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
    public partial interface IProfileMappingsClient
    {
        /// <summary>
        /// Get Profile Mapping Fetches a single Profile Mapping referenced by its ID.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="mappingId"></param>
        ///  <returns>Task of IProfileMapping</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IProfileMapping> GetProfileMappingAsync(string mappingId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Enumerates Profile Mappings in your organization with pagination.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to -1)</param>
        /// <param name="sourceId"> (optional)</param>
        /// <param name="targetId"> (optional)</param>
        /// A collection of <see cref="IProfileMappingsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IProfileMapping> ListProfileMappings(string after = null, int? limit = null, string sourceId = null, string targetId = null);
        /// <summary>
        /// Update Profile Mapping Updates an existing Profile Mapping by adding, updating, or removing one or many Property Mappings.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="mappingId"></param>
        ///  <returns>Task of IProfileMapping</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IProfileMapping> UpdateProfileMappingAsync(IProfileMapping body, string mappingId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

