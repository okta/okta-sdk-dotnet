// <copyright file="PasswordPolicyPasswordSettingsAge.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyPasswordSettingsAge : Resource, IPasswordPolicyPasswordSettingsAge
    {
        /// <inheritdoc/>
        public int? ExpireWarnDays 
        {
            get => GetIntegerProperty("expireWarnDays");
            set => this["expireWarnDays"] = value;
        }
        
        /// <inheritdoc/>
        public int? HistoryCount 
        {
            get => GetIntegerProperty("historyCount");
            set => this["historyCount"] = value;
        }
        
        /// <inheritdoc/>
        public int? MaxAgeDays 
        {
            get => GetIntegerProperty("maxAgeDays");
            set => this["maxAgeDays"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinAgeMinutes 
        {
            get => GetIntegerProperty("minAgeMinutes");
            set => this["minAgeMinutes"] = value;
        }
        
    }
}
