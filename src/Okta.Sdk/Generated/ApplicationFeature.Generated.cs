// <copyright file="ApplicationFeature.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ApplicationFeature : Resource, IApplicationFeature
    {
        /// <inheritdoc/>
        public ICapabilitiesObject Capabilities 
        {
            get => GetResourceProperty<CapabilitiesObject>("capabilities");
            set => this["capabilities"] = value;
        }
        
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public EnabledStatus Status 
        {
            get => GetEnumProperty<EnabledStatus>("status");
            set => this["status"] = value;
        }

        public ICollectionClient<IApplicationFeature> ListFeaturesForApplication(string appId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        //public ICollectionClient<IApplicationFeature> ListFeaturesForApplication(
        //    string appId)
        //    => GetClient().Applications.ListFeaturesForApplication(appId);

    }
}
