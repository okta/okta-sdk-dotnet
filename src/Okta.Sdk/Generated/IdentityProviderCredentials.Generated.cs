// <copyright file="IdentityProviderCredentials.Generated.cs" company="Okta, Inc">
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
    public sealed partial class IdentityProviderCredentials : Resource, IIdentityProviderCredentials
    {
        /// <inheritdoc/>
        public IIdentityProviderCredentialsClient Client 
        {
            get => GetResourceProperty<IdentityProviderCredentialsClient>("client");
            set => this["client"] = value;
        }
        
        /// <inheritdoc/>
        public IIdentityProviderCredentialsSigning Signing 
        {
            get => GetResourceProperty<IdentityProviderCredentialsSigning>("signing");
            set => this["signing"] = value;
        }
        
        /// <inheritdoc/>
        public IIdentityProviderCredentialsTrust Trust 
        {
            get => GetResourceProperty<IdentityProviderCredentialsTrust>("trust");
            set => this["trust"] = value;
        }
        
    }
}
