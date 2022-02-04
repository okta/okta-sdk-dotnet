// <copyright file="OrgsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OrgsClient : OktaClient, IOrgsClient
    {
        // Remove parameterless constructor
        private OrgsClient()
        {
        }

        internal OrgsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IOrgSetting> GetOrgSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OrgSetting>(new HttpRequest
            {
                Uri = "/api/v1/org",
                Verb = HttpVerb.GET,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgSetting> PartialUpdateOrgSettingAsync(IOrgSetting orgSetting, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgSetting>(new HttpRequest
            {
                Uri = "/api/v1/org",
                Verb = HttpVerb.POST,
                Payload = orgSetting,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgSetting> UpdateOrgSettingAsync(IOrgSetting orgSetting, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<OrgSetting>(new HttpRequest
            {
                Uri = "/api/v1/org",
                Verb = HttpVerb.PUT,
                Payload = orgSetting,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOrgContactTypeObj> GetOrgContactTypes()
            => GetCollectionClient<IOrgContactTypeObj>(new HttpRequest
            {
                Uri = "/api/v1/org/contacts",
                Verb = HttpVerb.GET,
                
            });
                    
        /// <inheritdoc />
        public async Task<IOrgContactUser> GetOrgContactUserAsync(string contactType, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OrgContactUser>(new HttpRequest
            {
                Uri = "/api/v1/org/contacts/{contactType}",
                Verb = HttpVerb.GET,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["contactType"] = contactType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgContactUser> UpdateOrgContactUserAsync(IUserIdString userId, string contactType, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<OrgContactUser>(new HttpRequest
            {
                Uri = "/api/v1/org/contacts/{contactType}",
                Verb = HttpVerb.PUT,
                Payload = userId,
                PathParameters = new Dictionary<string, object>()
                {
                    ["contactType"] = contactType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgPreferences> GetOrgPreferencesAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OrgPreferences>(new HttpRequest
            {
                Uri = "/api/v1/org/preferences",
                Verb = HttpVerb.GET,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgPreferences> HideOktaUiFooterAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgPreferences>(new HttpRequest
            {
                Uri = "/api/v1/org/preferences/hideEndUserFooter",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgPreferences> ShowOktaUiFooterAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgPreferences>(new HttpRequest
            {
                Uri = "/api/v1/org/preferences/showEndUserFooter",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaCommunicationSetting> GetOktaCommunicationSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OrgOktaCommunicationSetting>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaCommunication",
                Verb = HttpVerb.GET,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaCommunicationSetting> OptInUsersToOktaCommunicationEmailsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgOktaCommunicationSetting>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaCommunication/optIn",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaCommunicationSetting> OptOutUsersFromOktaCommunicationEmailsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgOktaCommunicationSetting>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaCommunication/optOut",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaSupportSettingsObj> GetOrgOktaSupportSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OrgOktaSupportSettingsObj>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaSupport",
                Verb = HttpVerb.GET,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaSupportSettingsObj> ExtendOktaSupportAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgOktaSupportSettingsObj>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaSupport/extend",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaSupportSettingsObj> GrantOktaSupportAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgOktaSupportSettingsObj>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaSupport/grant",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOrgOktaSupportSettingsObj> RevokeOktaSupportAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OrgOktaSupportSettingsObj>(new HttpRequest
            {
                Uri = "/api/v1/org/privacy/oktaSupport/revoke",
                Verb = HttpVerb.POST,
                
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
