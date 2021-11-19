// <copyright file="ProfileEnrollmentPolicyRuleAction.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ProfileEnrollmentPolicyRuleAction : Resource, IProfileEnrollmentPolicyRuleAction
    {
        /// <inheritdoc/>
        public string Access 
        {
            get => GetStringProperty("access");
            set => this["access"] = value;
        }
        
        /// <inheritdoc/>
        public IProfileEnrollmentPolicyRuleActivationRequirement ActivationRequirements 
        {
            get => GetResourceProperty<ProfileEnrollmentPolicyRuleActivationRequirement>("activationRequirements");
            set => this["activationRequirements"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IPreRegistrationInlineHook> PreRegistrationInlineHooks 
        {
            get => GetArrayProperty<IPreRegistrationInlineHook>("preRegistrationInlineHooks");
            set => this["preRegistrationInlineHooks"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IProfileEnrollmentPolicyRuleProfileAttribute> ProfileAttributes 
        {
            get => GetArrayProperty<IProfileEnrollmentPolicyRuleProfileAttribute>("profileAttributes");
            set => this["profileAttributes"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> TargetGroupIds 
        {
            get => GetArrayProperty<string>("targetGroupIds");
            set => this["targetGroupIds"] = value;
        }
        
        /// <inheritdoc/>
        public string UnknownUserAction 
        {
            get => GetStringProperty("unknownUserAction");
            set => this["unknownUserAction"] = value;
        }
        
    }
}
