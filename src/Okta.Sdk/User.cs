// <copyright file="User.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
        public Task DeactivateOrDeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.DeactivateOrDeleteUserAsync(Id, cancellationToken);

        public Task ChangeRecoveryQuestionAsync(ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken))
            => new UserClient(GetDataStore()).ChangeRecoveryQuestionAsync(Id, options, cancellationToken);
    }
}
