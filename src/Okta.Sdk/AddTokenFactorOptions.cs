// <copyright file="AddTokenFactorOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Helper class for token factor settings
    /// </summary>
    public sealed class AddTokenFactorOptions
    {
        /// <summary>
        /// Gets or sets the credential id
        /// </summary>
        public string CredentialId { get; set; }

        /// <summary>
        /// Gets or sets the pass code
        /// </summary>
        public string PassCode { get; set; }

        /// <summary>
        /// Gets or sets the next pass code
        /// </summary>
        public string NextPassCode { get; set; }

        /// <summary>
        /// Gets or sets the provider
        /// </summary>
        public FactorProvider Provider { get; set; }
    }
}
