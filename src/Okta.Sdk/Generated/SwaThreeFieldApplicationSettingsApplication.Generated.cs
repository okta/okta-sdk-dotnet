// <copyright file="SwaThreeFieldApplicationSettingsApplication.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SwaThreeFieldApplicationSettingsApplication : ApplicationSettingsApplication, ISwaThreeFieldApplicationSettingsApplication
    {
        /// <inheritdoc/>
        public string ButtonSelector 
        {
            get => GetStringProperty("buttonSelector");
            set => this["buttonSelector"] = value;
        }
        
        /// <inheritdoc/>
        public string ExtraFieldSelector 
        {
            get => GetStringProperty("extraFieldSelector");
            set => this["extraFieldSelector"] = value;
        }
        
        /// <inheritdoc/>
        public string ExtraFieldValue 
        {
            get => GetStringProperty("extraFieldValue");
            set => this["extraFieldValue"] = value;
        }
        
        /// <inheritdoc/>
        public string LoginUrlRegex 
        {
            get => GetStringProperty("loginUrlRegex");
            set => this["loginUrlRegex"] = value;
        }
        
        /// <inheritdoc/>
        public string PasswordSelector 
        {
            get => GetStringProperty("passwordSelector");
            set => this["passwordSelector"] = value;
        }
        
        /// <inheritdoc/>
        public string TargetUrl 
        {
            get => GetStringProperty("targetURL");
            set => this["targetURL"] = value;
        }
        
        /// <inheritdoc/>
        public string UserNameSelector 
        {
            get => GetStringProperty("userNameSelector");
            set => this["userNameSelector"] = value;
        }
        
    }
}
