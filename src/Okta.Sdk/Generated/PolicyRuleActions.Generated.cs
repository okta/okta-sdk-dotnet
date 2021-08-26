// <copyright file="PolicyRuleActions.Generated.cs" company="Okta, Inc">
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
    public partial class PolicyRuleActions : Resource, IPolicyRuleActions
    {
        /// <inheritdoc/>
        public IPolicyRuleActionsEnroll Enroll 
        {
            get => GetResourceProperty<PolicyRuleActionsEnroll>("enroll");
            set => this["enroll"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyRuleAction PasswordChange 
        {
            get => GetResourceProperty<PasswordPolicyRuleAction>("passwordChange");
            set => this["passwordChange"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyRuleAction SelfServicePasswordReset 
        {
            get => GetResourceProperty<PasswordPolicyRuleAction>("selfServicePasswordReset");
            set => this["selfServicePasswordReset"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyRuleAction SelfServiceUnlock 
        {
            get => GetResourceProperty<PasswordPolicyRuleAction>("selfServiceUnlock");
            set => this["selfServiceUnlock"] = value;
        }
        
        /// <inheritdoc/>
        public IOktaSignOnPolicyRuleSignonActions Signon 
        {
            get => GetResourceProperty<OktaSignOnPolicyRuleSignonActions>("signon");
            set => this["signon"] = value;
        }
        
    }
}
