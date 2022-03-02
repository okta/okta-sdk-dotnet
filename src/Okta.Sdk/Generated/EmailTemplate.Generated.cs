// <copyright file="EmailTemplate.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class EmailTemplate : Resource, IEmailTemplate
    {
        /// <inheritdoc/>
        public string Name => GetStringProperty("name");
        
        /// <inheritdoc />
        public Task<IEmailTemplate> GetEmailTemplateAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.GetEmailTemplateAsync(brandId, templateName, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteEmailTemplateCustomizationsAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.DeleteEmailTemplateCustomizationsAsync(brandId, templateName, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IEmailTemplateCustomization> ListEmailTemplateCustomizations(
            string brandId, string templateName)
            => GetClient().Brands.ListEmailTemplateCustomizations(brandId, templateName);
        
        /// <inheritdoc />
        public Task<IEmailTemplateCustomization> CreateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, 
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.CreateEmailTemplateCustomizationAsync(customization, brandId, templateName, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteEmailTemplateCustomizationAsync(
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.DeleteEmailTemplateCustomizationAsync(brandId, templateName, customizationId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEmailTemplateCustomization> GetEmailTemplateCustomizationAsync(
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.GetEmailTemplateCustomizationAsync(brandId, templateName, customizationId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEmailTemplateCustomization> UpdateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, 
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.UpdateEmailTemplateCustomizationAsync(customization, brandId, templateName, customizationId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEmailTemplateContent> GetEmailTemplateCustomizationPreviewAsync(
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.GetEmailTemplateCustomizationPreviewAsync(brandId, templateName, customizationId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEmailTemplateContent> GetEmailTemplateDefaultContentAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.GetEmailTemplateDefaultContentAsync(brandId, templateName, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEmailTemplateContent> GetEmailTemplateDefaultContentPreviewAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.GetEmailTemplateDefaultContentPreviewAsync(brandId, templateName, cancellationToken);
        
        /// <inheritdoc />
        public Task SendTestEmailAsync(IEmailTemplateTestRequest customization, 
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.SendTestEmailAsync(customization, brandId, templateName, cancellationToken);
        
    }
}
