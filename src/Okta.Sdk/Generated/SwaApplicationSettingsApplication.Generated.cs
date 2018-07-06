// <copyright file="SwaApplicationSettingsApplication.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SwaApplicationSettingsApplication : ApplicationSettingsApplication, ISwaApplicationSettingsApplication
    {
        /// <inheritdoc/>
        public string ButtonField 
        {
            get => GetStringProperty("buttonField");
            set => this["buttonField"] = value;
        }
        
        /// <inheritdoc/>
        public string LoginUrlRegex 
        {
            get => GetStringProperty("loginUrlRegex");
            set => this["loginUrlRegex"] = value;
        }
        
        /// <inheritdoc/>
        public string PasswordField 
        {
            get => GetStringProperty("passwordField");
            set => this["passwordField"] = value;
        }
        
        /// <inheritdoc/>
        public string Url 
        {
            get => GetStringProperty("url");
            set => this["url"] = value;
        }
        
        /// <inheritdoc/>
        public string UsernameField 
        {
            get => GetStringProperty("usernameField");
            set => this["usernameField"] = value;
        }
        
    }
}
