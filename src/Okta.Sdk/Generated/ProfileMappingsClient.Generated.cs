// <copyright file="ProfileMappingsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ProfileMappingsClient : OktaClient, IProfileMappingsClient
    {
        // Remove parameterless constructor
        private ProfileMappingsClient()
        {
        }

        internal ProfileMappingsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IProfileMapping> GetProfileMappingAsync(string mappingId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<ProfileMapping>(new HttpRequest
        {
            Uri = "/api/v1/mappings/{mappingId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["mappingId"] = mappingId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<IProfileMapping>ListProfileMappings(string after = null, int? limit = null, string sourceId = null, string targetId = null)
        
        => GetCollectionClient<IProfileMapping>(new HttpRequest
        {
            Uri = "/api/v1/mappings",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["after"] = after,
                ["limit"] = limit,
                ["sourceId"] = sourceId,
                ["targetId"] = targetId,
            },
        });
            
        
        /// <inheritdoc />
        public async Task<IProfileMapping> UpdateProfileMappingAsync(IProfileMapping body, string mappingId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<ProfileMapping>(new HttpRequest
        {
            Uri = "/api/v1/mappings/{mappingId}",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["mappingId"] = mappingId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
