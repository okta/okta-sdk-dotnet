// <copyright file="SignInPageTouchPointVariant.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SignInPageTouchPointVariant values in the Okta API.
    /// </summary>
    public sealed class SignInPageTouchPointVariant : StringEnum
    {
        /// <summary>The OKTA_DEFAULT SignInPageTouchPointVariant.</summary>
        public static SignInPageTouchPointVariant OktaDefault = new SignInPageTouchPointVariant("OKTA_DEFAULT");

        /// <summary>The BACKGROUND_SECONDARY_COLOR SignInPageTouchPointVariant.</summary>
        public static SignInPageTouchPointVariant BackgroundSecondaryColor = new SignInPageTouchPointVariant("BACKGROUND_SECONDARY_COLOR");

        /// <summary>The BACKGROUND_IMAGE SignInPageTouchPointVariant.</summary>
        public static SignInPageTouchPointVariant BackgroundImage = new SignInPageTouchPointVariant("BACKGROUND_IMAGE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="SignInPageTouchPointVariant"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator SignInPageTouchPointVariant(string value) => new SignInPageTouchPointVariant(value);

        /// <summary>
        /// Creates a new <see cref="SignInPageTouchPointVariant"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SignInPageTouchPointVariant(string value)
            : base(value)
        {
        }

    }
}
