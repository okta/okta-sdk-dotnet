// <copyright file="IUser.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a User resource in the Okta API.</summary>
    public partial interface IUser
    {
        IAsyncEnumerable<IAppLink> AppLinks { get; }

        IAsyncEnumerable<IRole> Roles { get; }

        IAsyncEnumerable<IGroup> Groups { get; }

        IAsyncEnumerable<IFactor> Factors { get; }

        Task<IUserCredentials> ChangePasswordAsync(ChangePasswordOptions options, CancellationToken cancellationToken = default(CancellationToken));

        Task<IResetPasswordToken> ResetPasswordAsync(bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateOrDeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task ChangeRecoveryQuestionAsync(ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken));

        Task RemoveFromGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Saves changes and returns the updated resource.
        /// </summary>
        /// <remarks>Alias of <see cref="IUsersClient.UpdateUserAsync(IUser, string, CancellationToken)"/>.</remarks>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated <see cref="IUser">User</see>.</returns>
        Task<IUser> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<IFactor> AddFactorAsync(AddSecurityQuestionFactorOptions securityQuestionFactorOptions, CancellationToken cancellationToken = default(CancellationToken));
    }
}
