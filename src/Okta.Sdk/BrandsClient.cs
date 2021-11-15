// <copyright file="BrandsClient.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public sealed partial class BrandsClient : OktaClient, IBrandsClient
    {
        /// <inheritdoc />
        public async Task<IImageUploadResponse> UploadBrandThemeLogoAsync(FileStream file, string brandId, string themeId, CancellationToken cancellationToken = default)
        {
            byte[] fileBytes = new byte[file.Length];
            await file.ReadAsync(fileBytes, 0, (int)file.Length, cancellationToken).ConfigureAwait(false);

            var request = new MultipartHttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/logo",
                Payload = fileBytes,
                ContentType = "multipart/form-data",
                Verb = HttpVerb.Post,
                FileName = file.Name,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
            };

            return await PostAsync<ImageUploadResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IImageUploadResponse> UploadBrandThemeFaviconAsync(FileStream file, string brandId, string themeId,
            CancellationToken cancellationToken = default)
        {
            byte[] fileBytes = new byte[file.Length];
            await file.ReadAsync(fileBytes, 0, (int)file.Length, cancellationToken).ConfigureAwait(false);

            var request = new MultipartHttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/favicon",
                Payload = fileBytes,
                ContentType = "multipart/form-data",
                Verb = HttpVerb.Post,
                FileName = file.Name,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
            };

            return await PostAsync<ImageUploadResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IImageUploadResponse> UploadBrandThemeBackgroundImageAsync(FileStream file, string brandId, string themeId,
            CancellationToken cancellationToken = default)
        {
            byte[] fileBytes = new byte[file.Length];
            await file.ReadAsync(fileBytes, 0, (int)file.Length, cancellationToken).ConfigureAwait(false);

            var request = new MultipartHttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/background-image",
                Payload = fileBytes,
                ContentType = "multipart/form-data",
                Verb = HttpVerb.Post,
                FileName = file.Name,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
            };

            return await PostAsync<ImageUploadResponse>(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
