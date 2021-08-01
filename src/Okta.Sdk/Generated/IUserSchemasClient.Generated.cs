// <copyright file="IUserSchemasClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta UserSchema resources.</summary>
    public partial interface IUserSchemasClient
    {
        /// <summary>
        /// Fetches the Schema for an App User
        /// </summary>
        /// <param name="appInstanceId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserSchema"/> response.</returns>
        Task<IUserSchema> GetApplicationUserSchemaAsync(string appInstanceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Partial updates on the User Profile properties of the Application User Schema.
        /// </summary>
        /// <param name="userSchema">The <see cref="IUserSchema"/> resource.</param>
        /// <param name="appInstanceId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserSchema"/> response.</returns>
        Task<IUserSchema> UpdateApplicationUserProfileAsync(IUserSchema userSchema, string appInstanceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches the schema for a Schema Id.
        /// </summary>
        /// <param name="schemaId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserSchema"/> response.</returns>
        Task<IUserSchema> GetUserSchemaAsync(string schemaId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Partial updates on the User Profile properties of the user schema.
        /// </summary>
        /// <param name="userSchema">The <see cref="IUserSchema"/> resource.</param>
        /// <param name="schemaId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserSchema"/> response.</returns>
        Task<IUserSchema> UpdateUserProfileAsync(IUserSchema userSchema, string schemaId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
