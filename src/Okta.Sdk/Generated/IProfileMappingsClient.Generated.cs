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
    /// <summary>A client that works with Okta ProfileMapping resources.</summary>
    public partial interface IProfileMappingsClient
    {
        /// <summary>
        /// Enumerates Profile Mappings in your organization with pagination.
        /// </summary>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <param name="sourceId"></param>
        /// <param name="targetId"></param>
        /// <returns>A collection of <see cref="IProfileMapping"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IProfileMapping> ListProfileMappings(string after = null, int? limit = -1, string sourceId = null, string targetId = "");

        /// <summary>
        /// Fetches a single Profile Mapping referenced by its ID.
        /// </summary>
        /// <param name="mappingId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IProfileMapping"/> response.</returns>
        Task<IProfileMapping> GetProfileMappingAsync(string mappingId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an existing Profile Mapping by adding, updating, or removing one or many Property Mappings.
        /// </summary>
        /// <param name="profileMapping">The <see cref="IProfileMapping"/> resource.</param>
        /// <param name="mappingId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IProfileMapping"/> response.</returns>
        Task<IProfileMapping> UpdateProfileMappingAsync(IProfileMapping profileMapping, string mappingId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
