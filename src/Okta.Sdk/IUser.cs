// <copyright file="IUser.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a User resource in the Okta API.</summary>
    public partial interface IUser
    {
        /// <summary>
        /// Gets a collection of <see cref="IAppLink"/> that can be enumerated asynchronously
        /// </summary>
        IAsyncEnumerable<IAppLink> AppLinks { get; }

        /// <summary>
        /// Gets a collection of <see cref="IRole"/> that can be enumerated asynchronously
        /// </summary>
        IAsyncEnumerable<IRole> Roles { get; }

        /// <summary>
        /// Gets a collection of <see cref="IGroup"/> that can be enumerated asynchronously
        /// </summary>
        IAsyncEnumerable<IGroup> Groups { get; }

        /// <summary>
        /// Gets a collection of <see cref="IFactor"/> that can be enumerated asynchronously
        /// </summary>
        IAsyncEnumerable<IFactor> Factors { get; }

        /// <summary>
        /// Changes the user password
        /// </summary>
        /// <param name="options">The password options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserCredentials"/> response</returns>
        Task<IUserCredentials> ChangePasswordAsync(ChangePasswordOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Resets the user password
        /// </summary>
        /// <param name="sendEmail">The send email flag</param>
        /// <param name="cancellationToken">The cancellation token </param>
        /// <returns>The <see cref="IResetPasswordToken"/> response</returns>
        Task<IResetPasswordToken> ResetPasswordAsync(bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a deactivated user
        /// </summary>
        /// <param name="sendEmail">The send email flag</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The asynchronous task</returns>
        Task DeactivateOrDeleteAsync(bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Changes the user recovery question
        /// </summary>
        /// <param name="options">The recovery question options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The asynchronous task</returns>
        Task ChangeRecoveryQuestionAsync(ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes a user from a group
        /// </summary>
        /// <param name="groupId">The group id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The asynchronous task</returns>
        Task RemoveFromGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Saves changes and returns the updated resource.
        /// </summary>
        /// <remarks>Alias of <see cref="IUsersClient.UpdateUserAsync(IUser, string, CancellationToken)"/>.</remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated <see cref="IUser">User</see>.</returns>
        Task<IUser> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a security question factor to the user
        /// </summary>
        /// <param name="securityQuestionFactorOptions">The security question options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddSecurityQuestionFactorOptions securityQuestionFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a call factor to the user
        /// </summary>
        /// <param name="callFactorOptions">The call factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddCallFactorOptions callFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds an email factor to the user
        /// </summary>
        /// <param name="emailFactorOptions">The email factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddEmailFactorOptions emailFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a hardward factor to the user
        /// </summary>
        /// <param name="hardwareFactorOptions">The hardware factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddHardwareFactorOptions hardwareFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a push factor to the user
        /// </summary>
        /// <param name="pushFactorOptions">The push factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddPushFactorOptions pushFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds an SMS factor to the user
        /// </summary>
        /// <param name="smsFactorOptions">The SMS factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddSmsFactorOptions smsFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a token factor to the user
        /// </summary>
        /// <param name="tokenFactorOptions">The token factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddTokenFactorOptions tokenFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a token:software:totp factor to the user
        /// </summary>
        /// <param name="totpFactorOptions">The token:software:totp options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IFactor"/> response</returns>
        Task<IFactor> AddFactorAsync(AddTotpFactorOptions totpFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a user
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The asynchronous task</returns>
        /// <remarks>Explicit overload to support backward compatibility.</remarks>
        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates a user.
        /// </summary>
        /// <returns>The asynchronous task</returns>
        /// <remarks>Explicit overload to support backward compatibility.</remarks>
        Task DeactivateAsync();
    }
}
