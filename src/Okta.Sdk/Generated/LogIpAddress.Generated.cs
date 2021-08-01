// <copyright file="LogIpAddress.Generated.cs" company="Okta, Inc">
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
    public sealed partial class LogIpAddress : Resource, ILogIpAddress
    {
        /// <inheritdoc/>
        public ILogGeographicalContext GeographicalContext 
        {
            get => GetResourceProperty<LogGeographicalContext>("geographicalContext");
            set => this["geographicalContext"] = value;
        }
        
        /// <inheritdoc/>
        public string Ip => GetStringProperty("ip");
        
        /// <inheritdoc/>
        public string Source => GetStringProperty("source");
        
        /// <inheritdoc/>
        public string Version => GetStringProperty("version");
        
    }
}
