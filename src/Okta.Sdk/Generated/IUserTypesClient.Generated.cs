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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IUserTypesClient
    {
        /// <summary>
        ///  Creates a new User Type. A default User Type is automatically created along with your org, and you may add another 9 User Types for a maximum of 10.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IUserType</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserType> CreateUserTypeAsync(IUserType body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deletes a User Type permanently. This operation is not permitted for the default type, nor for any User Type that has existing users
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="typeId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteUserTypeAsync(string typeId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Fetches a User Type by ID. The special identifier &#x60;default&#x60; may be used to fetch the default User Type.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="typeId"></param>
        ///  <returns>Task of IUserType</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserType> GetUserTypeAsync(string typeId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Fetches all User Types in your org
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// A collection of <see cref="IUserTypesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IUserType> ListUserTypes();
        /// <summary>
        ///  Replace an existing User Type
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="typeId"></param>
        ///  <returns>Task of IUserType</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserType> ReplaceUserTypeAsync(IUserType body, string typeId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Updates an existing User Type
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="typeId"></param>
        ///  <returns>Task of IUserType</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserType> UpdateUserTypeAsync(IUserType body, string typeId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

