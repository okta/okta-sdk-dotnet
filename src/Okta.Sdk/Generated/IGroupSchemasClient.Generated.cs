// <copyright file="IGroupSchemasClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta GroupSchema resources.</summary>
    public partial interface IGroupSchemasClient
    {
        /// <summary>
        /// Fetches the group schema
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupSchema"/> response.</returns>
        Task<IGroupSchema> GetGroupSchemaAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates, adds ore removes one or more custom Group Profile properties in the schema
        /// </summary>
        /// <param name="body">The <see cref="IGroupSchema"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IGroupSchema"/> response.</returns>
        Task<IGroupSchema> UpdateGroupSchemaAsync(IGroupSchema body, CancellationToken cancellationToken = default(CancellationToken));

    }
}
