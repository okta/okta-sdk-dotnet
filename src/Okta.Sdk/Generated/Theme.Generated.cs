// <copyright file="Theme.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Theme : Resource, ITheme
    {
        /// <inheritdoc/>
        public string BackgroundImage => GetStringProperty("backgroundImage");
        
        /// <inheritdoc/>
        public EmailTemplateTouchPointVariant EmailTemplateTouchPointVariant 
        {
            get => GetEnumProperty<EmailTemplateTouchPointVariant>("emailTemplateTouchPointVariant");
            set => this["emailTemplateTouchPointVariant"] = value;
        }
        
        /// <inheritdoc/>
        public EndUserDashboardTouchPointVariant EndUserDashboardTouchPointVariant 
        {
            get => GetEnumProperty<EndUserDashboardTouchPointVariant>("endUserDashboardTouchPointVariant");
            set => this["endUserDashboardTouchPointVariant"] = value;
        }
        
        /// <inheritdoc/>
        public ErrorPageTouchPointVariant ErrorPageTouchPointVariant 
        {
            get => GetEnumProperty<ErrorPageTouchPointVariant>("errorPageTouchPointVariant");
            set => this["errorPageTouchPointVariant"] = value;
        }
        
        /// <inheritdoc/>
        public string PrimaryColorContrastHex 
        {
            get => GetStringProperty("primaryColorContrastHex");
            set => this["primaryColorContrastHex"] = value;
        }
        
        /// <inheritdoc/>
        public string PrimaryColorHex 
        {
            get => GetStringProperty("primaryColorHex");
            set => this["primaryColorHex"] = value;
        }
        
        /// <inheritdoc/>
        public string SecondaryColorContrastHex 
        {
            get => GetStringProperty("secondaryColorContrastHex");
            set => this["secondaryColorContrastHex"] = value;
        }
        
        /// <inheritdoc/>
        public string SecondaryColorHex 
        {
            get => GetStringProperty("secondaryColorHex");
            set => this["secondaryColorHex"] = value;
        }
        
        /// <inheritdoc/>
        public SignInPageTouchPointVariant SignInPageTouchPointVariant 
        {
            get => GetEnumProperty<SignInPageTouchPointVariant>("signInPageTouchPointVariant");
            set => this["signInPageTouchPointVariant"] = value;
        }
        
        /// <inheritdoc />
        public Task DeleteBrandThemeLogoAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.DeleteBrandThemeLogoAsync(brandId, themeId, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteBrandThemeFaviconAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.DeleteBrandThemeFaviconAsync(brandId, themeId, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteBrandThemeBackgroundImageAsync(
            string brandId, string themeId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Brands.DeleteBrandThemeBackgroundImageAsync(brandId, themeId, cancellationToken);
        
    }
}
