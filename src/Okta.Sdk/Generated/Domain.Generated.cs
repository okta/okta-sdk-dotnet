// <copyright file="Domain.Generated.cs" company="Okta, Inc">
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
    public sealed partial class Domain : Resource, IDomain
    {
        /// <inheritdoc/>
        public DomainCertificateSourceType CertificateSourceType 
        {
            get => GetEnumProperty<DomainCertificateSourceType>("certificateSourceType");
            set => this["certificateSourceType"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IDnsRecord> DnsRecords 
        {
            get => GetArrayProperty<IDnsRecord>("dnsRecords");
            set => this["dnsRecords"] = value;
        }
        
        /// <inheritdoc/>
        public string DomainName 
        {
            get => GetStringProperty("domain");
            set => this["domain"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public IDomainCertificateMetadata PublicCertificate 
        {
            get => GetResourceProperty<DomainCertificateMetadata>("publicCertificate");
            set => this["publicCertificate"] = value;
        }
        
        /// <inheritdoc/>
        public DomainValidationStatus ValidationStatus 
        {
            get => GetEnumProperty<DomainValidationStatus>("validationStatus");
            set => this["validationStatus"] = value;
        }
        
    }
}
