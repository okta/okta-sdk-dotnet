// <copyright file="GroupType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of GroupType values in the Okta API.
    /// </summary>
    public sealed class GroupType : StringEnum
    {
        /// <summary>The OKTA_GROUP GroupType.</summary>
        public static GroupType OktaGroup = new GroupType("OKTA_GROUP");

        /// <summary>The APP_GROUP GroupType.</summary>
        public static GroupType AppGroup = new GroupType("APP_GROUP");

        /// <summary>The BUILT_IN GroupType.</summary>
        public static GroupType BuiltIn = new GroupType("BUILT_IN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="GroupType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator GroupType(string value) => new GroupType(value);

        /// <summary>
        /// Creates a new <see cref="GroupType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public GroupType(string value)
            : base(value)
        {
        }

    }
}
