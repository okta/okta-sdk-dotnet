// <copyright file="OrgOktaSupportSetting.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of OrgOktaSupportSetting values in the Okta API.
    /// </summary>
    public sealed class OrgOktaSupportSetting : StringEnum
    {
        /// <summary>The DISABLED OrgOktaSupportSetting.</summary>
        public static OrgOktaSupportSetting Disabled = new OrgOktaSupportSetting("DISABLED");

        /// <summary>The ENABLED OrgOktaSupportSetting.</summary>
        public static OrgOktaSupportSetting Enabled = new OrgOktaSupportSetting("ENABLED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="OrgOktaSupportSetting"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator OrgOktaSupportSetting(string value) => new OrgOktaSupportSetting(value);

        /// <summary>
        /// Creates a new <see cref="OrgOktaSupportSetting"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public OrgOktaSupportSetting(string value)
            : base(value)
        {
        }

    }
}
