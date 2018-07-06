// <copyright file="ApplicationCredentialsOAuthClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ApplicationCredentialsOAuthClient : Resource, IApplicationCredentialsOAuthClient
    {
        /// <inheritdoc/>
        public bool? AutoKeyRotation 
        {
            get => GetBooleanProperty("autoKeyRotation");
            set => this["autoKeyRotation"] = value;
        }
        
        /// <inheritdoc/>
        public string ClientId 
        {
            get => GetStringProperty("client_id");
            set => this["client_id"] = value;
        }
        
        /// <inheritdoc/>
        public string ClientSecret 
        {
            get => GetStringProperty("client_secret");
            set => this["client_secret"] = value;
        }
        
        /// <inheritdoc/>
        public OAuthEndpointAuthenticationMethod TokenEndpointAuthMethod 
        {
            get => GetEnumProperty<OAuthEndpointAuthenticationMethod>("token_endpoint_auth_method");
            set => this["token_endpoint_auth_method"] = value;
        }
        
    }
}
