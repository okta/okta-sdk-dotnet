// <copyright file="User.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class User : Resource, IUser
    {
        /// <inheritdoc/>
        public DateTimeOffset? Activated => GetDateTimeProperty("activated");
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IUserCredentials Credentials 
        {
            get => GetResourceProperty<UserCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastLogin => GetDateTimeProperty("lastLogin");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public DateTimeOffset? PasswordChanged => GetDateTimeProperty("passwordChanged");
        
        /// <inheritdoc/>
        public IUserProfile Profile 
        {
            get => GetResourceProperty<UserProfile>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public UserStatus Status => GetEnumProperty<UserStatus>("status");
        
        /// <inheritdoc/>
        public DateTimeOffset? StatusChanged => GetDateTimeProperty("statusChanged");
        
        /// <inheritdoc/>
        public UserStatus TransitioningToStatus => GetEnumProperty<UserStatus>("transitioningToStatus");
        
        /// <inheritdoc />
        public Task EndAllSessionsAsync(bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.EndAllUserSessionsAsync(Id, oauthTokens, cancellationToken);
        
        /// <inheritdoc />
        public Task<IUserActivationToken> ActivateAsync(bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ActivateUserAsync(Id, sendEmail, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.DeactivateUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task SuspendAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.SuspendUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task UnsuspendAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.UnsuspendUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<ITempPassword> ExpirePasswordAsync(bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ExpirePasswordAsync(Id, tempPassword, cancellationToken);
        
        /// <inheritdoc />
        public Task UnlockAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.UnlockUserAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task ResetFactorsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.ResetAllFactorsAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task AddToGroupAsync(string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.AddUserToGroupAsync(groupId, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IFactor> AddFactorAsync(Factor factor, bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.AddFactorAsync(factor, Id, updatePhone, templateId, tokenLifetimeSeconds, activate, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IFactor> ListSupportedFactors()
            => GetClient().UserFactors.ListSupportedFactors(Id);
        
        /// <inheritdoc />
        public ICollectionClient<IFactor> ListFactors()
            => GetClient().UserFactors.ListFactors(Id);
        
        /// <inheritdoc />
        public ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions()
            => GetClient().UserFactors.ListSupportedSecurityQuestions(Id);
        
        /// <inheritdoc />
        public Task<IFactor> GetFactorAsync(string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().UserFactors.GetFactorAsync(Id, factorId, cancellationToken);
        
    }
}
