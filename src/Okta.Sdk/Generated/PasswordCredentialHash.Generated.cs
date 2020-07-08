// <copyright file="PasswordCredentialHash.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordCredentialHash : Resource, IPasswordCredentialHash
    {
        /// <inheritdoc/>
        public PasswordCredentialHashAlgorithm Algorithm 
        {
            get => GetEnumProperty<PasswordCredentialHashAlgorithm>("algorithm");
            set => this["algorithm"] = value;
        }
        
        /// <inheritdoc/>
        public string Salt 
        {
            get => GetStringProperty("salt");
            set => this["salt"] = value;
        }
        
        /// <inheritdoc/>
        public string SaltOrder 
        {
            get => GetStringProperty("saltOrder");
            set => this["saltOrder"] = value;
        }
        
        /// <inheritdoc/>
        public string Value 
        {
            get => GetStringProperty("value");
            set => this["value"] = value;
        }
        
        /// <inheritdoc/>
        public int? WorkerFactor 
        {
            get => GetIntegerProperty("workerFactor");
            set => this["workerFactor"] = value;
        }
        
    }
}
