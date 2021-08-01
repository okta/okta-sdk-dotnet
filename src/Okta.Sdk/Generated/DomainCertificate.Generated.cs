// <copyright file="DomainCertificate.Generated.cs" company="Okta, Inc">
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
    public sealed partial class DomainCertificate : Resource, IDomainCertificate
    {
        /// <inheritdoc/>
        public string Certificate 
        {
            get => GetStringProperty("certificate");
            set => this["certificate"] = value;
        }
        
        /// <inheritdoc/>
        public string CertificateChain 
        {
            get => GetStringProperty("certificateChain");
            set => this["certificateChain"] = value;
        }
        
        /// <inheritdoc/>
        public string PrivateKey 
        {
            get => GetStringProperty("privateKey");
            set => this["privateKey"] = value;
        }
        
        /// <inheritdoc/>
        public DomainCertificateType Type 
        {
            get => GetEnumProperty<DomainCertificateType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public Task CreateCertificateAsync(IDomainCertificate domainCertificate, 
            string domainId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Domains.CreateCertificateAsync(domainCertificate, domainId, cancellationToken);
        
    }
}
