// <copyright file="ApplicationSettings.Generated.cs" company="Okta, Inc">
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
    public partial class ApplicationSettings : Resource, IApplicationSettings
    {
        /// <inheritdoc/>
        public IApplicationSettingsApplication App 
        {
            get => GetResourceProperty<ApplicationSettingsApplication>("app");
            set => this["app"] = value;
        }
        
        /// <inheritdoc/>
        public bool? ImplicitAssignment 
        {
            get => GetBooleanProperty("implicitAssignment");
            set => this["implicitAssignment"] = value;
        }
        
        /// <inheritdoc/>
        public IApplicationSettingsNotifications Notifications 
        {
            get => GetResourceProperty<ApplicationSettingsNotifications>("notifications");
            set => this["notifications"] = value;
        }
        
    }
}
