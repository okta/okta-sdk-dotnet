// <copyright file="SamlAttributeStatement.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SamlAttributeStatement : Resource, ISamlAttributeStatement
    {
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public string Namespace 
        {
            get => GetStringProperty("namespace");
            set => this["namespace"] = value;
        }
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Values 
        {
            get => GetArrayProperty<string>("values");
            set => this["values"] = value;
        }
        
    }
}
