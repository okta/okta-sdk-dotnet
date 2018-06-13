// <copyright file="ApplicationSettingsNotificationsVpn.Generated.cs" company="Okta, Inc">
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
    public sealed partial class ApplicationSettingsNotificationsVpn : Resource, IApplicationSettingsNotificationsVpn
    {
        /// <inheritdoc/>
        public string HelpUrl 
        {
            get => GetStringProperty("helpUrl");
            set => this["helpUrl"] = value;
        }
        
        /// <inheritdoc/>
        public string Message 
        {
            get => GetStringProperty("message");
            set => this["message"] = value;
        }
        
        /// <inheritdoc/>
        public IApplicationSettingsNotificationsVpnNetwork Network 
        {
            get => GetResourceProperty<ApplicationSettingsNotificationsVpnNetwork>("network");
            set => this["network"] = value;
        }
        
    }
}
