// <copyright file="IAuthorizationServer.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a AuthorizationServer resource in the Okta API.</summary>
    public partial interface IAuthorizationServer : IResource
    {
        IList<string> Audiences { get; set; }

        DateTimeOffset? Created { get; }

        IAuthorizationServerCredentials Credentials { get; set; }

        string Description { get; set; }

        string Id { get; }

        string Issuer { get; set; }

        string IssuerMode { get; set; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        string Status { get; set; }

        ICollectionClient<IOAuth2Claim> ListOAuth2Claims(
            );

        Task<IOAuth2Claim> CreateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteOAuth2ClaimAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2Claim> GetOAuth2ClaimAsync(
            string claimId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2Claim> UpdateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, 
            string claimId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2Client> ListOAuth2Clients(
            );

        Task RevokeRefreshTokensForClientAsync(
            string clientId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForClient(
            string clientId, string expand = null, string after = null, int? limit = -1);

        Task<IOAuth2RefreshToken> GetRefreshTokenForClientAsync(
            string clientId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeRefreshTokenForClientAsync(
            string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IJsonWebKey> ListKeys(
            );

        ICollectionClient<IJsonWebKey> RotateKeys(IJwkUse use 
            );

        Task ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IPolicy> ListPolicies(
            );

        Task<IPolicy> CreatePolicyAsync(IPolicy policy, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeletePolicyAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IPolicy> GetPolicyAsync(
            string policyId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IPolicy> UpdatePolicyAsync(IPolicy policy, 
            string policyId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2Scope> ListOAuth2Scopes(
            string q = null, string filter = null, string cursor = null, int? limit = -1);

        Task<IOAuth2Scope> CreateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteOAuth2ScopeAsync(
            string scopeId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2Scope> GetOAuth2ScopeAsync(
            string scopeId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2Scope> UpdateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, 
            string scopeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
