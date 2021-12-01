// <copyright file="EmailTemplateTouchPointVariant.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of EmailTemplateTouchPointVariant values in the Okta API.
    /// </summary>
    public sealed class EmailTemplateTouchPointVariant : StringEnum
    {
        /// <summary>The OKTA_DEFAULT EmailTemplateTouchPointVariant.</summary>
        public static EmailTemplateTouchPointVariant OktaDefault = new EmailTemplateTouchPointVariant("OKTA_DEFAULT");

        /// <summary>The FULL_THEME EmailTemplateTouchPointVariant.</summary>
        public static EmailTemplateTouchPointVariant FullTheme = new EmailTemplateTouchPointVariant("FULL_THEME");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="EmailTemplateTouchPointVariant"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EmailTemplateTouchPointVariant(string value) => new EmailTemplateTouchPointVariant(value);

        /// <summary>
        /// Creates a new <see cref="EmailTemplateTouchPointVariant"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EmailTemplateTouchPointVariant(string value)
            : base(value)
        {
        }

    }
}
