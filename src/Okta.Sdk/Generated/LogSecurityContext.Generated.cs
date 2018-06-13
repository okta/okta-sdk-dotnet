// <copyright file="LogSecurityContext.Generated.cs" company="Okta, Inc">
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
    public sealed partial class LogSecurityContext : Resource, ILogSecurityContext
    {
        /// <inheritdoc/>
        public int? AsNumber => GetIntegerProperty("asNumber");
        
        /// <inheritdoc/>
        public string AsOrg => GetStringProperty("asOrg");
        
        /// <inheritdoc/>
        public string Domain => GetStringProperty("domain");
        
        /// <inheritdoc/>
        public bool? IsProxy => GetBooleanProperty("isProxy");
        
        /// <inheritdoc/>
        public string Isp => GetStringProperty("isp");
        
    }
}
