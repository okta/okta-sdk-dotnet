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
        public string Alg => GetStringProperty("alg");
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string E => GetStringProperty("e");
        
        /// <inheritdoc/>
        public DateTimeOffset? ExpiresAt => GetDateTimeProperty("expiresAt");
        
        /// <inheritdoc/>
        public IList<string> KeyOps => GetArrayProperty<string>("key_ops");
        
        /// <inheritdoc/>
        public string Kid => GetStringProperty("kid");
        
        /// <inheritdoc/>
        public string Kty => GetStringProperty("kty");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string N => GetStringProperty("n");
        
        /// <inheritdoc/>
        public string Status => GetStringProperty("status");
        
        /// <inheritdoc/>
        public string Use => GetStringProperty("use");
        
        /// <inheritdoc/>
        public IList<string> X5C => GetArrayProperty<string>("x5c");
        
        /// <inheritdoc/>
        public string X5T => GetStringProperty("x5t");
        
        /// <inheritdoc/>
        public string X5TS256 => GetStringProperty("x5t#S256");
        
        /// <inheritdoc/>
        public string X5U => GetStringProperty("x5u");
        
    }
}
