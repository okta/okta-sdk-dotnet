// <copyright file="BrandScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class BrandScenarios
    {
        [Fact]
        public async Task UpdateBrand()
        {
            var client = TestClient.Create();

            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();
            var originalCustomPrivacyPolicyUrl = brand.CustomPrivacyPolicyUrl;

            brand.CustomPrivacyPolicyUrl = "https://www.someHost.com/privacy-policy";
            brand.AgreeToCustomPrivacyPolicy = true;

            try
            {
                var updatedBrand = await client.Brands.UpdateBrandAsync(brand, brand.Id);
                updatedBrand.Id.Should().Be(brand.Id);
                updatedBrand.CustomPrivacyPolicyUrl.Should().Be(brand.CustomPrivacyPolicyUrl);
            }
            finally
            {
                brand.CustomPrivacyPolicyUrl = originalCustomPrivacyPolicyUrl;
                await client.Brands.UpdateBrandAsync(brand, brand.Id);
            }
        }

        [Fact]
        public async Task ListBrands()
        {
            var client = TestClient.Create();

            var brands = await client.Brands.ListBrands().ToListAsync();

            brands.Should().NotBeNullOrEmpty();
            brands.First().Id.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetBrand()
        {
            var client = TestClient.Create();

            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();

            var retrievedBrand = await client.Brands.GetBrandAsync(brand.Id);

            retrievedBrand.Id.Should().Be(brand.Id);
            retrievedBrand.CustomPrivacyPolicyUrl.Should().Be(brand.CustomPrivacyPolicyUrl);
            retrievedBrand.RemovePoweredByOkta.Should().Be(brand.RemovePoweredByOkta);
        }

        [Fact]
        public async Task GetBrandThemes()
        {
            var client = TestClient.Create();

            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();

            var themes = await client.Brands.ListBrandThemes(brand.Id).ToListAsync();
            themes.Should().NotBeNullOrEmpty();
            themes.First().Id.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetBrandTheme()
        {
            var client = TestClient.Create();

            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();

            var theme = await client.Brands.ListBrandThemes(brand.Id).FirstOrDefaultAsync();

            var retrievedTheme = await client.Brands.GetBrandThemeAsync(brand.Id, theme.Id);
            retrievedTheme.Id.Should().Be(theme.Id);
            retrievedTheme.BackgroundImage.Should().Be(theme.BackgroundImage);
            retrievedTheme.EmailTemplateTouchPointVariant.Should().Be(theme.EmailTemplateTouchPointVariant);
            retrievedTheme.EndUserDashboardTouchPointVariant.Should().Be(theme.EndUserDashboardTouchPointVariant);
            retrievedTheme.ErrorPageTouchPointVariant.Should().Be(theme.ErrorPageTouchPointVariant);
            retrievedTheme.Favicon.Should().Be(theme.Favicon);
            retrievedTheme.Logo.Should().Be(theme.Logo);
            retrievedTheme.PrimaryColorContrastHex.Should().Be(theme.PrimaryColorContrastHex);
            retrievedTheme.PrimaryColorHex.Should().Be(theme.PrimaryColorHex);
            retrievedTheme.SecondaryColorContrastHex.Should().Be(theme.SecondaryColorContrastHex);
            retrievedTheme.SecondaryColorHex.Should().Be(theme.SecondaryColorHex);
            retrievedTheme.SignInPageTouchPointVariant.Should().Be(theme.SignInPageTouchPointVariant);
        }

        [Fact]
        public async Task UpdateBrandTheme()
        {
            var client = TestClient.Create();

            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();

            var theme = await client.Brands.ListBrandThemes(brand.Id).FirstOrDefaultAsync();

            var originalPrimaryColorHex = theme.PrimaryColorHex;
            var originalSecondaryColorHex = theme.SecondaryColorHex;
            var originalSignInPageTouchPointVariant = theme.SignInPageTouchPointVariant;
            var originalEndUserDashboardTouchPointVariant = theme.EndUserDashboardTouchPointVariant;
            var originalErrorPageTouchPointVariant = theme.ErrorPageTouchPointVariant;
            var originalEmailTemplateTouchPointVariant = theme.EmailTemplateTouchPointVariant;

            var themeToUpdate = new Theme
            {
                PrimaryColorHex = "#1662dd",
                SecondaryColorHex = "#ebebed",
                SignInPageTouchPointVariant = SignInPageTouchPointVariant.OktaDefault,
                EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.OktaDefault,
                ErrorPageTouchPointVariant = ErrorPageTouchPointVariant.OktaDefault,
                EmailTemplateTouchPointVariant = EmailTemplateTouchPointVariant.OktaDefault,
            };

            try
            {
                var updatedTheme = await client.Brands.UpdateBrandThemeAsync(themeToUpdate, brand.Id, theme.Id);

                updatedTheme.Id.Should().Be(theme.Id);
                updatedTheme.PrimaryColorHex.Should().Be(themeToUpdate.PrimaryColorHex);
                updatedTheme.SecondaryColorHex.Should().Be(themeToUpdate.SecondaryColorHex);
                updatedTheme.SignInPageTouchPointVariant.Should().Be(themeToUpdate.SignInPageTouchPointVariant);
                updatedTheme.EndUserDashboardTouchPointVariant.Should().Be(themeToUpdate.EndUserDashboardTouchPointVariant);
                updatedTheme.ErrorPageTouchPointVariant.Should().Be(themeToUpdate.ErrorPageTouchPointVariant);
                updatedTheme.EmailTemplateTouchPointVariant.Should().Be(themeToUpdate.EmailTemplateTouchPointVariant);
            }
            finally
            {
                themeToUpdate.PrimaryColorHex = originalPrimaryColorHex;
                themeToUpdate.SecondaryColorHex = originalSecondaryColorHex;
                themeToUpdate.SignInPageTouchPointVariant = originalSignInPageTouchPointVariant;
                themeToUpdate.EndUserDashboardTouchPointVariant = originalEndUserDashboardTouchPointVariant;
                themeToUpdate.ErrorPageTouchPointVariant = originalErrorPageTouchPointVariant;
                themeToUpdate.EmailTemplateTouchPointVariant = originalEmailTemplateTouchPointVariant;
                await client.Brands.UpdateBrandThemeAsync(themeToUpdate, brand.Id, theme.Id);
            }
        }

        [Fact]
        public async Task ListEmailTemplates()
        {
            var client = TestClient.Create();
            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();

            var emailTemplate = await client.Brands.ListEmailTemplates(brand.Id).FirstOrDefaultAsync();

            emailTemplate.Should().NotBeNull();
            emailTemplate.Name.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetEmailTemplate()
        {
            var client = TestClient.Create();
            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();
            var emailTemplate = await client.Brands.ListEmailTemplates(brand.Id).FirstOrDefaultAsync();

            var retrievedEmailTemplate = await client.Brands.GetEmailTemplateAsync(brand.Id, emailTemplate.Name);

            retrievedEmailTemplate.Should().NotBeNull();
            retrievedEmailTemplate.Name.Should().Be(emailTemplate.Name);
        }

        [Fact]
        public async Task ListEmailTemplateCustomizations()
        {
            var client = TestClient.Create();
            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();
            var emailTemplate = await client.Brands.ListEmailTemplates(brand.Id).FirstOrDefaultAsync();

            var emailTemplateCustomizations = await client.Brands.ListEmailTemplateCustomizations(brand.Id, emailTemplate.Name).ToArrayAsync();

            emailTemplateCustomizations.Should().NotBeNull();
        }

        [Fact]
        public async Task GetEmailTemplateDefaultContent()
        {
            var client = TestClient.Create();
            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();
            var emailTemplate = await client.Brands.ListEmailTemplates(brand.Id).FirstOrDefaultAsync();

            var emailTemplateCustomizationContent = await client.Brands.GetEmailTemplateDefaultContentAsync(brand.Id, emailTemplate.Name);
            emailTemplateCustomizationContent.Should().NotBeNull();
        }

        [Fact]
        public async Task GetEmailTemplateDefaultContentPreview()
        {
            var client = TestClient.Create();
            var brand = await client.Brands.ListBrands().FirstOrDefaultAsync();
            var emailTemplate = await client.Brands.ListEmailTemplates(brand.Id).FirstOrDefaultAsync();

            var emailTemplateCustomizationPreview = await client.Brands.GetEmailTemplateDefaultContentPreviewAsync(brand.Id, emailTemplate.Name);
            emailTemplateCustomizationPreview.Should().NotBeNull();
        }
    }
}
