// <copyright file="Authenticator.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Authenticator : Resource, IAuthenticator
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Key 
        {
            get => GetStringProperty("key");
            set => this["key"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public IAuthenticatorSettings Settings 
        {
            get => GetResourceProperty<AuthenticatorSettings>("settings");
            set => this["settings"] = value;
        }
        
        /// <inheritdoc/>
        public AuthenticatorStatus Status 
        {
            get => GetEnumProperty<AuthenticatorStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public AuthenticatorType Type 
        {
            get => GetEnumProperty<AuthenticatorType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Authenticators.ActivateAuthenticatorAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Authenticators.DeactivateAuthenticatorAsync(Id, cancellationToken);
        
    }
}
