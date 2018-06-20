// <copyright file="WsFederationApplicationSettingsApplication.Generated.cs" company="Okta, Inc">
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
    public sealed partial class WsFederationApplicationSettingsApplication : ApplicationSettingsApplication, IWsFederationApplicationSettingsApplication
    {
        /// <inheritdoc/>
        public string AttributeStatements 
        {
            get => GetStringProperty("attributeStatements");
            set => this["attributeStatements"] = value;
        }
        
        /// <inheritdoc/>
        public string AudienceRestriction 
        {
            get => GetStringProperty("audienceRestriction");
            set => this["audienceRestriction"] = value;
        }
        
        /// <inheritdoc/>
        public string AuthenticationContextClassName 
        {
            get => GetStringProperty("authnContextClassRef");
            set => this["authnContextClassRef"] = value;
        }
        
        /// <inheritdoc/>
        public string GroupFilter 
        {
            get => GetStringProperty("groupFilter");
            set => this["groupFilter"] = value;
        }
        
        /// <inheritdoc/>
        public string GroupName 
        {
            get => GetStringProperty("groupName");
            set => this["groupName"] = value;
        }
        
        /// <inheritdoc/>
        public string GroupValueFormat 
        {
            get => GetStringProperty("groupValueFormat");
            set => this["groupValueFormat"] = value;
        }
        
        /// <inheritdoc/>
        public string NameIdFormat 
        {
            get => GetStringProperty("nameIDFormat");
            set => this["nameIDFormat"] = value;
        }
        
        /// <inheritdoc/>
        public string Realm 
        {
            get => GetStringProperty("realm");
            set => this["realm"] = value;
        }
        
        /// <inheritdoc/>
        public string SiteUrl 
        {
            get => GetStringProperty("siteURL");
            set => this["siteURL"] = value;
        }
        
        /// <inheritdoc/>
        public string UsernameAttribute 
        {
            get => GetStringProperty("usernameAttribute");
            set => this["usernameAttribute"] = value;
        }
        
        /// <inheritdoc/>
        public bool? WReplyOverride 
        {
            get => GetBooleanProperty("wReplyOverride");
            set => this["wReplyOverride"] = value;
        }
        
        /// <inheritdoc/>
        public string WReplyUrl 
        {
            get => GetStringProperty("wReplyURL");
            set => this["wReplyURL"] = value;
        }
        
    }
}
