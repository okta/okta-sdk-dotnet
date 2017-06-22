// <copyright file="GroupRuleStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class GroupRuleStatus : StringEnum
    {
        public static GroupRuleStatus Active = new GroupRuleStatus("ACTIVE");

        public static GroupRuleStatus Inactive = new GroupRuleStatus("INACTIVE");

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
