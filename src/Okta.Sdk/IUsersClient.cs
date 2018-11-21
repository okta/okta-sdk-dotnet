// <copyright file="IUsersClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta User resources.</summary>
    public partial interface IUsersClient : IAsyncEnumerable<IUser>
    {
        /// <summary>
        /// Creates a new user in your Okta organization without a password or a recovery question/answer.
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/api/resources/users.html#create-user-without-credentials">Create User without Credentials</a> in the documentation.</remarks>
        /// <param name="options">The options for this Create User (without credentials) request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created user.</returns>
        Task<IUser> CreateUserAsync(CreateUserWithoutCredentialsOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new user in your Okta organization with a recovery question/answer (but no password).
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/api/resources/users.html#create-user-with-recovery-question">Create User with Recovery Question</a> in the documentation.</remarks>
        /// <param name="options">The options for this Create User (with recovery question) request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created user.</returns>
        Task<IUser> CreateUserAsync(CreateUserWithRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new user in your Okta organization with the specified password.
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/api/resources/users.html#create-user-with-password">Create User with Password</a> in the documentation.</remarks>
        /// <param name="options">The options for this Create User (with password) request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created user.</returns>
        Task<IUser> CreateUserAsync(CreateUserWithPasswordOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new user in your Okta organization with the specified authentication provider.
        /// </summary>
        /// <remarks>See <a href="https://developer.okta.com/docs/api/resources/users.html#create-user-with-authentication-provider">Create User with Authentication Provider</a> in the documentation.</remarks>
        /// <param name="options">The options for this Create User (with authentication provider) request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created user.</returns>
        Task<IUser> CreateUserAsync(CreateUserWithProviderOptions options, CancellationToken cancellationToken = default(CancellationToken));

        // TODO add groupIds options to all of the above?

        /// <summary>
        /// Changes a user's password.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="options">The options for this Change Password request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="UserCredentials"/> response.</returns>
        Task<IUserCredentials> ChangePasswordAsync(string userId, ChangePasswordOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes a user's recovery question.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="options">The options for this Change Recovery Question request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserCredentials"/> response.</returns>
        Task ChangeRecoveryQuestionAsync(string userId, ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Resets a user's password.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="sendEmail">Sends reset password email to the user if <c>true</c>.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IResetPasswordToken"/> response.</returns>
        Task<IResetPasswordToken> ResetPasswordAsync(string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a user permanently. This operation can only be performed on users that have a &#x60;DEPROVISIONED&#x60; status.  **This action cannot be recovered!**
        /// </summary>
        /// <param name="userId">The User ID</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        /// <remarks>Explicit overload to support backward compatibility.</remarks>
        Task DeactivateOrDeleteUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a user permanently. This operation can only be performed on users that have a &#x60;DEPROVISIONED&#x60; status.  **This action cannot be recovered!**
        /// </summary>
        /// <param name="userId">The User ID</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        /// <remarks>Explicit overload to support backward compatibility.</remarks>
        Task DeactivateOrDeleteUserAsync(string userId);
    }
}
