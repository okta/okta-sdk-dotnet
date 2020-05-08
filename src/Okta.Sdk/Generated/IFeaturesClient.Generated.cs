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
    /// <summary>A client that works with Okta Feature resources.</summary>
    public partial interface IFeaturesClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <returns>A collection of <see cref="IFeature"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IFeature> ListFeatures();

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="featureId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IFeature"/> response.</returns>
        Task<IFeature> GetFeatureAsync(string featureId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns>A collection of <see cref="IFeature"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IFeature> ListFeatureDependencies(string featureId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns>A collection of <see cref="IFeature"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IFeature> ListFeatureDependents(string featureId);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="featureId"></param>
        /// <param name="lifecycle"></param>
        /// <param name="mode"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IFeature"/> response.</returns>
        Task<IFeature> UpdateFeatureLifecycleAsync(string featureId, string lifecycle, string mode = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}
