// <copyright file="NotificationType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of NotificationType values in the Okta API.
    /// </summary>
    public sealed class NotificationType : StringEnum
    {
        /// <summary>The CONNECTOR_AGENT NotificationType.</summary>
        public static NotificationType ConnectorAgent = new NotificationType("CONNECTOR_AGENT");

        /// <summary>The USER_LOCKED_OUT NotificationType.</summary>
        public static NotificationType UserLockedOut = new NotificationType("USER_LOCKED_OUT");

        /// <summary>The APP_IMPORT NotificationType.</summary>
        public static NotificationType AppImport = new NotificationType("APP_IMPORT");

        /// <summary>The LDAP_AGENT NotificationType.</summary>
        public static NotificationType LdapAgent = new NotificationType("LDAP_AGENT");

        /// <summary>The AD_AGENT NotificationType.</summary>
        public static NotificationType AdAgent = new NotificationType("AD_AGENT");

        /// <summary>The OKTA_ANNOUNCEMENT NotificationType.</summary>
        public static NotificationType OktaAnnouncement = new NotificationType("OKTA_ANNOUNCEMENT");

        /// <summary>The OKTA_ISSUE NotificationType.</summary>
        public static NotificationType OktaIssue = new NotificationType("OKTA_ISSUE");

        /// <summary>The OKTA_UPDATE NotificationType.</summary>
        public static NotificationType OktaUpdate = new NotificationType("OKTA_UPDATE");

        /// <summary>The IWA_AGENT NotificationType.</summary>
        public static NotificationType IwaAgent = new NotificationType("IWA_AGENT");

        /// <summary>The USER_DEPROVISION NotificationType.</summary>
        public static NotificationType UserDeprovision = new NotificationType("USER_DEPROVISION");

        /// <summary>The REPORT_SUSPICIOUS_ACTIVITY NotificationType.</summary>
        public static NotificationType ReportSuspiciousActivity = new NotificationType("REPORT_SUSPICIOUS_ACTIVITY");

        /// <summary>The RATELIMIT_NOTIFICATION NotificationType.</summary>
        public static NotificationType RatelimitNotification = new NotificationType("RATELIMIT_NOTIFICATION");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="NotificationType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator NotificationType(string value) => new NotificationType(value);

        /// <summary>
        /// Creates a new <see cref="NotificationType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public NotificationType(string value)
            : base(value)
        {
        }

    }
}
