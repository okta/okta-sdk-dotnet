// <copyright file="GroupSchemaAttribute.Generated.cs" company="Okta, Inc">
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
    public sealed partial class GroupSchemaAttribute : Resource, IGroupSchemaAttribute
    {
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Enum 
        {
            get => GetArrayProperty<string>("enum");
            set => this["enum"] = value;
        }
        
        /// <inheritdoc/>
        public string ExternalName 
        {
            get => GetStringProperty("externalName");
            set => this["externalName"] = value;
        }
        
        /// <inheritdoc/>
        public string ExternalNamespace 
        {
            get => GetStringProperty("externalNamespace");
            set => this["externalNamespace"] = value;
        }
        
        /// <inheritdoc/>
        public IUserSchemaAttributeItems Items 
        {
            get => GetResourceProperty<UserSchemaAttributeItems>("items");
            set => this["items"] = value;
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
        public IList<IUserSchemaAttributeEnum> OneOf 
        {
            get => GetArrayProperty<IUserSchemaAttributeEnum>("oneOf");
            set => this["oneOf"] = value;
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
        public UserSchemaAttributeScope Scope 
        {
            get => GetEnumProperty<UserSchemaAttributeScope>("scope");
            set => this["scope"] = value;
        }
        
        /// <inheritdoc/>
        public string Title 
        {
            get => GetStringProperty("title");
            set => this["title"] = value;
        }
        
        /// <inheritdoc/>
        public UserSchemaAttributeType Type 
        {
            get => GetEnumProperty<UserSchemaAttributeType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc/>
        public UserSchemaAttributeUnion Union 
        {
            get => GetEnumProperty<UserSchemaAttributeUnion>("union");
            set => this["union"] = value;
        }
        
        /// <inheritdoc/>
        public string Unique 
        {
            get => GetStringProperty("unique");
            set => this["unique"] = value;
        }
        
    }
}
