// <copyright file="AppLink.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
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
    public sealed partial class AppLink : Resource, IAppLink
    {
        /// <inheritdoc/>
        public string AppAssignmentId => GetStringProperty("appAssignmentId");
        
        /// <inheritdoc/>
        public string AppInstanceId => GetStringProperty("appInstanceId");
        
        /// <inheritdoc/>
        public string AppName => GetStringProperty("appName");
        
        /// <inheritdoc/>
        public bool? CredentialsSetup => GetBooleanProperty("credentialsSetup");
        
        /// <inheritdoc/>
        public bool? Hidden => GetBooleanProperty("hidden");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Label => GetStringProperty("label");
        
        /// <inheritdoc/>
        public string LinkUrl => GetStringProperty("linkUrl");
        
        /// <inheritdoc/>
        public string LogoUrl => GetStringProperty("logoUrl");
        
        /// <inheritdoc/>
        public int? SortOrder => GetIntegerProperty("sortOrder");
        
    }
}
