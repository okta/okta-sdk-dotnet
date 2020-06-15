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
        public ICollectionClient<IInlineHook> ListInlineHooks(string type = null)
            => GetCollectionClient<IInlineHook>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks",
                Verb = HttpVerb.Get,
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["type"] = type,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IInlineHook> CreateInlineHookAsync(IInlineHook inlineHook, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<InlineHook>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks",
                Verb = HttpVerb.Post,
                Payload = inlineHook,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks/{inlineHookId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["inlineHookId"] = inlineHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IInlineHook> GetInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<InlineHook>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks/{inlineHookId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["inlineHookId"] = inlineHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IInlineHook> UpdateInlineHookAsync(IInlineHook inlineHook, string inlineHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<InlineHook>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks/{inlineHookId}",
                Verb = HttpVerb.Put,
                Payload = inlineHook,
                PathParameters = new Dictionary<string, object>()
                {
                    ["inlineHookId"] = inlineHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IInlineHookResponse> ExecuteInlineHookAsync(IInlineHookPayload payloadData, string inlineHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<InlineHookResponse>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks/{inlineHookId}/execute",
                Verb = HttpVerb.Post,
                Payload = payloadData,
                PathParameters = new Dictionary<string, object>()
                {
                    ["inlineHookId"] = inlineHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IInlineHook> ActivateInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<InlineHook>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks/{inlineHookId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["inlineHookId"] = inlineHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IInlineHook> DeactivateInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<InlineHook>(new HttpRequest
            {
                Uri = "/api/v1/inlineHooks/{inlineHookId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["inlineHookId"] = inlineHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
