// <copyright file="SessionsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SessionsClient : OktaClient, ISessionsClient
    {
        // Remove parameterless constructor
        private SessionsClient()
        {
        }

        internal SessionsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<ISession> CreateSessionAsync(ICreateSessionRequest createSessionRequest, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Session>(new HttpRequest
            {
                Uri = "/api/v1/sessions",
                Payload = createSessionRequest,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task EndSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/sessions/{sessionId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["sessionId"] = sessionId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ISession> GetSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Session>(new HttpRequest
            {
                Uri = "/api/v1/sessions/{sessionId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["sessionId"] = sessionId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ISession> RefreshSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Session>(new HttpRequest
            {
                Uri = "/api/v1/sessions/{sessionId}/lifecycle/refresh",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["sessionId"] = sessionId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
