// <copyright file="OktaSignOnPolicyRuleSignonActions.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OktaSignOnPolicyRuleSignonActions : Resource, IOktaSignOnPolicyRuleSignonActions
    {
        /// <inheritdoc/>
        public string Access 
        {
            get => GetStringProperty("access");
            set => this["access"] = value;
        }
        
        /// <inheritdoc/>
        public int? FactorLifetime 
        {
            get => GetIntegerProperty("factorLifetime");
            set => this["factorLifetime"] = value;
        }
        
        /// <inheritdoc/>
        public string FactorPromptMode 
        {
            get => GetStringProperty("factorPromptMode");
            set => this["factorPromptMode"] = value;
        }
        
        /// <inheritdoc/>
        public bool? RememberDeviceByDefault 
        {
            get => GetBooleanProperty("rememberDeviceByDefault");
            set => this["rememberDeviceByDefault"] = value;
        }
        
        /// <inheritdoc/>
        public bool? RequireFactor 
        {
            get => GetBooleanProperty("requireFactor");
            set => this["requireFactor"] = value;
        }
        
        /// <inheritdoc/>
        public IOktaSignOnPolicyRuleSignonSessionActions Session 
        {
            get => GetResourceProperty<OktaSignOnPolicyRuleSignonSessionActions>("session");
            set => this["session"] = value;
        }
        
    }
}
