// <copyright file="IBrandsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta Brand resources.</summary>
    public partial interface IBrandsClient
    {
        /// <summary>
        /// List all the brands in your org.
        /// </summary>
        /// <returns>A collection of <see cref="IBrand"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IBrand> ListBrands();

        /// <summary>
        /// Fetches a brand by `brandId`
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IBrand"/> response.</returns>
        Task<IBrand> GetBrandAsync(string brandId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a brand by `brandId`
        /// </summary>
        /// <param name="brand">The <see cref="IBrand"/> resource.</param>
        /// <param name="brandId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IBrand"/> response.</returns>
        Task<IBrand> UpdateBrandAsync(IBrand brand, string brandId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all the themes in your brand
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns>A collection of <see cref="IThemeResponse"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IThemeResponse> ListBrandThemes(string brandId);

        /// <summary>
        /// Fetches a theme for a brand
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IThemeResponse"/> response.</returns>
        Task<IThemeResponse> GetBrandThemeAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a theme for a brand
        /// </summary>
        /// <param name="theme">The <see cref="ITheme"/> resource.</param>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IThemeResponse"/> response.</returns>
        Task<IThemeResponse> UpdateBrandThemeAsync(ITheme theme, string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a Theme background image
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteBrandThemeBackgroundImageAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the background image for your Theme
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IImageUploadResponse"/> response.</returns>
        Task<IImageUploadResponse> UploadBrandThemeBackgroundImageAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a Theme favicon. The org then uses the Okta default favicon.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteBrandThemeFaviconAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the favicon for your theme
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IImageUploadResponse"/> response.</returns>
        Task<IImageUploadResponse> UploadBrandThemeFaviconAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a Theme logo. The org then uses the Okta default logo.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteBrandThemeLogoAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the logo for your Theme
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IImageUploadResponse"/> response.</returns>
        Task<IImageUploadResponse> UploadBrandThemeLogoAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
