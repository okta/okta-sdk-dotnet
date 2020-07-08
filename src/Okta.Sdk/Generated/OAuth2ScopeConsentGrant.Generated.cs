// <copyright file="OAuth2ScopeConsentGrant.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OAuth2ScopeConsentGrant : Resource, IOAuth2ScopeConsentGrant
    {
        /// <inheritdoc/>
        public string ClientId 
        {
            get => GetStringProperty("clientId");
            set => this["clientId"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IOAuth2Actor CreatedBy 
        {
            get => GetResourceProperty<OAuth2Actor>("createdBy");
            set => this["createdBy"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Issuer 
        {
            get => GetStringProperty("issuer");
            set => this["issuer"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string ScopeId 
        {
            get => GetStringProperty("scopeId");
            set => this["scopeId"] = value;
        }
        
        /// <inheritdoc/>
        public OAuth2ScopeConsentGrantSource Source 
        {
            get => GetEnumProperty<OAuth2ScopeConsentGrantSource>("source");
            set => this["source"] = value;
        }
        
        /// <inheritdoc/>
        public OAuth2ScopeConsentGrantStatus Status 
        {
            get => GetEnumProperty<OAuth2ScopeConsentGrantStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public string UserId 
        {
            get => GetStringProperty("userId");
            set => this["userId"] = value;
        }
        
    }
}
