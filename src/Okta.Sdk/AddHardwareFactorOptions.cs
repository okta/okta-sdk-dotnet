// <copyright file="AddHardwareFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for hardware factor settings
    /// </summary>
    public sealed class AddHardwareFactorOptions
    {
        /// <summary>
        /// Gets or sets factor passCode
        /// </summary>
        public string PassCode { get; set; }

        /// <summary>
        /// Gets or sets factor provider
        /// </summary>
        public FactorProvider Provider { get; set; }
    }
}
