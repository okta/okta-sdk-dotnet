// <copyright file="TemplatesClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class TemplatesClient : OktaClient, ITemplatesClient
    {
        // Remove parameterless constructor
        private TemplatesClient()
        {
        }

        internal TemplatesClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<ISmsTemplate> ListSmsTemplates(SmsTemplateType templateType = null)
            => GetCollectionClient<ISmsTemplate>(new HttpRequest
            {
                Uri = "/api/v1/templates/sms",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["templateType"] = templateType,
                },
            });
                    
        /// <inheritdoc />
        public async Task<ISmsTemplate> CreateSmsTemplateAsync(ISmsTemplate smsTemplate, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<SmsTemplate>(new HttpRequest
            {
                Uri = "/api/v1/templates/sms",
                Payload = smsTemplate,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteSmsTemplateAsync(string templateId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/templates/sms/{templateId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["templateId"] = templateId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ISmsTemplate> GetSmsTemplateAsync(string templateId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<SmsTemplate>(new HttpRequest
            {
                Uri = "/api/v1/templates/sms/{templateId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["templateId"] = templateId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ISmsTemplate> PartialUpdateSmsTemplateAsync(ISmsTemplate smsTemplate, string templateId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<SmsTemplate>(new HttpRequest
            {
                Uri = "/api/v1/templates/sms/{templateId}",
                Payload = smsTemplate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["templateId"] = templateId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ISmsTemplate> UpdateSmsTemplateAsync(ISmsTemplate smsTemplate, string templateId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<SmsTemplate>(new HttpRequest
            {
                Uri = "/api/v1/templates/sms/{templateId}",
                Payload = smsTemplate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["templateId"] = templateId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
