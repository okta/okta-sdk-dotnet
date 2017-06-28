// <copyright file="IUserClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IUserClient
    {
        /// <summary>
        /// Creates a new user in your Okta organization with the specified password.
        /// </summary>
        /// <param name="createUserOptions">The options for this Create User request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created user.</returns>
        Task<User> CreateUserAsync(CreateUserWithPasswordOptions createUserOptions, CancellationToken cancellationToken = default(CancellationToken));
    }
}
