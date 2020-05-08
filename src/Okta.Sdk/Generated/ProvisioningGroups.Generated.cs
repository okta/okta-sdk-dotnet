// <copyright file="ProvisioningGroups.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ProvisioningGroups : Resource, IProvisioningGroups
    {
        /// <inheritdoc/>
        public string Action 
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Assignments 
        {
            get => GetArrayProperty<string>("assignments");
            set => this["assignments"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Filter 
        {
            get => GetArrayProperty<string>("filter");
            set => this["filter"] = value;
        }
        
        /// <inheritdoc/>
        public string SourceAttributeName 
        {
            get => GetStringProperty("sourceAttributeName");
            set => this["sourceAttributeName"] = value;
        }
        
    }
}
