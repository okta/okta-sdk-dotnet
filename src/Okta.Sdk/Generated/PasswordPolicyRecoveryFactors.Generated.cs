// <copyright file="PasswordPolicyRecoveryFactors.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyRecoveryFactors : Resource, IPasswordPolicyRecoveryFactors
    {
        /// <inheritdoc/>
        public IPasswordPolicyRecoveryFactorSettings OktaCall 
        {
            get => GetResourceProperty<PasswordPolicyRecoveryFactorSettings>("okta_call");
            set => this["okta_call"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyRecoveryEmail OktaEmail 
        {
            get => GetResourceProperty<PasswordPolicyRecoveryEmail>("okta_email");
            set => this["okta_email"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyRecoveryFactorSettings OktaSms 
        {
            get => GetResourceProperty<PasswordPolicyRecoveryFactorSettings>("okta_sms");
            set => this["okta_sms"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyRecoveryQuestion RecoveryQuestion 
        {
            get => GetResourceProperty<PasswordPolicyRecoveryQuestion>("recovery_question");
            set => this["recovery_question"] = value;
        }
        
    }
}
