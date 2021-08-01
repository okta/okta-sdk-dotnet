// <copyright file="LogAuthenticationContext.Generated.cs" company="Okta, Inc">
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
    public sealed partial class LogAuthenticationContext : Resource, ILogAuthenticationContext
    {
        /// <inheritdoc/>
        public LogAuthenticationProvider AuthenticationProvider 
        {
            get => GetEnumProperty<LogAuthenticationProvider>("authenticationProvider");
            set => this["authenticationProvider"] = value;
        }
        
        /// <inheritdoc/>
        public int? AuthenticationStep => GetIntegerProperty("authenticationStep");
        
        /// <inheritdoc/>
        public LogCredentialProvider CredentialProvider 
        {
            get => GetEnumProperty<LogCredentialProvider>("credentialProvider");
            set => this["credentialProvider"] = value;
        }
        
        /// <inheritdoc/>
        public LogCredentialType CredentialType 
        {
            get => GetEnumProperty<LogCredentialType>("credentialType");
            set => this["credentialType"] = value;
        }
        
        /// <inheritdoc/>
        public string ExternalSessionId => GetStringProperty("externalSessionId");
        
        /// <inheritdoc/>
        public string Interface => GetStringProperty("interface");
        
        /// <inheritdoc/>
        public ILogIssuer Issuer 
        {
            get => GetResourceProperty<LogIssuer>("issuer");
            set => this["issuer"] = value;
        }
        
    }
}
