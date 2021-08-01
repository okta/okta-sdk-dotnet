// <copyright file="ThreatInsightsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ThreatInsightsClient : OktaClient, IThreatInsightsClient
    {
        // Remove parameterless constructor
        private ThreatInsightsClient()
        {
        }

        internal ThreatInsightsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IThreatInsightConfiguration> GetCurrentConfigurationAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<ThreatInsightConfiguration>(new HttpRequest
            {
                Uri = "/api/v1/threats/configuration",
                Verb = HttpVerb.Get,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IThreatInsightConfiguration> UpdateConfigurationAsync(IThreatInsightConfiguration threatInsightConfiguration, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ThreatInsightConfiguration>(new HttpRequest
            {
                Uri = "/api/v1/threats/configuration",
                Verb = HttpVerb.Post,
                Payload = threatInsightConfiguration,
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
