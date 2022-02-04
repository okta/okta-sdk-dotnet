// <copyright file="IFeaturesClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IFeaturesClient
    {
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="featureId"></param>
        ///  <returns>Task of IFeature</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IFeature> GetFeatureAsync(string featureId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="featureId"></param>
        /// A collection of <see cref="IFeaturesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IFeature> ListFeatureDependencies(string featureId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="featureId"></param>
        /// A collection of <see cref="IFeaturesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IFeature> ListFeatureDependents(string featureId);
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// A collection of <see cref="IFeaturesClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IFeature> ListFeatures();
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="featureId"></param>
        /// <param name="lifecycle"></param>
        /// <param name="mode"> (optional)</param>
        ///  <returns>Task of IFeature</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IFeature> UpdateFeatureLifecycleAsync(string featureId, string lifecycle, string mode = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

