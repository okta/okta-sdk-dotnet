// <copyright file="IDomain.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a Domain resource in the Okta API.</summary>
    public partial interface IDomain : IResource
    {
        DomainCertificateSourceType CertificateSourcetype { get; set; }

        IList<IDNSRecord> DnsRecords { get; set; }

        string DomainName { get; set; }

        string Id { get; }

        IDomainCertificateMetadata PublicCertificate { get; set; }

        DomainValidationStatus ValidationStatus { get; set; }

    }
}
