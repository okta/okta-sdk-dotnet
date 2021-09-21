// <copyright file="UserSchemaAttribute.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserSchemaAttribute : Resource, IUserSchemaAttribute
    {
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttributeMaster Master 
        {
            get => GetResourceProperty<UserSchemaAttributeMaster>("master");
            set => this["master"] = value;
        }
        
        /// <inheritdoc/>
        public int? MaxLength 
        {
            get => GetIntegerProperty("maxLength");
            set => this["maxLength"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinLength 
        {
            get => GetIntegerProperty("minLength");
            set => this["minLength"] = value;
        }
        
        /// <inheritdoc/>
        public string Mutability 
        {
            get => GetStringProperty("mutability");
            set => this["mutability"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IUserSchemaAttributePermission> Permissions 
        {
            get => GetArrayProperty<IUserSchemaAttributePermission>("permissions");
            set => this["permissions"] = value;
        }
        
        /// <inheritdoc/>
        public bool? Required 
        {
            get => GetBooleanProperty("required");
            set => this["required"] = value;
        }
        
        /// <inheritdoc/>
        public string Scope 
        {
            get => GetStringProperty("scope");
            set => this["scope"] = value;
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
