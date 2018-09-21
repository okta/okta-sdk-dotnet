// <copyright file="PasswordPolicyPasswordSettingsLockout.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyPasswordSettingsLockout : Resource, IPasswordPolicyPasswordSettingsLockout
    {
        /// <inheritdoc/>
        public int? AutoUnlockMinutes 
        {
            get => GetIntegerProperty("autoUnlockMinutes");
            set => this["autoUnlockMinutes"] = value;
        }
        
        /// <inheritdoc/>
        public int? MaxAttempts 
        {
            get => GetIntegerProperty("maxAttempts");
            set => this["maxAttempts"] = value;
        }
        
        /// <inheritdoc/>
        public bool? ShowLockoutFailures 
        {
            get => GetBooleanProperty("showLockoutFailures");
            set => this["showLockoutFailures"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> UserLockoutNotificationChannels 
        {
            get => GetArrayProperty<string>("userLockoutNotificationChannels");
            set => this["userLockoutNotificationChannels"] = value;
        }
        
    }
}
