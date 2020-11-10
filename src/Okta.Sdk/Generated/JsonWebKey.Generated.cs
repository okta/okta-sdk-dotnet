// <copyright file="JsonWebKey.Generated.cs" company="Okta, Inc">
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
    public sealed partial class JsonWebKey : Resource, IJsonWebKey
    {
        /// <inheritdoc/>
        public string Alg 
        {
            get => GetStringProperty("alg");
            set => this["alg"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string E 
        {
            get => GetStringProperty("e");
            set => this["e"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? ExpiresAt => GetDateTimeProperty("expiresAt");
        
        /// <inheritdoc/>
        public IList<string> KeyOps 
        {
            get => GetArrayProperty<string>("key_ops");
            set => this["key_ops"] = value;
        }
        
        /// <inheritdoc/>
        public string Kid 
        {
            get => GetStringProperty("kid");
            set => this["kid"] = value;
        }
        
        /// <inheritdoc/>
        public string Kty 
        {
            get => GetStringProperty("kty");
            set => this["kty"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string N 
        {
            get => GetStringProperty("n");
            set => this["n"] = value;
        }
        
        /// <inheritdoc/>
        public string Status => GetStringProperty("status");
        
        /// <inheritdoc/>
        public string Use 
        {
            get => GetStringProperty("use");
            set => this["use"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> X5C 
        {
            get => GetArrayProperty<string>("x5c");
            set => this["x5c"] = value;
        }
        
        /// <inheritdoc/>
        public string X5T 
        {
            get => GetStringProperty("x5t");
            set => this["x5t"] = value;
        }
        
        /// <inheritdoc/>
        public string X5TS256 
        {
            get => GetStringProperty("x5t#S256");
            set => this["x5t#S256"] = value;
        }
        
        /// <inheritdoc/>
        public string X5U 
        {
            get => GetStringProperty("x5u");
            set => this["x5u"] = value;
        }
        
    }
}
