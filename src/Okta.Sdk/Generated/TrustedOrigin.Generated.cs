// <copyright file="TrustedOrigin.Generated.cs" company="Okta, Inc">
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
    public sealed partial class TrustedOrigin : Resource, ITrustedOrigin
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string CreatedBy 
        {
            get => GetStringProperty("createdBy");
            set => this["createdBy"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string LastUpdatedBy 
        {
            get => GetStringProperty("lastUpdatedBy");
            set => this["lastUpdatedBy"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public string Origin 
        {
            get => GetStringProperty("origin");
            set => this["origin"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IScope> Scopes 
        {
            get => GetArrayProperty<IScope>("scopes");
            set => this["scopes"] = value;
        }
        
        /// <inheritdoc/>
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
    }
}
