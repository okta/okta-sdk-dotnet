// <copyright file="ErrorPageTouchPointVariant.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ErrorPageTouchPointVariant values in the Okta API.
    /// </summary>
    public sealed class ErrorPageTouchPointVariant : StringEnum
    {
        /// <summary>The OKTA_DEFAULT ErrorPageTouchPointVariant.</summary>
        public static ErrorPageTouchPointVariant OktaDefault = new ErrorPageTouchPointVariant("OKTA_DEFAULT");

        /// <summary>The BACKGROUND_SECONDARY_COLOR ErrorPageTouchPointVariant.</summary>
        public static ErrorPageTouchPointVariant BackgroundSecondaryColor = new ErrorPageTouchPointVariant("BACKGROUND_SECONDARY_COLOR");

        /// <summary>The BACKGROUND_IMAGE ErrorPageTouchPointVariant.</summary>
        public static ErrorPageTouchPointVariant BackgroundImage = new ErrorPageTouchPointVariant("BACKGROUND_IMAGE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ErrorPageTouchPointVariant"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ErrorPageTouchPointVariant(string value) => new ErrorPageTouchPointVariant(value);

        /// <summary>
        /// Creates a new <see cref="ErrorPageTouchPointVariant"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ErrorPageTouchPointVariant(string value)
            : base(value)
        {
        }

    }
}
