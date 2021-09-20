// <copyright file="UserSchemaAttributeUnion.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of UserSchemaAttributeUnion values in the Okta API.
    /// </summary>
    public sealed class UserSchemaAttributeUnion : StringEnum
    {
        /// <summary>The DISABLE UserSchemaAttributeUnion.</summary>
        public static UserSchemaAttributeUnion Disable = new UserSchemaAttributeUnion("DISABLE");

        /// <summary>The ENABLE UserSchemaAttributeUnion.</summary>
        public static UserSchemaAttributeUnion Enable = new UserSchemaAttributeUnion("ENABLE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="UserSchemaAttributeUnion"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator UserSchemaAttributeUnion(string value) => new UserSchemaAttributeUnion(value);

        /// <summary>
        /// Creates a new <see cref="UserSchemaAttributeUnion"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public UserSchemaAttributeUnion(string value)
            : base(value)
        {
        }

    }
}
