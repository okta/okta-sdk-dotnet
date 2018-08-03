// <copyright file="RoleStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of RoleStatus values in the Okta API.
    /// </summary>
    public sealed class RoleStatus : StringEnum
    {
        /// <summary>The ACTIVE RoleStatus.</summary>
        public static RoleStatus Active = new RoleStatus("ACTIVE");

        /// <summary>The INACTIVE RoleStatus.</summary>
        public static RoleStatus Inactive = new RoleStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="RoleStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator RoleStatus(string value) => new RoleStatus(value);

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
