// <copyright file="SocialAuthToken.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SocialAuthToken : Resource, ISocialAuthToken
    {
        /// <inheritdoc/>
        public DateTimeOffset? ExpiresAt => GetDateTimeProperty("expiresAt");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public IList<string> Scopes 
        {
            get => GetArrayProperty<string>("scopes");
            set => this["scopes"] = value;
        }
        
        /// <inheritdoc/>
        public string Token 
        {
            get => GetStringProperty("token");
            set => this["token"] = value;
        }
        
        /// <inheritdoc/>
        public string TokenAuthScheme 
        {
            get => GetStringProperty("tokenAuthScheme");
            set => this["tokenAuthScheme"] = value;
        }
        
        /// <inheritdoc/>
        public string TokenType 
        {
            get => GetStringProperty("tokenType");
            set => this["tokenType"] = value;
        }
        
    }
}
