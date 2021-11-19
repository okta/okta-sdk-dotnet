// <copyright file="IThemeResponse.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a ThemeResponse resource in the Okta API.</summary>
    public partial interface IThemeResponse : IResource
    {
        string BackgroundImage { get; }

        EmailTemplateTouchPointVariant EmailTemplateTouchPointVariant { get; set; }

        EndUserDashboardTouchPointVariant EndUserDashboardTouchPointVariant { get; set; }

        ErrorPageTouchPointVariant ErrorPageTouchPointVariant { get; set; }

        string Favicon { get; }

        string Id { get; }

        string Logo { get; }

        string PrimaryColorContrastHex { get; set; }

        string PrimaryColorHex { get; set; }

        string SecondaryColorContrastHex { get; set; }

        string SecondaryColorHex { get; set; }

        SignInPageTouchPointVariant SignInPageTouchPointVariant { get; set; }

    }
}
