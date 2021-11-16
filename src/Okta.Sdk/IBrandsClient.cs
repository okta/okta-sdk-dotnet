// <copyright file="IBrandsClient.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc cref="IBrandsClient"/>
    public partial interface IBrandsClient
    {
        /// <summary>
        /// Updates the logo for your Theme
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="brandId">The brand Id.</param>
        /// <param name="themeId">The theme Id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeLogoAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the favicon for your Theme
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="brandId">The brand Id.</param>
        /// <param name="themeId">The theme Id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeFaviconAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the background image for your Theme
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="brandId">The brand Id.</param>
        /// <param name="themeId">The theme Id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeBackgroundImageAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default);
    }
}
