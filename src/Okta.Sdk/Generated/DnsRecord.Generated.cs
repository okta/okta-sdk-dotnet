// <copyright file="DnsRecord.Generated.cs" company="Okta, Inc">
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
    public sealed partial class DnsRecord : Resource, IDnsRecord
    {
        /// <inheritdoc/>
        public string Expiration 
        {
            get => GetStringProperty("expiration");
            set => this["expiration"] = value;
        }
        
        /// <inheritdoc/>
        public string Fqdn 
        {
            get => GetStringProperty("fqdn");
            set => this["fqdn"] = value;
        }
        
        /// <inheritdoc/>
        public DnsRecordType RecordType 
        {
            get => GetEnumProperty<DnsRecordType>("recordType");
            set => this["recordType"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Values 
        {
            get => GetArrayProperty<string>("values");
            set => this["values"] = value;
        }
        
    }
}
