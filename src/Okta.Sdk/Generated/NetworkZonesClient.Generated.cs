// <copyright file="NetworkZonesClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class NetworkZonesClient : OktaClient, INetworkZonesClient
    {
        // Remove parameterless constructor
        private NetworkZonesClient()
        {
        }

        internal NetworkZonesClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<INetworkZone> ActivateNetworkZoneAsync(string zoneId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<NetworkZone>(new HttpRequest
        {
            Uri = "/api/v1/zones/{zoneId}/lifecycle/activate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["zoneId"] = zoneId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<INetworkZone> CreateNetworkZoneAsync(INetworkZone body,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<NetworkZone>(new HttpRequest
        {
            Uri = "/api/v1/zones",
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
        public async Task<INetworkZone> DeactivateNetworkZoneAsync(string zoneId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<NetworkZone>(new HttpRequest
        {
            Uri = "/api/v1/zones/{zoneId}/lifecycle/deactivate",
            Verb = HttpVerb.POST,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["zoneId"] = zoneId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteNetworkZoneAsync(string zoneId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/zones/{zoneId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["zoneId"] = zoneId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<INetworkZone> GetNetworkZoneAsync(string zoneId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<NetworkZone>(new HttpRequest
        {
            Uri = "/api/v1/zones/{zoneId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["zoneId"] = zoneId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<INetworkZone>ListNetworkZones(string after = null, int? limit = null, string filter = null)
        
        => GetCollectionClient<INetworkZone>(new HttpRequest
        {
            Uri = "/api/v1/zones",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["after"] = after,
                ["limit"] = limit,
                ["filter"] = filter,
            },
        });
            
        
        /// <inheritdoc />
        public async Task<INetworkZone> UpdateNetworkZoneAsync(INetworkZone body, string zoneId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PutAsync<NetworkZone>(new HttpRequest
        {
            Uri = "/api/v1/zones/{zoneId}",
            Verb = HttpVerb.PUT,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["zoneId"] = zoneId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
