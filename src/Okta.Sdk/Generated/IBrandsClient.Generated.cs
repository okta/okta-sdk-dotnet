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
        /// List email templates in your organization with pagination.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of email templates.</param>
        /// <param name="limit">Specifies the number of results returned (maximum 200)</param>
        /// <returns>A collection of <see cref="IEmailTemplate"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IEmailTemplate> ListEmailTemplates(string brandId, string after = null, int? limit = 20);

        /// <summary>
        /// Fetch an email template by templateName
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplate"/> response.</returns>
        Task<IEmailTemplate> GetEmailTemplateAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete all customizations for an email template. Also known as “Reset to Default”.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteEmailTemplateCustomizationsAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List all email customizations for an email template
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <returns>A collection of <see cref="IEmailTemplateCustomization"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IEmailTemplateCustomization> ListEmailTemplateCustomizations(string brandId, string templateName);

        /// <summary>
        /// Create an email customization
        /// </summary>
        /// <param name="customization">The <see cref="IEmailTemplateCustomizationRequest"/> resource.</param>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateCustomization"/> response.</returns>
        Task<IEmailTemplateCustomization> CreateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete an email customization
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="customizationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteEmailTemplateCustomizationAsync(string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch an email customization by id.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="customizationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateCustomization"/> response.</returns>
        Task<IEmailTemplateCustomization> GetEmailTemplateCustomizationAsync(string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an email customization
        /// </summary>
        /// <param name="customization">The <see cref="IEmailTemplateCustomizationRequest"/> resource.</param>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="customizationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateCustomization"/> response.</returns>
        Task<IEmailTemplateCustomization> UpdateEmailTemplateCustomizationAsync(IEmailTemplateCustomizationRequest customization, string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get a preview of an email template customization.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="customizationId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateContent"/> response.</returns>
        Task<IEmailTemplateContent> GetEmailTemplateCustomizationPreviewAsync(string brandId, string templateName, string customizationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch the default content for an email template.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateContent"/> response.</returns>
        Task<IEmailTemplateContent> GetEmailTemplateDefaultContentAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a preview of an email template's default content by populating velocity references with the current user's environment.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateContent"/> response.</returns>
        Task<IEmailTemplateContent> GetEmailTemplateDefaultContentPreviewAsync(string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Send a test email to the current users primary and secondary email addresses. The email content is selected based on the following priority: &mdash;  An email customization specifically for the users locale. &mdash;  The default language of email customizations. &mdash;  The email templates default content.
        /// </summary>
        /// <param name="customization">The <see cref="IEmailTemplateTestRequest"/> resource.</param>
        /// <param name="brandId"></param>
        /// <param name="templateName"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEmailTemplateContent"/> response.</returns>
        Task<IEmailTemplateContent> SendTestEmailAsync(IEmailTemplateTestRequest customization, string brandId, string templateName, CancellationToken cancellationToken = default(CancellationToken));

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
        /// Deletes a Theme favicon. The org then uses the Okta default favicon.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteBrandThemeFaviconAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a Theme logo. The org then uses the Okta default logo.
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="themeId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteBrandThemeLogoAsync(string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
