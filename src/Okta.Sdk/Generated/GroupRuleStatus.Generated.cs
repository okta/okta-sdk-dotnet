// <copyright file="GroupRuleStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

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
        /// Implicit operator declaration to accept and convert a string value as a <see cref="GroupRuleStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator GroupRuleStatus(string value) => new GroupRuleStatus(value);

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
