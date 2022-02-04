// <copyright file="InlineHooksClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class InlineHooksClient : OktaClient, IInlineHooksClient
    {
        // Remove parameterless constructor
        private InlineHooksClient()
        {
        }

        internal InlineHooksClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IInlineHook> ActivateInlineHookAsync(string inlineHookId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<InlineHook>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks/{inlineHookId}/lifecycle/activate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["inlineHookId"] = inlineHookId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IInlineHook> CreateInlineHookAsync(IInlineHook body,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<InlineHook>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks",
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
        public async Task<IInlineHook> DeactivateInlineHookAsync(string inlineHookId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<InlineHook>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks/{inlineHookId}/lifecycle/deactivate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["inlineHookId"] = inlineHookId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteInlineHookAsync(string inlineHookId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks/{inlineHookId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["inlineHookId"] = inlineHookId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IInlineHookResponse> ExecuteInlineHookAsync(IInlineHookPayload body, string inlineHookId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<InlineHookResponse>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks/{inlineHookId}/execute",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["inlineHookId"] = inlineHookId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IInlineHook> GetInlineHookAsync(string inlineHookId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<InlineHook>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks/{inlineHookId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["inlineHookId"] = inlineHookId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<IInlineHook>ListInlineHooks(string type = null)
        
        => GetCollectionClient<IInlineHook>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["type"] = type,
            },
        });
            
        
        /// <inheritdoc />
        public async Task<IInlineHook> UpdateInlineHookAsync(IInlineHook body, string inlineHookId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PutAsync<InlineHook>(new HttpRequest
        {
            Uri = "/api/v1/inlineHooks/{inlineHookId}",
            Verb = HttpVerb.PUT,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["inlineHookId"] = inlineHookId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
