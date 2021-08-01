// <copyright file="DomainsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class DomainsClient : OktaClient, IDomainsClient
    {
        // Remove parameterless constructor
        private DomainsClient()
        {
        }

        internal DomainsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IDomainListResponse> ListDomainsAsync(CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<DomainListResponse>(new HttpRequest
            {
                Uri = "/api/v1/domains",
                Verb = HttpVerb.Get,
                
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IDomainResponse> CreateDomainAsync(IDomain domain, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<DomainResponse>(new HttpRequest
            {
                Uri = "/api/v1/domains",
                Verb = HttpVerb.Post,
                Payload = domain,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/domains/{domainId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["domainId"] = domainId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IDomainResponse> GetDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<DomainResponse>(new HttpRequest
            {
                Uri = "/api/v1/domains/{domainId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["domainId"] = domainId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task CreateCertificateAsync(IDomainCertificate domainCertificate, string domainId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/domains/{domainId}/certificate",
                Verb = HttpVerb.Put,
                Payload = domainCertificate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["domainId"] = domainId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IDomainResponse> VerifyDomainAsync(string domainId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<DomainResponse>(new HttpRequest
            {
                Uri = "/api/v1/domains/{domainId}/verify",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["domainId"] = domainId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
