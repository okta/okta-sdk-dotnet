// <copyright file="RoleAssignmentType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of RoleAssignmentType values in the Okta API.
    /// </summary>
    public sealed class RoleAssignmentType : StringEnum
    {
        /// <summary>The GROUP RoleAssignmentType.</summary>
        public static RoleAssignmentType Group = new RoleAssignmentType("GROUP");

        /// <summary>The USER RoleAssignmentType.</summary>
        public static RoleAssignmentType User = new RoleAssignmentType("USER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="RoleAssignmentType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator RoleAssignmentType(string value) => new RoleAssignmentType(value);

        /// <summary>
        /// Creates a new <see cref="RoleAssignmentType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public RoleAssignmentType(string value)
            : base(value)
        {
        }

    }
}
