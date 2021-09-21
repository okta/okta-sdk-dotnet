// <copyright file="PasswordPolicyRuleActions.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyRuleActions : Resource, IPasswordPolicyRuleActions
    {
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
        
    }
}
