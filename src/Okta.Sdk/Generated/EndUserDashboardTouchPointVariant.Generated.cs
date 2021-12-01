// <copyright file="EndUserDashboardTouchPointVariant.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of EndUserDashboardTouchPointVariant values in the Okta API.
    /// </summary>
    public sealed class EndUserDashboardTouchPointVariant : StringEnum
    {
        /// <summary>The OKTA_DEFAULT EndUserDashboardTouchPointVariant.</summary>
        public static EndUserDashboardTouchPointVariant OktaDefault = new EndUserDashboardTouchPointVariant("OKTA_DEFAULT");

        /// <summary>The WHITE_LOGO_BACKGROUND EndUserDashboardTouchPointVariant.</summary>
        public static EndUserDashboardTouchPointVariant WhiteLogoBackground = new EndUserDashboardTouchPointVariant("WHITE_LOGO_BACKGROUND");

        /// <summary>The FULL_THEME EndUserDashboardTouchPointVariant.</summary>
        public static EndUserDashboardTouchPointVariant FullTheme = new EndUserDashboardTouchPointVariant("FULL_THEME");

        /// <summary>The LOGO_ON_FULL_WHITE_BACKGROUND EndUserDashboardTouchPointVariant.</summary>
        public static EndUserDashboardTouchPointVariant LogoOnFullWhiteBackground = new EndUserDashboardTouchPointVariant("LOGO_ON_FULL_WHITE_BACKGROUND");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="EndUserDashboardTouchPointVariant"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EndUserDashboardTouchPointVariant(string value) => new EndUserDashboardTouchPointVariant(value);

        /// <summary>
        /// Creates a new <see cref="EndUserDashboardTouchPointVariant"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EndUserDashboardTouchPointVariant(string value)
            : base(value)
        {
        }

    }
}
