// <copyright file="Protocol.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Protocol : Resource, IProtocol
    {
        /// <inheritdoc/>
        public IProtocolAlgorithms Algorithms 
        {
            get => GetResourceProperty<ProtocolAlgorithms>("algorithms");
            set => this["algorithms"] = value;
        }
        
        /// <inheritdoc/>
        public IIdentityProviderCredentials Credentials 
        {
            get => GetResourceProperty<IdentityProviderCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoints Endpoints 
        {
            get => GetResourceProperty<ProtocolEndpoints>("endpoints");
            set => this["endpoints"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolEndpoint Issuer 
        {
            get => GetResourceProperty<ProtocolEndpoint>("issuer");
            set => this["issuer"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolRelayState RelayState 
        {
            get => GetResourceProperty<ProtocolRelayState>("relayState");
            set => this["relayState"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Scopes 
        {
            get => GetArrayProperty<string>("scopes");
            set => this["scopes"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocolSettings Settings 
        {
            get => GetResourceProperty<ProtocolSettings>("settings");
            set => this["settings"] = value;
        }
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
    }
}
