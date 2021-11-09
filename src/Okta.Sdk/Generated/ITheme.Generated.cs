// <copyright file="ITheme.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Theme resource in the Okta API.</summary>
    public partial interface ITheme : IResource
    {
        string BackgroundImage { get; }

        EmailTemplateTouchPointVariant EmailTemplateTouchPointVariant { get; set; }

        EndUserDashboardTouchPointVariant EndUserDashboardTouchPointVariant { get; set; }

        ErrorPageTouchPointVariant ErrorPageTouchPointVariant { get; set; }

        string PrimaryColorContrastHex { get; set; }

        string PrimaryColorHex { get; set; }

        string SecondaryColorContrastHex { get; set; }

        string SecondaryColorHex { get; set; }

        SignInPageTouchPointVariant SignInPageTouchPointVariant { get; set; }

        Task<IImageUploadResponse> UploadBrandThemeLogoAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteBrandThemeLogoAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IImageUploadResponse> UpdateBrandThemeFaviconAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteBrandThemeFaviconAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IImageUploadResponse> UpdateBrandThemeBackgroundImageAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteBrandThemeBackgroundImageAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
