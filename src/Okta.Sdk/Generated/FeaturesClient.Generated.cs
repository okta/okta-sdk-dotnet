// <copyright file="FeaturesClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class FeaturesClient : OktaClient, IFeaturesClient
    {
        // Remove parameterless constructor
        private FeaturesClient()
        {
        }

        internal FeaturesClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IFeature> ListFeatures()
            => GetCollectionClient<IFeature>(new HttpRequest
            {
                Uri = "/api/v1/features",
                Verb = HttpVerb.Get,
                
            });
                    
        /// <inheritdoc />
        public async Task<IFeature> GetFeatureAsync(string featureId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Feature>(new HttpRequest
            {
                Uri = "/api/v1/features/{featureId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["featureId"] = featureId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IFeature> ListFeatureDependencies(string featureId)
            => GetCollectionClient<IFeature>(new HttpRequest
            {
                Uri = "/api/v1/features/{featureId}/dependencies",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["featureId"] = featureId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IFeature> ListFeatureDependents(string featureId)
            => GetCollectionClient<IFeature>(new HttpRequest
            {
                Uri = "/api/v1/features/{featureId}/dependents",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["featureId"] = featureId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IFeature> UpdateFeatureLifecycleAsync(string featureId, string lifecycle, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Feature>(new HttpRequest
            {
                Uri = "/api/v1/features/{featureId}/{lifecycle}",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["featureId"] = featureId,
                    ["lifecycle"] = lifecycle,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["mode"] = mode,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
