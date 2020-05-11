// <copyright file="ScopeType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ScopeType values in the Okta API.
    /// </summary>
    public sealed class ScopeType : StringEnum
    {
        /// <summary>The CORS ScopeType.</summary>
        public static ScopeType Cors = new ScopeType("CORS");

        /// <summary>The REDIRECT ScopeType.</summary>
        public static ScopeType Redirect = new ScopeType("REDIRECT");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ScopeType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ScopeType(string value) => new ScopeType(value);

        /// <summary>
        /// Creates a new <see cref="ScopeType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ScopeType(string value)
            : base(value)
        {
        }

    }
}
