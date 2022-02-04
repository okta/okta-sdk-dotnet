// <copyright file="TrustedOriginsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class TrustedOriginsClient : OktaClient, ITrustedOriginsClient
    {
        // Remove parameterless constructor
        private TrustedOriginsClient()
        {
        }

        internal TrustedOriginsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<ITrustedOrigin> ActivateOriginAsync(string trustedOriginId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<TrustedOrigin>(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins/{trustedOriginId}/lifecycle/activate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["trustedOriginId"] = trustedOriginId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<ITrustedOrigin> CreateOriginAsync(ITrustedOrigin body,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<TrustedOrigin>(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins",
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
        public async Task<ITrustedOrigin> DeactivateOriginAsync(string trustedOriginId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<TrustedOrigin>(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins/{trustedOriginId}/lifecycle/deactivate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["trustedOriginId"] = trustedOriginId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteOriginAsync(string trustedOriginId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins/{trustedOriginId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["trustedOriginId"] = trustedOriginId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<ITrustedOrigin> GetOriginAsync(string trustedOriginId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<TrustedOrigin>(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins/{trustedOriginId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["trustedOriginId"] = trustedOriginId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<ITrustedOrigin>ListOrigins(string q = null, string filter = null, string after = null, int? limit = null)
        
        => GetCollectionClient<ITrustedOrigin>(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["q"] = q,
                ["filter"] = filter,
                ["after"] = after,
                ["limit"] = limit,
            },
        });
            
        
        /// <inheritdoc />
        public async Task<ITrustedOrigin> UpdateOriginAsync(ITrustedOrigin body, string trustedOriginId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PutAsync<TrustedOrigin>(new HttpRequest
        {
            Uri = "/api/v1/trustedOrigins/{trustedOriginId}",
            Verb = HttpVerb.PUT,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["trustedOriginId"] = trustedOriginId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
