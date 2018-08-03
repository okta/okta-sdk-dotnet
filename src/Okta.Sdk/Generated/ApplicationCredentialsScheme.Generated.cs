// <copyright file="ApplicationCredentialsScheme.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ApplicationCredentialsScheme values in the Okta API.
    /// </summary>
    public sealed class ApplicationCredentialsScheme : StringEnum
    {
        /// <summary>The SHARED_USERNAME_AND_PASSWORD ApplicationCredentialsScheme.</summary>
        public static ApplicationCredentialsScheme SharedUsernameAndPassword = new ApplicationCredentialsScheme("SHARED_USERNAME_AND_PASSWORD");

        /// <summary>The EXTERNAL_PASSWORD_SYNC ApplicationCredentialsScheme.</summary>
        public static ApplicationCredentialsScheme ExternalPasswordSync = new ApplicationCredentialsScheme("EXTERNAL_PASSWORD_SYNC");

        /// <summary>The EDIT_USERNAME_AND_PASSWORD ApplicationCredentialsScheme.</summary>
        public static ApplicationCredentialsScheme EditUsernameAndPassword = new ApplicationCredentialsScheme("EDIT_USERNAME_AND_PASSWORD");

        /// <summary>The EDIT_PASSWORD_ONLY ApplicationCredentialsScheme.</summary>
        public static ApplicationCredentialsScheme EditPasswordOnly = new ApplicationCredentialsScheme("EDIT_PASSWORD_ONLY");

        /// <summary>The ADMIN_SETS_CREDENTIALS ApplicationCredentialsScheme.</summary>
        public static ApplicationCredentialsScheme AdminSetsCredentials = new ApplicationCredentialsScheme("ADMIN_SETS_CREDENTIALS");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ApplicationCredentialsScheme"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ApplicationCredentialsScheme(string value) => new ApplicationCredentialsScheme(value);

        /// <summary>
        /// Creates a new <see cref="ApplicationCredentialsScheme"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ApplicationCredentialsScheme(string value)
            : base(value)
        {
        }

    }
}
