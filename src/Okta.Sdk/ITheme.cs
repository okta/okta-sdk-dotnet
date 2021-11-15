using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface ITheme
    {
        /// <summary>
        /// Updates the logo for your Theme
        /// </summary>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UploadBrandThemeLogoAsync(FileStream file,
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the Favicon for your Theme
        /// </summary>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UpdateBrandThemeFaviconAsync(FileStream file,
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the background image for your Theme
        /// </summary>
        /// <returns>A <see cref="IImageUploadResponse"/></returns>
        Task<IImageUploadResponse> UpdateBrandThemeBackgroundImageAsync(FileStream file,
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
