// <copyright file="ApplicationCredentialsSigningUse.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ApplicationCredentialsSigningUse values in the Okta API.
    /// </summary>
    public sealed class ApplicationCredentialsSigningUse : StringEnum
    {
        /// <summary>The sig ApplicationCredentialsSigningUse.</summary>
        public static ApplicationCredentialsSigningUse Sig = new ApplicationCredentialsSigningUse("sig");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ApplicationCredentialsSigningUse"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ApplicationCredentialsSigningUse(string value) => new ApplicationCredentialsSigningUse(value);

        /// <summary>
        /// Creates a new <see cref="ApplicationCredentialsSigningUse"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ApplicationCredentialsSigningUse(string value)
            : base(value)
        {
        }

    }
}
