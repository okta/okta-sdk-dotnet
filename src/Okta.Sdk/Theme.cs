// <copyright file="Theme.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc cref="Theme"/>
    public partial class Theme
    {
        /// <inheritdoc />
        public Task<IImageUploadResponse> UploadBrandThemeLogoAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default)
            => GetClient().Brands.UploadBrandThemeLogoAsync(file, brandId, themeId, cancellationToken);

        /// <inheritdoc />
        public Task<IImageUploadResponse> UpdateBrandThemeFaviconAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default)
            => GetClient().Brands.UploadBrandThemeFaviconAsync(file, brandId, themeId, cancellationToken);

        /// <inheritdoc />
        public Task<IImageUploadResponse> UpdateBrandThemeBackgroundImageAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default)
            => GetClient().Brands.UploadBrandThemeBackgroundImageAsync(file, brandId, themeId, cancellationToken);
    }
}
