// <copyright file="AppUser.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AppUser : Resource, IAppUser
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IAppUserCredentials Credentials 
        {
            get => GetResourceProperty<AppUserCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public string ExternalId => GetStringProperty("externalId");
        
        /// <inheritdoc/>
        public string Id 
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastSync => GetDateTimeProperty("lastSync");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public DateTimeOffset? PasswordChanged => GetDateTimeProperty("passwordChanged");
        
        /// <inheritdoc/>
        public Resource Profile 
        {
            get => GetResourceProperty<Resource>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public string Scope 
        {
            get => GetStringProperty("scope");
            set => this["scope"] = value;
        }
        
        /// <inheritdoc/>
        public string Status => GetStringProperty("status");
        
        /// <inheritdoc/>
        public DateTimeOffset? StatusChanged => GetDateTimeProperty("statusChanged");
        
        /// <inheritdoc/>
        public string SyncState => GetStringProperty("syncState");
        
    }
}
