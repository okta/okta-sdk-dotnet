// <copyright file="OrgSetting.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OrgSetting : Resource, IOrgSetting
    {
        /// <inheritdoc/>
        public string Address1 
        {
            get => GetStringProperty("address1");
            set => this["address1"] = value;
        }
        
        /// <inheritdoc/>
        public string Address2 
        {
            get => GetStringProperty("address2");
            set => this["address2"] = value;
        }
        
        /// <inheritdoc/>
        public string City 
        {
            get => GetStringProperty("city");
            set => this["city"] = value;
        }
        
        /// <inheritdoc/>
        public string CompanyName 
        {
            get => GetStringProperty("companyName");
            set => this["companyName"] = value;
        }
        
        /// <inheritdoc/>
        public string Country 
        {
            get => GetStringProperty("country");
            set => this["country"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string EndUserSupportHelpUrl 
        {
            get => GetStringProperty("endUserSupportHelpURL");
            set => this["endUserSupportHelpURL"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? ExpiresAt => GetDateTimeProperty("expiresAt");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string PhoneNumber 
        {
            get => GetStringProperty("phoneNumber");
            set => this["phoneNumber"] = value;
        }
        
        /// <inheritdoc/>
        public string PostalCode 
        {
            get => GetStringProperty("postalCode");
            set => this["postalCode"] = value;
        }
        
        /// <inheritdoc/>
        public string State 
        {
            get => GetStringProperty("state");
            set => this["state"] = value;
        }
        
        /// <inheritdoc/>
        public string Status => GetStringProperty("status");
        
        /// <inheritdoc/>
        public string Subdomain => GetStringProperty("subdomain");
        
        /// <inheritdoc/>
        public string SupportPhoneNumber 
        {
            get => GetStringProperty("supportPhoneNumber");
            set => this["supportPhoneNumber"] = value;
        }
        
        /// <inheritdoc/>
        public string Website 
        {
            get => GetStringProperty("website");
            set => this["website"] = value;
        }
        
        /// <inheritdoc />
        public Task<IOrgSetting> PartialUpdateAsync(IOrgSetting orgSetting, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.PartialUpdateOrgSettingAsync(orgSetting, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOrgContactTypeObj> GetContactTypes(
            )
            => GetClient().Orgs.GetOrgContactTypes();
        
        /// <inheritdoc />
        public Task<IOrgContactUser> GetOrgContactUserAsync(
            string contactType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.GetOrgContactUserAsync(contactType, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgOktaSupportSettingsObj> GetSupportSettingsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.GetOrgOktaSupportSettingsAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgOktaCommunicationSetting> CommunicationSettingsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.GetOktaCommunicationSettingsAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgPreferences> OrgPreferencesAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.GetOrgPreferencesAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgPreferences> ShowFooterAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.ShowOktaUiFooterAsync(cancellationToken);
        
        /// <inheritdoc />
        public Task<IOrgPreferences> HideFooterAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Orgs.HideOktaUiFooterAsync(cancellationToken);
        
    }
}
