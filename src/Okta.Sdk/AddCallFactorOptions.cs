// <copyright file="AddCallFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for call factor settings
    /// </summary>
    public sealed class AddCallFactorOptions
    {
        /// <summary>
        /// Gets or sets the phone extension
        /// </summary>
        public string PhoneExtension { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
