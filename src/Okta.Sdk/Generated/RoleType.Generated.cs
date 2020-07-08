// <copyright file="RoleType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of RoleType values in the Okta API.
    /// </summary>
    public sealed class RoleType : StringEnum
    {
        /// <summary>The SUPER_ADMIN RoleType.</summary>
        public static RoleType SuperAdmin = new RoleType("SUPER_ADMIN");

        /// <summary>The ORG_ADMIN RoleType.</summary>
        public static RoleType OrgAdmin = new RoleType("ORG_ADMIN");

        /// <summary>The APP_ADMIN RoleType.</summary>
        public static RoleType AppAdmin = new RoleType("APP_ADMIN");

        /// <summary>The USER_ADMIN RoleType.</summary>
        public static RoleType UserAdmin = new RoleType("USER_ADMIN");

        /// <summary>The HELP_DESK_ADMIN RoleType.</summary>
        public static RoleType HelpDeskAdmin = new RoleType("HELP_DESK_ADMIN");

        /// <summary>The READ_ONLY_ADMIN RoleType.</summary>
        public static RoleType ReadOnlyAdmin = new RoleType("READ_ONLY_ADMIN");

        /// <summary>The MOBILE_ADMIN RoleType.</summary>
        public static RoleType MobileAdmin = new RoleType("MOBILE_ADMIN");

        /// <summary>The API_ACCESS_MANAGEMENT_ADMIN RoleType.</summary>
        public static RoleType ApiAccessManagementAdmin = new RoleType("API_ACCESS_MANAGEMENT_ADMIN");

        /// <summary>The REPORT_ADMIN RoleType.</summary>
        public static RoleType ReportAdmin = new RoleType("REPORT_ADMIN");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="RoleType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator RoleType(string value) => new RoleType(value);

        /// <summary>
        /// Creates a new <see cref="RoleType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public RoleType(string value)
            : base(value)
        {
        }

    }
}
