// <copyright file="SingleLogout.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SingleLogout : Resource, ISingleLogout
    {
        /// <inheritdoc/>
        public bool? Enabled 
        {
            get => GetBooleanProperty("enabled");
            set => this["enabled"] = value;
        }
        
        /// <inheritdoc/>
        public string Issuer 
        {
            get => GetStringProperty("issuer");
            set => this["issuer"] = value;
        }
        
        /// <inheritdoc/>
        public string LogoutUrl 
        {
            get => GetStringProperty("logoutUrl");
            set => this["logoutUrl"] = value;
        }
        
    }
}
