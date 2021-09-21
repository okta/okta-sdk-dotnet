// <copyright file="UserType.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserType : Resource, IUserType
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string CreatedBy => GetStringProperty("createdBy");
        
        /// <inheritdoc/>
        public bool? Default => GetBooleanProperty("default");
        
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string DisplayName 
        {
            get => GetStringProperty("displayName");
            set => this["displayName"] = value;
        }
        
        /// <inheritdoc/>
        public string Id 
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string LastUpdatedBy => GetStringProperty("lastUpdatedBy");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
    }
}
