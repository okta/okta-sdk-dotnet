// <copyright file="AuthorizationServersClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AuthorizationServersClient : OktaClient, IAuthorizationServersClient
    {
        // Remove parameterless constructor
        private AuthorizationServersClient()
        {
        }

        internal AuthorizationServersClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IAuthorizationServer> ListAuthorizationServers(string q = null, string limit = null, string after = null)
            => GetCollectionClient<IAuthorizationServer>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["limit"] = limit,
                    ["after"] = after,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IAuthorizationServer> CreateAuthorizationServerAsync(IAuthorizationServer authorizationServer, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<AuthorizationServer>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers",
                Payload = authorizationServer,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServer> GetAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<AuthorizationServer>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServer> UpdateAuthorizationServerAsync(IAuthorizationServer authorizationServer, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<AuthorizationServer>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}",
                Payload = authorizationServer,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Claim> ListOAuth2Claims(string authServerId)
            => GetCollectionClient<IOAuth2Claim>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IOAuth2Claim> CreateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OAuth2Claim>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims",
                Payload = oAuth2Claim,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims/{claimId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["claimId"] = claimId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2Claim> GetOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2Claim>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims/{claimId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["claimId"] = claimId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2Claim> UpdateOAuth2ClaimAsync(IOAuth2Claim oAuth2Claim, string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<OAuth2Claim>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims/{claimId}",
                Payload = oAuth2Claim,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["claimId"] = claimId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Client> ListOAuth2ClientsForAuthorizationServer(string authServerId)
            => GetCollectionClient<IOAuth2Client>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public async Task RevokeRefreshTokensForAuthorizationServerAndClientAsync(string authServerId, string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["clientId"] = clientId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForAuthorizationServerAndClient(string authServerId, string clientId, string expand = null, string after = null, int? limit = -1)
            => GetCollectionClient<IOAuth2RefreshToken>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["clientId"] = clientId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task RevokeRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["clientId"] = clientId,
                    ["tokenId"] = tokenId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2RefreshToken> GetRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2RefreshToken>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["clientId"] = clientId,
                    ["tokenId"] = tokenId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListAuthorizationServerKeys(string authServerId)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/credentials/keys",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> RotateAuthorizationServerKeys(IJwkUse use, string authServerId)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate",
                Payload = use,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public async Task ActivateAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/lifecycle/activate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/lifecycle/deactivate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IPolicy> ListAuthorizationServerPolicies(string authServerId)
            => GetCollectionClient<IPolicy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IPolicy> CreateAuthorizationServerPolicyAsync(IPolicy policy, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Policy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies",
                Payload = policy,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IPolicy> GetAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Policy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IPolicy> UpdateAuthorizationServerPolicyAsync(IPolicy policy, string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<Policy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}",
                Payload = policy,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Scope> ListOAuth2Scopes(string authServerId, string q = null, string filter = null, string cursor = null, int? limit = -1)
            => GetCollectionClient<IOAuth2Scope>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["filter"] = filter,
                    ["cursor"] = cursor,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IOAuth2Scope> CreateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<OAuth2Scope>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes",
                Payload = oAuth2Scope,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["scopeId"] = scopeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2Scope> GetOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2Scope>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["scopeId"] = scopeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2Scope> UpdateOAuth2ScopeAsync(IOAuth2Scope oAuth2Scope, string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<OAuth2Scope>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}",
                Payload = oAuth2Scope,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["scopeId"] = scopeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
