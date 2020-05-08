// <copyright file="OAuth2Scope.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OAuth2Scope : Resource, IOAuth2Scope
    {
        /// <inheritdoc/>
        public string Consent 
        {
            get => GetStringProperty("consent");
            set => this["consent"] = value;
        }
        
        /// <inheritdoc/>
        public bool? Default 
        {
            get => GetBooleanProperty("default");
            set => this["default"] = value;
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
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string MetadataPublish 
        {
            get => GetStringProperty("metadataPublish");
            set => this["metadataPublish"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public bool? System 
        {
            get => GetBooleanProperty("system");
            set => this["system"] = value;
        }
        
    }
}
