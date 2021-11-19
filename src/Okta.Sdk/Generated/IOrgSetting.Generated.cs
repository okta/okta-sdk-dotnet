// <copyright file="IOrgSetting.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a OrgSetting resource in the Okta API.</summary>
    public partial interface IOrgSetting : IResource
    {
        string Address1 { get; set; }

        string Address2 { get; set; }

        string City { get; set; }

        string CompanyName { get; set; }

        string Country { get; set; }

        DateTimeOffset? Created { get; }

        string EndUserSupportHelpUrl { get; set; }

        DateTimeOffset? ExpiresAt { get; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string PhoneNumber { get; set; }

        string PostalCode { get; set; }

        string State { get; set; }

        string Status { get; }

        string Subdomain { get; }

        string SupportPhoneNumber { get; set; }

        string Website { get; set; }

        Task<IOrgSetting> PartialUpdateAsync(IOrgSetting orgSetting, 
            CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOrgContactTypeObj> GetContactTypes(
            );

        Task<IOrgContactUser> GetOrgContactUserAsync(
            string contactType, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOrgOktaSupportSettingsObj> GetSupportSettingsAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IOrgOktaCommunicationSetting> CommunicationSettingsAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IOrgPreferences> OrgPreferencesAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IOrgPreferences> ShowFooterAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IOrgPreferences> HideFooterAsync(
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
