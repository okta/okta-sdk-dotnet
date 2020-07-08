// <copyright file="ProtocolEndpoints.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ProtocolEndpoints : Resource, IProtocolEndpoints
    {
        /// <inheritdoc/>
        public IProtocolEndpoint Acs 
        {
            get => GetResourceProperty<ProtocolEndpoint>("acs");
            set => this["acs"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Authorization 
        {
            get => GetResourceProperty<ProtocolEndpoint>("authorization");
            set => this["authorization"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Jwks 
        {
            get => GetResourceProperty<ProtocolEndpoint>("jwks");
            set => this["jwks"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Metadata 
        {
            get => GetResourceProperty<ProtocolEndpoint>("metadata");
            set => this["metadata"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Slo 
        {
            get => GetResourceProperty<ProtocolEndpoint>("slo");
            set => this["slo"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Sso 
        {
            get => GetResourceProperty<ProtocolEndpoint>("sso");
            set => this["sso"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Token 
        {
            get => GetResourceProperty<ProtocolEndpoint>("token");
            set => this["token"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint UserInfo 
        {
            get => GetResourceProperty<ProtocolEndpoint>("userInfo");
            set => this["userInfo"] = value;
        }
        
    }
}
