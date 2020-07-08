// <copyright file="IDevicePolicyRuleCondition.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a DevicePolicyRuleCondition resource in the Okta API.</summary>
    public partial interface IDevicePolicyRuleCondition : IResource
    {
        bool? Migrated { get; set; }

        IDevicePolicyRuleConditionPlatform Platform { get; set; }

        bool? Rooted { get; set; }

        string TrustLevel { get; set; }

    }
}
