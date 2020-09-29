// <copyright file="AddPasswordPolicyRuleOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    /// <summary>
    /// Custom HMAC-based One-Time Password (HOTP) factor options
    /// </summary>
    public class AddCustomHotpFactorOptions
    {
        /// <summary>
        /// Gets or sets the Factor Profile id
        /// </summary>
        public string FactorProfileId { get; set; }

        /// <summary>
        /// Gets or sets the shared secret for a particular token
        /// </summary>
        public string ProfileSharedSecret { get; set; }
    }
}
