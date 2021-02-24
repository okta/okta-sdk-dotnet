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
    public sealed partial class UserSchema : Resource, IUserSchema
    {
        /// <inheritdoc/>
        public string Schema 
        {
            get => GetStringProperty("$schema");
            set => this["$schema"] = value;
        }
        
        /// <inheritdoc/>
        public string Created 
        {
            get => GetStringProperty("created");
            set => this["created"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaDefinitions Definitions 
        {
            get => GetResourceProperty<UserSchemaDefinitions>("definitions");
            set => this["definitions"] = value;
        }
        
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string LastUpdated 
        {
            get => GetStringProperty("lastUpdated");
            set => this["lastUpdated"] = value;
        }
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public Resource Properties 
        {
            get => GetResourceProperty<Resource>("properties");
            set => this["properties"] = value;
        }
        
        /// <inheritdoc/>
        public string Title 
        {
            get => GetStringProperty("title");
            set => this["title"] = value;
        }
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
    }
}
