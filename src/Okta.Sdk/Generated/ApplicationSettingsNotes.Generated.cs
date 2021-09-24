// <copyright file="ApplicationSettingsNotes.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ApplicationSettingsNotes : Resource, IApplicationSettingsNotes
    {
        /// <inheritdoc/>
        public string Admin 
        {
            get => GetStringProperty("admin");
            set => this["admin"] = value;
        }
        
        /// <inheritdoc/>
        public string EndUser 
        {
            get => GetStringProperty("enduser");
            set => this["enduser"] = value;
        }
        
    }
}
