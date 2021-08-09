// <copyright file="AuthorizationServerPolicyRuleConditions.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AuthorizationServerPolicyRuleConditions : Resource, IAuthorizationServerPolicyRuleConditions
    {
        /// <inheritdoc/>
        public IPolicyPeopleCondition People 
        {
            get => GetResourceProperty<PolicyPeopleCondition>("people");
            set => this["people"] = value;
        }
        
        /// <inheritdoc/>
        public IClientPolicyCondition Clients 
        {
            get => GetResourceProperty<ClientPolicyCondition>("clients");
            set => this["clients"] = value;
        }
        
        /// <inheritdoc/>
        public IGrantTypePolicyRuleCondition GrantTypes 
        {
            get => GetResourceProperty<GrantTypePolicyRuleCondition>("grantTypes");
            set => this["grantTypes"] = value;
        }
        
        /// <inheritdoc/>
        public IOAuth2ScopesMediationPolicyRuleCondition Scopes 
        {
            get => GetResourceProperty<OAuth2ScopesMediationPolicyRuleCondition>("scopes");
            set => this["scopes"] = value;
        }
        
    }
}
