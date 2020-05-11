// <copyright file="Feature.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Feature : Resource, IFeature
    {
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public IFeatureStage Stage 
        {
            get => GetResourceProperty<FeatureStage>("stage");
            set => this["stage"] = value;
        }
        
        /// <inheritdoc/>
        public EnabledStatus Status 
        {
            get => GetEnumProperty<EnabledStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public FeatureType Type 
        {
            get => GetEnumProperty<FeatureType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task<IFeature> UpdateLifecycleAsync(
            string lifecycle, string mode = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Features.UpdateFeatureLifecycleAsync(Id, lifecycle, mode, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IFeature> GetDependents(
            )
            => GetClient().Features.ListFeatureDependents(Id);
        
        /// <inheritdoc />
        public ICollectionClient<IFeature> GetDependencies(
            )
            => GetClient().Features.ListFeatureDependencies(Id);
        
    }
}
