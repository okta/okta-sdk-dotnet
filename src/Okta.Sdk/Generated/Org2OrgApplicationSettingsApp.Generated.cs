// <copyright file="Org2OrgApplicationSettingsApp.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Org2OrgApplicationSettingsApp : ApplicationSettingsApplication, IOrg2OrgApplicationSettingsApp
    {
        /// <inheritdoc/>
        public string AcsUrl 
        {
            get => GetStringProperty("acsUrl");
            set => this["acsUrl"] = value;
        }
        
        /// <inheritdoc/>
        public string AudRestriction 
        {
            get => GetStringProperty("audRestriction");
            set => this["audRestriction"] = value;
        }
        
        /// <inheritdoc/>
        public string BaseUrl 
        {
            get => GetStringProperty("baseUrl");
            set => this["baseUrl"] = value;
        }
        
    }
}
