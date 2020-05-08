// <copyright file="OAuth2Claim.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OAuth2Claim : Resource, IOAuth2Claim
    {
        /// <inheritdoc/>
        public bool? AlwaysIncludeInToken 
        {
            get => GetBooleanProperty("alwaysIncludeInToken");
            set => this["alwaysIncludeInToken"] = value;
        }
        
        /// <inheritdoc/>
        public string ClaimType 
        {
            get => GetStringProperty("claimType");
            set => this["claimType"] = value;
        }
        
        /// <inheritdoc/>
        public IOAuth2ClaimConditions Conditions 
        {
            get => GetResourceProperty<OAuth2ClaimConditions>("conditions");
            set => this["conditions"] = value;
        }
        
        /// <inheritdoc/>
        public string GroupFilterType 
        {
            get => GetStringProperty("group_filter_type");
            set => this["group_filter_type"] = value;
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
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public bool? System 
        {
            get => GetBooleanProperty("system");
            set => this["system"] = value;
        }
        
        /// <inheritdoc/>
        public string Value 
        {
            get => GetStringProperty("value");
            set => this["value"] = value;
        }
        
        /// <inheritdoc/>
        public string ValueType 
        {
            get => GetStringProperty("valueType");
            set => this["valueType"] = value;
        }
        
    }
}
