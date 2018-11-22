// <copyright file="PasswordPolicyPasswordSettings.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyPasswordSettings : Resource, IPasswordPolicyPasswordSettings
    {
        /// <inheritdoc/>
        public IPasswordPolicyPasswordSettingsAge Age 
        {
            get => GetResourceProperty<PasswordPolicyPasswordSettingsAge>("age");
            set => this["age"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyPasswordSettingsComplexity Complexity 
        {
            get => GetResourceProperty<PasswordPolicyPasswordSettingsComplexity>("complexity");
            set => this["complexity"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordPolicyPasswordSettingsLockout Lockout 
        {
            get => GetResourceProperty<PasswordPolicyPasswordSettingsLockout>("lockout");
            set => this["lockout"] = value;
        }
        
    }
}
