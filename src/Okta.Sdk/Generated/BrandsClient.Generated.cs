// <copyright file="BrandsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class BrandsClient : OktaClient, IBrandsClient
    {
        // Remove parameterless constructor
        private BrandsClient()
        {
        }

        internal BrandsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IBrand> ListBrands()
            => GetCollectionClient<IBrand>(new HttpRequest
            {
                Uri = "/api/v1/brands",
                Verb = HttpVerb.Get,
                
            });
                    
        /// <inheritdoc />
        public async Task<IBrand> GetBrandAsync(string brandId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Brand>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IBrand> UpdateBrandAsync(IBrand brand, string brandId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<Brand>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}",
                Verb = HttpVerb.Put,
                Payload = brand,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IThemeResponse> ListBrandThemes(string brandId)
            => GetCollectionClient<IThemeResponse>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IThemeResponse> GetBrandThemeAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<ThemeResponse>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IThemeResponse> UpdateBrandThemeAsync(ITheme theme, string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<ThemeResponse>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}",
                Verb = HttpVerb.Put,
                Payload = theme,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteBrandThemeBackgroundImageAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/background-image",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IImageUploadResponse> UploadBrandThemeBackgroundImageAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ImageUploadResponse>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/background-image",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteBrandThemeFaviconAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/favicon",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IImageUploadResponse> UploadBrandThemeFaviconAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ImageUploadResponse>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/favicon",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteBrandThemeLogoAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/logo",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IImageUploadResponse> UploadBrandThemeLogoAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ImageUploadResponse>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/themes/{themeId}/logo",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["themeId"] = themeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
