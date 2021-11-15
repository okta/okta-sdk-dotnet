using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IBrandsClient
    {
        /// <summary>
        /// Updates the logo for your Theme
        /// </summary>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeLogoAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the favicon for your Theme
        /// </summary>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeFaviconAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the background image for your Theme
        /// </summary>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeBackgroundImageAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default);
    }
}
