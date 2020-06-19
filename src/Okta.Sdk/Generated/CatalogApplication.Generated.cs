// <copyright file="CatalogApplication.Generated.cs" company="Okta, Inc">
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
    public sealed partial class CatalogApplication : Resource, ICatalogApplication
    {
        /// <inheritdoc/>
        public string Category 
        {
            get => GetStringProperty("category");
            set => this["category"] = value;
        }
        
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string DisplayName 
        {
            get => GetStringProperty("displayName");
            set => this["displayName"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Features 
        {
            get => GetArrayProperty<string>("features");
            set => this["features"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> SignOnModes 
        {
            get => GetArrayProperty<string>("signOnModes");
            set => this["signOnModes"] = value;
        }
        
        /// <inheritdoc/>
        public CatalogApplicationStatus Status 
        {
            get => GetEnumProperty<CatalogApplicationStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public string VerificationStatus 
        {
            get => GetStringProperty("verificationStatus");
            set => this["verificationStatus"] = value;
        }
        
        /// <inheritdoc/>
        public string Website 
        {
            get => GetStringProperty("website");
            set => this["website"] = value;
        }
        
    }
}
