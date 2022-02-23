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
        public ICollectionClient<IEmailTemplate> ListEmailTemplates(string brandId, string after = null, int? limit = 20)
            => GetCollectionClient<IEmailTemplate>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IEmailTemplate> GetEmailTemplateAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<EmailTemplate>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteEmailTemplateCustomizationsAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IEmailTemplateCustomization> ListEmailTemplateCustomizations(string brandId, string templateName)
            => GetCollectionClient<IEmailTemplateCustomization>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IEmailTemplateCustomization> CreateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<EmailTemplateCustomization>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations",
                Verb = HttpVerb.Post,
                Payload = customization,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteEmailTemplateCustomizationAsync(string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                    ["customizationId"] = customizationId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEmailTemplateCustomization> GetEmailTemplateCustomizationAsync(string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<EmailTemplateCustomization>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                    ["customizationId"] = customizationId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEmailTemplateCustomization> UpdateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<EmailTemplateCustomization>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}",
                Verb = HttpVerb.Put,
                Payload = customization,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                    ["customizationId"] = customizationId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEmailTemplateContent> GetEmailTemplateCustomizationPreviewAsync(string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<EmailTemplateContent>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                    ["customizationId"] = customizationId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEmailTemplateContent> GetEmailTemplateDefaultContentAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<EmailTemplateContent>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/default-content",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEmailTemplateContent> GetEmailTemplateDefaultContentPreviewAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<EmailTemplateContent>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEmailTemplateContent> SendTestEmailAsync(IEmailTemplateTestRequest customization, string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<EmailTemplateContent>(new HttpRequest
            {
                Uri = "/api/v1/brands/{brandId}/templates/email/{templateName}/test",
                Verb = HttpVerb.Post,
                Payload = customization,
                PathParameters = new Dictionary<string, object>()
                {
                    ["brandId"] = brandId,
                    ["templateName"] = templateName,
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
        
    }
}
