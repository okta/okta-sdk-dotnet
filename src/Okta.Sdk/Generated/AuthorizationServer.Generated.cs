// <copyright file="AuthorizationServer.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AuthorizationServer : Resource, IAuthorizationServer
    {
        /// <inheritdoc/>
        public IList<string> Audiences 
        {
            get => GetArrayProperty<string>("audiences");
            set => this["audiences"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public IAuthorizationServerCredentials Credentials 
        {
            get => GetResourceProperty<AuthorizationServerCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public string Description 
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public string Issuer 
        {
            get => GetStringProperty("issuer");
            set => this["issuer"] = value;
        }
        
        /// <inheritdoc/>
        public string IssuerMode 
        {
            get => GetStringProperty("issuerMode");
            set => this["issuerMode"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Claim> ListOAuth2Claims(
            )
            => GetClient().AuthorizationServers.ListOAuth2Claims(Id);
        
        /// <inheritdoc />
        public Task<IOAuth2Claim> CreateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.CreateOAuth2ClaimAsync(oAuth2Claim, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteOAuth2ClaimAsync(
            string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.DeleteOAuth2ClaimAsync(Id, claimId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2Claim> GetOAuth2ClaimAsync(
            string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.GetOAuth2ClaimAsync(Id, claimId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2Claim> UpdateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, 
            string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.UpdateOAuth2ClaimAsync(oAuth2Claim, Id, claimId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Client> ListOAuth2Clients(
            )
            => GetClient().AuthorizationServers.ListOAuth2ClientsForAuthorizationServer(Id);
        
        /// <inheritdoc />
        public Task RevokeRefreshTokensForClientAsync(
            string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.RevokeRefreshTokensForAuthorizationServerAndClientAsync(Id, clientId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForClient(
            string clientId, string expand = null, string after = null, int? limit = -1)
            => GetClient().AuthorizationServers.ListRefreshTokensForAuthorizationServerAndClient(Id, clientId, expand, after, limit);
        
        /// <inheritdoc />
        public Task<IOAuth2RefreshToken> GetRefreshTokenForClientAsync(
            string clientId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.GetRefreshTokenForAuthorizationServerAndClientAsync(Id, clientId, tokenId, expand, cancellationToken);
        
        /// <inheritdoc />
        public Task RevokeRefreshTokenForClientAsync(
            string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.RevokeRefreshTokenForAuthorizationServerAndClientAsync(Id, clientId, tokenId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListKeys(
            )
            => GetClient().AuthorizationServers.ListAuthorizationServerKeys(Id);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> RotateKeys(IJwkUse use 
            )
            => GetClient().AuthorizationServers.RotateAuthorizationServerKeys(use, Id);
        
        /// <inheritdoc />
        public Task ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.ActivateAuthorizationServerAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.DeactivateAuthorizationServerAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IPolicy> ListPolicies(
            )
            => GetClient().AuthorizationServers.ListAuthorizationServerPolicies(Id);
        
        /// <inheritdoc />
        public Task<IPolicy> CreatePolicyAsync(IPolicy policy, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.CreateAuthorizationServerPolicyAsync(policy, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeletePolicyAsync(
            string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.DeleteAuthorizationServerPolicyAsync(Id, policyId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IPolicy> GetPolicyAsync(
            string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.GetAuthorizationServerPolicyAsync(Id, policyId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IPolicy> UpdatePolicyAsync(IPolicy policy, 
            string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.UpdateAuthorizationServerPolicyAsync(policy, Id, policyId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Scope> ListOAuth2Scopes(
            string q = null, string filter = null, string cursor = null, int? limit = -1)
            => GetClient().AuthorizationServers.ListOAuth2Scopes(Id, q, filter, cursor, limit);
        
        /// <inheritdoc />
        public Task<IOAuth2Scope> CreateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.CreateOAuth2ScopeAsync(oAuth2Scope, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteOAuth2ScopeAsync(
            string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.DeleteOAuth2ScopeAsync(Id, scopeId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2Scope> GetOAuth2ScopeAsync(
            string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.GetOAuth2ScopeAsync(Id, scopeId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IOAuth2Scope> UpdateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, 
            string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().AuthorizationServers.UpdateOAuth2ScopeAsync(oAuth2Scope, Id, scopeId, cancellationToken);
        
    }
}
