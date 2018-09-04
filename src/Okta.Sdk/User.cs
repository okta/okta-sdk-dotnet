// <copyright file="User.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents a User resource in the Okta API.
    /// </summary>
    public sealed partial class User : IUser
    {
        /// <inheritdoc/>
        public IAsyncEnumerable<IAppLink> AppLinks
            => GetClient().Users.ListAppLinks(Id);

        /// <inheritdoc/>
        public IAsyncEnumerable<IRole> Roles
            => GetClient().Users.ListAssignedRoles(Id);

        /// <inheritdoc/>
        public IAsyncEnumerable<IGroup> Groups
            => GetClient().Users.ListUserGroups(Id);

        /// <inheritdoc/>
        public IAsyncEnumerable<IFactor> Factors
            => GetClient().UserFactors.ListFactors(Id);

        /// <inheritdoc/>
        public Task<IUserCredentials> ChangePasswordAsync(ChangePasswordOptions options, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ChangePasswordAsync(Id, options, cancellationToken);

        /// <inheritdoc />
        public Task<IResetPasswordToken> ResetPasswordAsync(bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ResetPasswordAsync(Id, sendEmail, cancellationToken);

        /// <inheritdoc/>
        public Task DeactivateOrDeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.DeactivateOrDeleteUserAsync(Id, cancellationToken);

        /// <inheritdoc/>
        public Task ChangeRecoveryQuestionAsync(ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ChangeRecoveryQuestionAsync(Id, options, cancellationToken);

        /// <inheritdoc/>
        public Task RemoveFromGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.RemoveGroupUserAsync(groupId, Id, cancellationToken);

        /// <inheritdoc/>
        public Task<IUser> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.UpdateUserAsync(this, Id, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddSecurityQuestionFactorOptions securityQuestionFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, securityQuestionFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddCallFactorOptions callFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, callFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddEmailFactorOptions emailFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, emailFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddHardwareFactorOptions hardwareFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, hardwareFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddPushFactorOptions pushFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, pushFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddSmsFactorOptions smsFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, smsFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddTokenFactorOptions tokenFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, tokenFactorOptions, cancellationToken);

        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(AddTotpFactorOptions totpFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(Id, totpFactorOptions, cancellationToken);
    }
}
