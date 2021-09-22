// <copyright file="UserSchema.Generated.cs" company="Okta, Inc">
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
    [ResourceObject(NullValueHandling = ResourceNullValueHandling.Include)] 
    public sealed partial class UserSchema : Resource, IUserSchema
    
    {
        /// <inheritdoc/>
        public string Schema => GetStringProperty("$schema");
        
        /// <inheritdoc/>
        public string Created => GetStringProperty("created");
        
        /// <inheritdoc/>
        public IUserSchemaDefinitions Definitions 
        {
            get => GetResourceProperty<UserSchemaDefinitions>("definitions");
            set => this["definitions"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string LastUpdated => GetStringProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name => GetStringProperty("name");
        
        /// <inheritdoc/>
        public IUserSchemaProperties Properties => GetResourceProperty<UserSchemaProperties>("properties");
        
        /// <inheritdoc/>
        public string Title 
        {
            get => GetStringProperty("title");
            set => this["title"] = value;
        }
        
        /// <inheritdoc/>
        public string Type => GetStringProperty("type");
        
    }
}
