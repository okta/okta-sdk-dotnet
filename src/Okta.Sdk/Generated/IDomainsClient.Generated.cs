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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IDomainsClient
    {
        /// <summary>
        /// Create Certificate Creates the Certificate for the Domain.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="domainId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task CreateCertificateAsync(IDomainCertificate body, string domainId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create Domain Creates your domain.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IDomainResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        //Task<IDomainResponse> CreateDomainAsync(IDomain body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete Domain Deletes a Domain by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="domainId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Domain Fetches a Domain by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="domainId"></param>
        ///  <returns>Task of IDomainResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        //Task<IDomainResponse> GetDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List Domains List all verified custom Domains for the org.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        ///  <returns>Task of IDomainListResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IDomainListResponse> ListDomainsAsync( CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Verify Domain Verifies the Domain by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="domainId"></param>
        ///  <returns>Task of IDomainResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        //Task<IDomainResponse> VerifyDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

