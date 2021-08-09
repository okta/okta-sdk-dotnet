// <copyright file="EventHooksClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class EventHooksClient : OktaClient, IEventHooksClient
    {
        // Remove parameterless constructor
        private EventHooksClient()
        {
        }

        internal EventHooksClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IEventHook> ListEventHooks()
            => GetCollectionClient<IEventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks",
                Verb = HttpVerb.Get,
                
            });
                    
        /// <inheritdoc />
        public async Task<IEventHook> CreateEventHookAsync(IEventHook eventHook, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<EventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks",
                Verb = HttpVerb.Post,
                Payload = eventHook,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEventHook> GetEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<EventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks/{eventHookId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["eventHookId"] = eventHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEventHook> UpdateEventHookAsync(IEventHook eventHook, string eventHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<EventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks/{eventHookId}",
                Verb = HttpVerb.Put,
                Payload = eventHook,
                PathParameters = new Dictionary<string, object>()
                {
                    ["eventHookId"] = eventHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/eventHooks/{eventHookId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["eventHookId"] = eventHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEventHook> ActivateEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<EventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks/{eventHookId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["eventHookId"] = eventHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEventHook> DeactivateEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<EventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks/{eventHookId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["eventHookId"] = eventHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IEventHook> VerifyEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<EventHook>(new HttpRequest
            {
                Uri = "/api/v1/eventHooks/{eventHookId}/lifecycle/verify",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["eventHookId"] = eventHookId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
