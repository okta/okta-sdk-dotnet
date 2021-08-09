// <copyright file="IDomainsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta Domain resources.</summary>
    public partial interface IDomainsClient
    {
        /// <summary>
        /// List all verified custom Domains for the org.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IDomainListResponse"/> response.</returns>
        Task<IDomainListResponse> ListDomainsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates your domain.
        /// </summary>
        /// <param name="domain">The <see cref="IDomain"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IDomainResponse"/> response.</returns>
        Task<IDomainResponse> CreateDomainAsync(IDomain domain, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Verifies the Domain by `id`.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IDomainResponse"/> response.</returns>
        Task<IDomainResponse> VerifyDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates the Certificate for the Domain.
        /// </summary>
        /// <param name="domainCertificate">The <see cref="IDomainCertificate"/> resource.</param>
        /// <param name="domainId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task CreateCertificateAsync(IDomainCertificate domainCertificate, string domainId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a Domain by `id`.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IDomainResponse"/> response.</returns>
        Task<IDomainResponse> GetDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a Domain by `id`.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
