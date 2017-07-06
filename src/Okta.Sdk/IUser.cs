// <copyright file="IUser.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IUser
    {
        IAsyncEnumerable<IAppLink> AppLinks { get; }

        IAsyncEnumerable<IRole> Roles { get; }

        IAsyncEnumerable<IGroup> Groups { get; }

        Task DeactivateOrDeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task ChangeRecoveryQuestionAsync(ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken));
    }
}
