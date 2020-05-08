// <copyright file="IUserTypesClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta UserType resources.</summary>
    public partial interface IUserTypesClient
    {
        /// <summary>
        /// Fetches all User Types in your org
        /// </summary>
        /// <returns>A collection of <see cref="IUserType"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IUserType> ListUserTypes();

        /// <summary>
        /// Creates a new User Type. A default User Type is automatically created along with your org, and you may add another 9 User Types for a maximum of 10.
        /// </summary>
        /// <param name="userType">The <see cref="IUserType"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserType"/> response.</returns>
        Task<IUserType> CreateUserTypeAsync(IUserType userType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a User Type permanently. This operation is not permitted for the default type, nor for any User Type that has existing users
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteUserTypeAsync(string typeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a User Type by ID. The special identifier `default` may be used to fetch the default User Type.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserType"/> response.</returns>
        Task<IUserType> GetUserTypeAsync(string typeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an existing User Type
        /// </summary>
        /// <param name="userType">The <see cref="IUserType"/> resource.</param>
        /// <param name="typeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserType"/> response.</returns>
        Task<IUserType> UpdateUserTypeAsync(IUserType userType, string typeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Replace an existing User Type
        /// </summary>
        /// <param name="userType">The <see cref="IUserType"/> resource.</param>
        /// <param name="typeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserType"/> response.</returns>
        Task<IUserType> ReplaceUserTypeAsync(IUserType userType, string typeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
