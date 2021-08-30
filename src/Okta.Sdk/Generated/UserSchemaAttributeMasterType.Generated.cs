// <copyright file="UserSchemaAttributeMasterType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserSchemaAttributeMasterType values in the Okta API.
    /// </summary>
    public sealed class UserSchemaAttributeMasterType : StringEnum
    {
        /// <summary>The PROFILE_MASTER UserSchemaAttributeMasterType.</summary>
        public static UserSchemaAttributeMasterType ProfileMaster = new UserSchemaAttributeMasterType("PROFILE_MASTER");

        /// <summary>The OKTA UserSchemaAttributeMasterType.</summary>
        public static UserSchemaAttributeMasterType Okta = new UserSchemaAttributeMasterType("OKTA");

        /// <summary>The OVERRIDE UserSchemaAttributeMasterType.</summary>
        public static UserSchemaAttributeMasterType Override = new UserSchemaAttributeMasterType("OVERRIDE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserSchemaAttributeMasterType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserSchemaAttributeMasterType(string value) => new UserSchemaAttributeMasterType(value);

        /// <summary>
        /// Creates a new <see cref="UserSchemaAttributeMasterType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserSchemaAttributeMasterType(string value)
            : base(value)
        {
        }

    }
}
