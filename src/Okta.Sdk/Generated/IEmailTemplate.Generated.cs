// <copyright file="IEmailTemplate.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a EmailTemplate resource in the Okta API.</summary>
    public partial interface IEmailTemplate : IResource
    {
        string Name { get; }

        Task<IEmailTemplate> GetEmailTemplateAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteEmailTemplateCustomizationsAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IEmailTemplateCustomization> ListEmailTemplateCustomizations(
            string brandId, string templateName);

        Task<IEmailTemplateCustomization> CreateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, 
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteEmailTemplateCustomizationAsync(
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEmailTemplateCustomization> GetEmailTemplateCustomizationAsync(
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEmailTemplateCustomization> UpdateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, 
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEmailTemplateContent> GetEmailTemplateCustomizationPreviewAsync(
            string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEmailTemplateContent> GetEmailTemplateDefaultContentAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEmailTemplateContent> GetEmailTemplateDefaultContentPreviewAsync(
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        Task SendTestEmailAsync(IEmailTemplateTestRequest customization, 
            string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

    }
}
