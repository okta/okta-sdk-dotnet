// <copyright file="PasswordPolicyRuleAction.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyRuleAction : Resource, IPasswordPolicyRuleAction
    {
        /// <inheritdoc/>
        public string Access 
        {
            get => GetStringProperty("access");
            set => this["access"] = value;
        }
        
    }
}
