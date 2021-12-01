// <copyright file="AuthenticatorProviderConfiguration.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AuthenticatorProviderConfiguration : Resource, IAuthenticatorProviderConfiguration
    {
        /// <inheritdoc/>
        public int? AuthPort 
        {
            get => GetIntegerProperty("authPort");
            set => this["authPort"] = value;
        }
        
        /// <inheritdoc/>
        public string HostName 
        {
            get => GetStringProperty("hostName");
            set => this["hostName"] = value;
        }
        
        /// <inheritdoc/>
        public string InstanceId 
        {
            get => GetStringProperty("instanceId");
            set => this["instanceId"] = value;
        }
        
        /// <inheritdoc/>
        public string SharedSecret 
        {
            get => GetStringProperty("sharedSecret");
            set => this["sharedSecret"] = value;
        }
        
        /// <inheritdoc/>
        public IAuthenticatorProviderConfigurationUserNameTemplate UserNameTemplate 
        {
            get => GetResourceProperty<AuthenticatorProviderConfigurationUserNameTemplate>("userNameTemplate");
            set => this["userNameTemplate"] = value;
        }
        
    }
}
