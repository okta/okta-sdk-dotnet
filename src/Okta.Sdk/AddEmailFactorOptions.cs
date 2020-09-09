// <copyright file="AddEmailFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class to configure email factor settings
    /// </summary>
    public sealed class AddEmailFactorOptions
    {
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the lifetime of the OTP in a range 1 to 86400, 300 seconds is the default.
        /// </summary>
        public int TokenLifetimeSeconds { get; set; } = 300;
    }
}
