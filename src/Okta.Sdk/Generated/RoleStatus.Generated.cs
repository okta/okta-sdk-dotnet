// <copyright file="RoleStatus.Generated.cs" company="Okta, Inc">
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
    public sealed class RoleStatus : StringEnum
    {
        public static RoleStatus Active = new RoleStatus("ACTIVE");

        public static RoleStatus Inactive = new RoleStatus("INACTIVE");

        /// <summary>
        /// Creates a new <see cref="RoleStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public RoleStatus(string value)
            : base(value)
        {
        }
    }
}
