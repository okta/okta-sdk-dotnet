// <copyright file="PolicyRuleConditions.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PolicyRuleConditions : Resource, IPolicyRuleConditions
    {
        /// <inheritdoc/>
        public IAppAndInstancePolicyRuleCondition App 
        {
            get => GetResourceProperty<AppAndInstancePolicyRuleCondition>("app");
            set => this["app"] = value;
        }
        
        /// <inheritdoc/>
        public IAppInstancePolicyRuleCondition Apps 
        {
            get => GetResourceProperty<AppInstancePolicyRuleCondition>("apps");
            set => this["apps"] = value;
        }
        
        /// <inheritdoc/>
        public IPolicyRuleAuthContextCondition AuthContext 
        {
            get => GetResourceProperty<PolicyRuleAuthContextCondition>("authContext");
            set => this["authContext"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyAuthenticationProviderCondition AuthProvider 
        {
            get => GetResourceProperty<PasswordPolicyAuthenticationProviderCondition>("authProvider");
            set => this["authProvider"] = value;
        }
        
        /// <inheritdoc/>
        public IBeforeScheduledActionPolicyRuleCondition BeforeScheduledAction 
        {
            get => GetResourceProperty<BeforeScheduledActionPolicyRuleCondition>("beforeScheduledAction");
            set => this["beforeScheduledAction"] = value;
        }
        
        /// <inheritdoc/>
        public IClientPolicyCondition Clients 
        {
            get => GetResourceProperty<ClientPolicyCondition>("clients");
            set => this["clients"] = value;
        }
        
        /// <inheritdoc/>
        public IContextPolicyRuleCondition Context 
        {
            get => GetResourceProperty<ContextPolicyRuleCondition>("context");
            set => this["context"] = value;
        }
        
        /// <inheritdoc/>
        public IDevicePolicyRuleCondition Device 
        {
            get => GetResourceProperty<DevicePolicyRuleCondition>("device");
            set => this["device"] = value;
        }
        
        /// <inheritdoc/>
        public IGrantTypePolicyRuleCondition GrantTypes 
        {
            get => GetResourceProperty<GrantTypePolicyRuleCondition>("grantTypes");
            set => this["grantTypes"] = value;
        }
        
        /// <inheritdoc/>
        public IGroupPolicyRuleCondition Groups 
        {
            get => GetResourceProperty<GroupPolicyRuleCondition>("groups");
            set => this["groups"] = value;
        }
        
        /// <inheritdoc/>
        public IIdentityProviderPolicyRuleCondition IdentityProvider 
        {
            get => GetResourceProperty<IdentityProviderPolicyRuleCondition>("identityProvider");
            set => this["identityProvider"] = value;
        }
        
        /// <inheritdoc/>
        public IMDMEnrollmentPolicyRuleCondition MdmEnrollment 
        {
            get => GetResourceProperty<MDMEnrollmentPolicyRuleCondition>("mdmEnrollment");
            set => this["mdmEnrollment"] = value;
        }
        
        /// <inheritdoc/>
        public IPolicyNetworkCondition Network 
        {
            get => GetResourceProperty<PolicyNetworkCondition>("network");
            set => this["network"] = value;
        }
        
        /// <inheritdoc/>
        public IPolicyPeopleCondition People 
        {
            get => GetResourceProperty<PolicyPeopleCondition>("people");
            set => this["people"] = value;
        }
        
        /// <inheritdoc/>
        public IPlatformPolicyRuleCondition Platform 
        {
            get => GetResourceProperty<PlatformPolicyRuleCondition>("platform");
            set => this["platform"] = value;
        }
        
        /// <inheritdoc/>
        public IRiskPolicyRuleCondition Risk 
        {
            get => GetResourceProperty<RiskPolicyRuleCondition>("risk");
            set => this["risk"] = value;
        }
        
        /// <inheritdoc/>
        public IRiskScorePolicyRuleCondition RiskScore 
        {
            get => GetResourceProperty<RiskScorePolicyRuleCondition>("riskScore");
            set => this["riskScore"] = value;
        }
        
        /// <inheritdoc/>
        public IOAuth2ScopesMediationPolicyRuleCondition Scopes 
        {
            get => GetResourceProperty<OAuth2ScopesMediationPolicyRuleCondition>("scopes");
            set => this["scopes"] = value;
        }
        
        /// <inheritdoc/>
        public IUserIdentifierPolicyRuleCondition UserIdentifier 
        {
            get => GetResourceProperty<UserIdentifierPolicyRuleCondition>("userIdentifier");
            set => this["userIdentifier"] = value;
        }
        
        /// <inheritdoc/>
        public IUserStatusPolicyRuleCondition UserStatus 
        {
            get => GetResourceProperty<UserStatusPolicyRuleCondition>("userStatus");
            set => this["userStatus"] = value;
        }
        
        /// <inheritdoc/>
        public IUserPolicyRuleCondition Users 
        {
            get => GetResourceProperty<UserPolicyRuleCondition>("users");
            set => this["users"] = value;
        }
        
    }
}
