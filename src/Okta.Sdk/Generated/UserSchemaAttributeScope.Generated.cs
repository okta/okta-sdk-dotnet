// <copyright file="UserSchemaAttributeScope.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserSchemaAttributeScope values in the Okta API.
    /// </summary>
    public sealed class UserSchemaAttributeScope : StringEnum
    {
        /// <summary>The SELF UserSchemaAttributeScope.</summary>
        public static UserSchemaAttributeScope Self = new UserSchemaAttributeScope("SELF");

        /// <summary>The NONE UserSchemaAttributeScope.</summary>
        public static UserSchemaAttributeScope None = new UserSchemaAttributeScope("NONE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserSchemaAttributeScope"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserSchemaAttributeScope(string value) => new UserSchemaAttributeScope(value);

        /// <summary>
        /// Creates a new <see cref="UserSchemaAttributeScope"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserSchemaAttributeScope(string value)
            : base(value)
        {
        }

    }
}
