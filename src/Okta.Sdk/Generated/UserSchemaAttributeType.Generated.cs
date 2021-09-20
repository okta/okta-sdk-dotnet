// <copyright file="UserSchemaAttributeType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserSchemaAttributeType values in the Okta API.
    /// </summary>
    public sealed class UserSchemaAttributeType : StringEnum
    {
        /// <summary>The string UserSchemaAttributeType.</summary>
        public static UserSchemaAttributeType String = new UserSchemaAttributeType("string");

        /// <summary>The boolean UserSchemaAttributeType.</summary>
        public static UserSchemaAttributeType Boolean = new UserSchemaAttributeType("boolean");

        /// <summary>The number UserSchemaAttributeType.</summary>
        public static UserSchemaAttributeType Number = new UserSchemaAttributeType("number");

        /// <summary>The integer UserSchemaAttributeType.</summary>
        public static UserSchemaAttributeType Integer = new UserSchemaAttributeType("integer");

        /// <summary>The array UserSchemaAttributeType.</summary>
        public static UserSchemaAttributeType Array = new UserSchemaAttributeType("array");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserSchemaAttributeType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserSchemaAttributeType(string value) => new UserSchemaAttributeType(value);

        /// <summary>
        /// Creates a new <see cref="UserSchemaAttributeType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserSchemaAttributeType(string value)
            : base(value)
        {
        }

    }
}
