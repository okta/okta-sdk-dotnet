// <copyright file="PasswordCredential.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordCredential : Resource, IPasswordCredential
    {
        /// <inheritdoc/>
        public IPasswordCredentialHash Hash 
        {
            get => GetResourceProperty<PasswordCredentialHash>("hash");
            set => this["hash"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordCredentialHook Hook 
        {
            get => GetResourceProperty<PasswordCredentialHook>("hook");
            set => this["hook"] = value;
        }
        
        /// <inheritdoc/>
        public string Value 
        {
            get => GetStringProperty("value");
            set => this["value"] = value;
        }
        
    }
}
