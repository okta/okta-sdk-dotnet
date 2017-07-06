// <copyright file="IUsersClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IUsersClient : IAsyncEnumerable<IUser>
    {
        /// <summary>
        /// Creates a new user in your Okta organization with the specified password.
        /// </summary>
        /// <param name="options">The options for this Create User (with password) request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created user.</returns>
        Task<IUser> CreateUserAsync(CreateUserWithPasswordOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes a user's password.
        /// </summary>
        /// <param name="userId">The User ID.</param>
        /// <param name="options">The options for this Change Password request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="UserCredentials"/> response.</returns>
        Task<IUserCredentials> ChangePasswordAsync(string userId, ChangePasswordOptions options, CancellationToken cancellationToken = default(CancellationToken));

        Task ChangeRecoveryQuestionAsync(string userId, ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Resets a user's password.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="sendEmail">Sends reset password email to the user if <c>true</c>.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ResetPasswordToken"/> response.</returns>
        Task<IResetPasswordToken> ResetPasswordAsync(string userId,  bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
