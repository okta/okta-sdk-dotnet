// <copyright file="GroupRuleStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of GroupRuleStatus values in the Okta API.
    /// </summary>
    public sealed class GroupRuleStatus : StringEnum
    {
        /// <summary>The ACTIVE GroupRuleStatus.</summary>
        public static GroupRuleStatus Active = new GroupRuleStatus("ACTIVE");

        /// <summary>The INACTIVE GroupRuleStatus.</summary>
        public static GroupRuleStatus Inactive = new GroupRuleStatus("INACTIVE");

        /// <summary>The INVALID GroupRuleStatus.</summary>
        public static GroupRuleStatus Invalid = new GroupRuleStatus("INVALID");

        /// <summary>
        /// Creates a new <see cref="GroupRuleStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public GroupRuleStatus(string value)
            : base(value)
        {
        }
    }
}
