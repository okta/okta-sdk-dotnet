// <copyright file="DomainResponse.Generated.cs" company="Okta, Inc">
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
    public sealed partial class DomainResponse : Resource, IDomainResponse
    {
        /// <inheritdoc/>
        public string CertificateSourcetype 
        {
            get => GetStringProperty("certificateSourcetype");
            set => this["certificateSourcetype"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IDNSRecord> DnsRecords 
        {
            get => GetArrayProperty<IDNSRecord>("dnsRecords");
            set => this["dnsRecords"] = value;
        }
        
        /// <inheritdoc/>
        public string Domain 
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
        public string ValidationStatus 
        {
            get => GetStringProperty("validationStatus");
            set => this["validationStatus"] = value;
        }
        
    }
}
