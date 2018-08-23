// <copyright file="BrowserPluginApplication.Generated.cs" company="Okta, Inc">
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
    public partial class BrowserPluginApplication : Application, IBrowserPluginApplication
    {
        /// <inheritdoc/>
        public new ISchemeApplicationCredentials Credentials 
        {
            get => GetResourceProperty<SchemeApplicationCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
    }
}
