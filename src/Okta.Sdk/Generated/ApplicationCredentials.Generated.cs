// <copyright file="ApplicationCredentials.Generated.cs" company="Okta, Inc">
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
    public partial class ApplicationCredentials : Resource, IApplicationCredentials
    {
        /// <inheritdoc/>
        public IApplicationCredentialsSigning Signing 
        {
            get => GetResourceProperty<ApplicationCredentialsSigning>("signing");
            set => this["signing"] = value;
        }
        
        /// <inheritdoc/>
        public IApplicationCredentialsUsernameTemplate UserNameTemplate 
        {
            get => GetResourceProperty<ApplicationCredentialsUsernameTemplate>("userNameTemplate");
            set => this["userNameTemplate"] = value;
        }
        
    }
}
