// <copyright file="IDomainCertificate.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a DomainCertificate resource in the Okta API.</summary>
    public partial interface IDomainCertificate : IResource
    {
        string Certificate { get; set; }

        string CertificateChain { get; set; }

        string PrivateKey { get; set; }

        DomainCertificateType Type { get; set; }

        Task CreateCertificateAsync(IDomainCertificate domainCertificate, 
            string domainId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
