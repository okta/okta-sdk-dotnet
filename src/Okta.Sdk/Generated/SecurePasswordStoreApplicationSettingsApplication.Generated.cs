// <copyright file="SecurePasswordStoreApplicationSettingsApplication.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SecurePasswordStoreApplicationSettingsApplication : ApplicationSettingsApplication, ISecurePasswordStoreApplicationSettingsApplication
    {
        /// <inheritdoc/>
        public string OptionalField1 
        {
            get => GetStringProperty("optionalField1");
            set => this["optionalField1"] = value;
        }
        
        /// <inheritdoc/>
        public string OptionalField1Value 
        {
            get => GetStringProperty("optionalField1Value");
            set => this["optionalField1Value"] = value;
        }
        
        /// <inheritdoc/>
        public string OptionalField2 
        {
            get => GetStringProperty("optionalField2");
            set => this["optionalField2"] = value;
        }
        
        /// <inheritdoc/>
        public string OptionalField2Value 
        {
            get => GetStringProperty("optionalField2Value");
            set => this["optionalField2Value"] = value;
        }
        
        /// <inheritdoc/>
        public string OptionalField3 
        {
            get => GetStringProperty("optionalField3");
            set => this["optionalField3"] = value;
        }
        
        /// <inheritdoc/>
        public string OptionalField3Value 
        {
            get => GetStringProperty("optionalField3Value");
            set => this["optionalField3Value"] = value;
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
