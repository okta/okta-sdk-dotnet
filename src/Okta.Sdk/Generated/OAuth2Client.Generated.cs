// <copyright file="OAuth2Client.Generated.cs" company="Okta, Inc">
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
    public sealed partial class OAuth2Client : Resource, IOAuth2Client
    {
        /// <inheritdoc/>
        public string ClientId => GetStringProperty("client_id");
        
        /// <inheritdoc/>
        public string ClientName => GetStringProperty("client_name");
        
        /// <inheritdoc/>
        public string ClientUri => GetStringProperty("client_uri");
        
        /// <inheritdoc/>
        public string LogoUri => GetStringProperty("logo_uri");
        
    }
}
