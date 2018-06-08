// <copyright file="PushFactorProfile.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PushFactorProfile : FactorProfile, IPushFactorProfile
    {
        /// <inheritdoc/>
        public string CredentialId 
        {
            get => GetStringProperty("credentialId");
            set => this["credentialId"] = value;
        }
        
        /// <inheritdoc/>
        public string DeviceType => GetStringProperty("deviceType");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public string Platform => GetStringProperty("platform");
        
        /// <inheritdoc/>
        public string Version 
        {
            get => GetStringProperty("version");
            set => this["version"] = value;
        }
        
    }
}
