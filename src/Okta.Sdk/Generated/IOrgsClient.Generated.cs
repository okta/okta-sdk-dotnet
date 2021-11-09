// <copyright file="IOrgsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta Org resources.</summary>
    public partial interface IOrgsClient
    {
        /// <summary>
        /// Get settings of your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgSetting"/> response.</returns>
        Task<IOrgSetting> GetOrgSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Partial update settings of your organization.
        /// </summary>
        /// <param name="orgSetting">The <see cref="IOrgSetting"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgSetting"/> response.</returns>
        Task<IOrgSetting> PartialUpdateOrgSettingAsync(IOrgSetting orgSetting, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update settings of your organization.
        /// </summary>
        /// <param name="orgSetting">The <see cref="IOrgSetting"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgSetting"/> response.</returns>
        Task<IOrgSetting> UpdateOrgSettingAsync(IOrgSetting orgSetting, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Contact Types of your organization.
        /// </summary>
        /// <returns>A collection of <see cref="IOrgContactTypeObj"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOrgContactTypeObj> GetOrgContactTypes();

        /// <summary>
        /// Retrieves the URL of the User associated with the specified Contact Type.
        /// </summary>
        /// <param name="contactType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgContactUser"/> response.</returns>
        Task<IOrgContactUser> GetOrgContactUserAsync(string contactType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the User associated with the specified Contact Type.
        /// </summary>
        /// <param name="userId">The <see cref="IUserIdString"/> resource.</param>
        /// <param name="contactType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgContactUser"/> response.</returns>
        Task<IOrgContactUser> UpdateOrgContactUserAsync(IUserIdString userId, string contactType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the logo for your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UpdateOrgLogoAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets preferences of your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgPreferences"/> response.</returns>
        Task<IOrgPreferences> GetOrgPreferencesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Hide the Okta UI footer for all end users of your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgPreferences"/> response.</returns>
        Task<IOrgPreferences> HideOktaUiFooterAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Makes the Okta UI footer visible for all end users of your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgPreferences"/> response.</returns>
        Task<IOrgPreferences> ShowOktaUiFooterAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Okta Communication Settings of your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaCommunicationSetting"/> response.</returns>
        Task<IOrgOktaCommunicationSetting> GetOktaCommunicationSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Opts in all users of this org to Okta Communication emails.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaCommunicationSetting"/> response.</returns>
        Task<IOrgOktaCommunicationSetting> OptInUsersToOktaCommunicationEmailsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Opts out all users of this org from Okta Communication emails.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaCommunicationSetting"/> response.</returns>
        Task<IOrgOktaCommunicationSetting> OptOutUsersFromOktaCommunicationEmailsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Okta Support Settings of your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaSupportSettingsObj"/> response.</returns>
        Task<IOrgOktaSupportSettingsObj> GetOrgOktaSupportSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Extends the length of time that Okta Support can access your org by 24 hours. This means that 24 hours are added to the remaining access time.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaSupportSettingsObj"/> response.</returns>
        Task<IOrgOktaSupportSettingsObj> ExtendOktaSupportAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enables you to temporarily allow Okta Support to access your org as an administrator for eight hours.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaSupportSettingsObj"/> response.</returns>
        Task<IOrgOktaSupportSettingsObj> GrantOktaSupportAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revokes Okta Support access to your organization.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOrgOktaSupportSettingsObj"/> response.</returns>
        Task<IOrgOktaSupportSettingsObj> RevokeOktaSupportAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
