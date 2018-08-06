// <copyright file="VerifyFactorRequest.Generated.cs" company="Okta, Inc">
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
    public sealed partial class VerifyFactorRequest : Resource, IVerifyFactorRequest
    {
        /// <inheritdoc/>
        public string ActivationToken 
        {
            get => GetStringProperty("activationToken");
            set => this["activationToken"] = value;
        }
        
        /// <inheritdoc/>
        public string Answer 
        {
            get => GetStringProperty("answer");
            set => this["answer"] = value;
        }
        
        /// <inheritdoc/>
        public string NextPassCode 
        {
            get => GetStringProperty("nextPassCode");
            set => this["nextPassCode"] = value;
        }
        
        /// <inheritdoc/>
        public string PassCode 
        {
            get => GetStringProperty("passCode");
            set => this["passCode"] = value;
        }
        
        /// <inheritdoc/>
        public int? TokenLifetimeSeconds 
        {
            get => GetIntegerProperty("tokenLifetimeSeconds");
            set => this["tokenLifetimeSeconds"] = value;
        }
        
    }
}
