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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IUserSchemasClient
    {
        /// <summary>
        /// Fetches the Schema for an App User Fetches the Schema for an App User
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appInstanceId"></param>
        ///  <returns>Task of IUserSchema</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserSchema> GetApplicationUserSchemaAsync(string appInstanceId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Fetches the schema for a Schema Id. Fetches the schema for a Schema Id.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="schemaId"></param>
        ///  <returns>Task of IUserSchema</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserSchema> GetUserSchemaAsync(string schemaId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Partial updates on the User Profile properties of the Application User Schema. Partial updates on the User Profile properties of the Application User Schema.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appInstanceId"></param>
        /// <param name="body"> (optional)</param>
        ///  <returns>Task of IUserSchema</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserSchema> UpdateApplicationUserProfileAsync(string appInstanceId, IUserSchema body = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Partial updates on the User Profile properties of the user schema.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="schemaId"></param>
        ///  <returns>Task of IUserSchema</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserSchema> UpdateUserProfileAsync(IUserSchema body, string schemaId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

