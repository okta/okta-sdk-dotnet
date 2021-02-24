// <copyright file="IOktasClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta Okta resources.</summary>
    public partial interface IOktasClient
    {
        /// <summary>
        /// Partial updates on the User Profile properties of the Application User Schema.
        /// </summary>
        /// <param name="body">The <see cref="IUserSchema"/> resource.</param>
        /// <param name="appInstanceId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserSchema"/> response.</returns>
        Task<IUserSchema> UpdateApplicationUserProfileAsync(IUserSchema body, string appInstanceId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
