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
        public async Task<ISmsTemplate> CreateSmsTemplateAsync(ISmsTemplate body,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<SmsTemplate>(new HttpRequest
        {
            Uri = "/api/v1/templates/sms",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteSmsTemplateAsync(string templateId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/templates/sms/{templateId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["templateId"] = templateId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<ISmsTemplate> GetSmsTemplateAsync(string templateId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<SmsTemplate>(new HttpRequest
        {
            Uri = "/api/v1/templates/sms/{templateId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["templateId"] = templateId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<ISmsTemplate>ListSmsTemplates(string templateType = null)
        
        => GetCollectionClient<ISmsTemplate>(new HttpRequest
        {
            Uri = "/api/v1/templates/sms",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["templateType"] = templateType,
            },
        });
            
        
        /// <inheritdoc />
        public async Task<ISmsTemplate> PartialUpdateSmsTemplateAsync(ISmsTemplate body, string templateId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<SmsTemplate>(new HttpRequest
        {
            Uri = "/api/v1/templates/sms/{templateId}",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["templateId"] = templateId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<ISmsTemplate> UpdateSmsTemplateAsync(ISmsTemplate body, string templateId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PutAsync<SmsTemplate>(new HttpRequest
        {
            Uri = "/api/v1/templates/sms/{templateId}",
            Verb = HttpVerb.PUT,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["templateId"] = templateId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
