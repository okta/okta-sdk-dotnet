// <copyright file="ActivateFactorRequest.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ActivateFactorRequest : Resource, IActivateFactorRequest
    {
        /// <inheritdoc/>
        public string Attestation 
        {
            get => GetStringProperty("attestation");
            set => this["attestation"] = value;
        }
        
        /// <inheritdoc/>
        public string ClientData 
        {
            get => GetStringProperty("clientData");
            set => this["clientData"] = value;
        }
        
        /// <inheritdoc/>
        public string PassCode 
        {
            get => GetStringProperty("passCode");
            set => this["passCode"] = value;
        }
        
        /// <inheritdoc/>
        public string RegistrationData 
        {
            get => GetStringProperty("registrationData");
            set => this["registrationData"] = value;
        }
        
        /// <inheritdoc/>
        public string StateToken 
        {
            get => GetStringProperty("stateToken");
            set => this["stateToken"] = value;
        }
        
    }
}
