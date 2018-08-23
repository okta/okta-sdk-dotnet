// <copyright file="AddTotpFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for token:software:totp factor
    /// </summary>
    public sealed class AddTotpFactorOptions
    {
        /// <summary>
        /// Gets or sets the factor provider
        /// </summary>
        public FactorProvider Provider { get; set; }
    }
}
