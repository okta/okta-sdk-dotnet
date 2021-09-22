// <copyright file="TokenAuthorizationServerPolicyRuleAction.Generated.cs" company="Okta, Inc">
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
    public sealed partial class TokenAuthorizationServerPolicyRuleAction : Resource, ITokenAuthorizationServerPolicyRuleAction
    {
        /// <inheritdoc/>
        public int? AccessTokenLifetimeMinutes 
        {
            get => GetIntegerProperty("accessTokenLifetimeMinutes");
            set => this["accessTokenLifetimeMinutes"] = value;
        }
        
        /// <inheritdoc/>
        public ITokenAuthorizationServerPolicyRuleActionInlineHook InlineHook 
        {
            get => GetResourceProperty<TokenAuthorizationServerPolicyRuleActionInlineHook>("inlineHook");
            set => this["inlineHook"] = value;
        }
        
        /// <inheritdoc/>
        public int? RefreshTokenLifetimeMinutes 
        {
            get => GetIntegerProperty("refreshTokenLifetimeMinutes");
            set => this["refreshTokenLifetimeMinutes"] = value;
        }
        
        /// <inheritdoc/>
        public int? RefreshTokenWindowMinutes 
        {
            get => GetIntegerProperty("refreshTokenWindowMinutes");
            set => this["refreshTokenWindowMinutes"] = value;
        }
        
    }
}
