// <copyright file="IUser.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a User resource in the Okta API.</summary>
    public partial interface IUser : IResource
    {
        DateTimeOffset? Activated { get; }

        DateTimeOffset? Created { get; }

        IUserCredentials Credentials { get; set; }

        string Id { get; }

        DateTimeOffset? LastLogin { get; }

        DateTimeOffset? LastUpdated { get; }

        DateTimeOffset? PasswordChanged { get; }

        IUserProfile Profile { get; set; }

        UserStatus Status { get; }

        DateTimeOffset? StatusChanged { get; }

        UserStatus TransitioningToStatus { get; }

        Task EndAllSessionsAsync(bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken));

        Task<IUserActivationToken> ActivateAsync(bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task SuspendAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task UnsuspendAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<ITempPassword> ExpirePasswordAsync(bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken));

        Task UnlockAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task ResetFactorsAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task AddToGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IFactor> AddFactorAsync(Factor factor, bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IFactor> ListSupportedFactors();

        ICollectionClient<IFactor> ListFactors();

        ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions();

        Task<IFactor> GetFactorAsync(string factorId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
