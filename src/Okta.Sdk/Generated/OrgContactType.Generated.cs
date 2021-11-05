// <copyright file="OrgContactType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OrgContactType values in the Okta API.
    /// </summary>
    public sealed class OrgContactType : StringEnum
    {
        /// <summary>The BILLING OrgContactType.</summary>
        public static OrgContactType Billing = new OrgContactType("BILLING");

        /// <summary>The TECHNICAL OrgContactType.</summary>
        public static OrgContactType Technical = new OrgContactType("TECHNICAL");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OrgContactType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OrgContactType(string value) => new OrgContactType(value);

        /// <summary>
        /// Creates a new <see cref="OrgContactType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OrgContactType(string value)
            : base(value)
        {
        }

    }
}
