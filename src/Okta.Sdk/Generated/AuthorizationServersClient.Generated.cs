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
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Post,
                Payload = authorizationServer,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServer> GetAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<AuthorizationServer>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}",
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Put,
                Payload = authorizationServer,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteAuthorizationServerAsync(string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}",
                Verb = HttpVerb.Delete,
                
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
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Post,
                Payload = oAuth2Claim,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2Claim> GetOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2Claim>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims/{claimId}",
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Put,
                Payload = oAuth2Claim,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["claimId"] = claimId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteOAuth2ClaimAsync(string authServerId, string claimId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/claims/{claimId}",
                Verb = HttpVerb.Delete,
                
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
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForAuthorizationServerAndClient(string authServerId, string clientId, string expand = null, string after = null, int? limit = -1)
            => GetCollectionClient<IOAuth2RefreshToken>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens",
                Verb = HttpVerb.Get,
                
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
        public async Task RevokeRefreshTokensForAuthorizationServerAndClientAsync(string authServerId, string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["clientId"] = clientId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2RefreshToken> GetRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2RefreshToken>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}",
                Verb = HttpVerb.Get,
                
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
        public async Task RevokeRefreshTokenForAuthorizationServerAndClientAsync(string authServerId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["clientId"] = clientId,
                    ["tokenId"] = tokenId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListAuthorizationServerKeys(string authServerId)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/credentials/keys",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> RotateAuthorizationServerKeys(IJwkUse jwkUse, string authServerId)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate",
                Verb = HttpVerb.Post,
                Payload = jwkUse,
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
                Verb = HttpVerb.Post,
                
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
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IAuthorizationServerPolicy> ListAuthorizationServerPolicies(string authServerId)
            => GetCollectionClient<IAuthorizationServerPolicy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IAuthorizationServerPolicy> CreateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy authorizationServerPolicy, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<AuthorizationServerPolicy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies",
                Verb = HttpVerb.Post,
                Payload = authorizationServerPolicy,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServerPolicy> GetAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<AuthorizationServerPolicy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServerPolicy> UpdateAuthorizationServerPolicyAsync(IAuthorizationServerPolicy authorizationServerPolicy, string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<AuthorizationServerPolicy>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}",
                Verb = HttpVerb.Put,
                Payload = authorizationServerPolicy,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ActivateAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateAuthorizationServerPolicyAsync(string authServerId, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IAuthorizationServerPolicyRule> ListAuthorizationServerPolicyRules(string policyId, string authServerId)
            => GetCollectionClient<IAuthorizationServerPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IAuthorizationServerPolicyRule> CreateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule authorizationServerPolicyRule, string policyId, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<AuthorizationServerPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules",
                Verb = HttpVerb.Post,
                Payload = authorizationServerPolicyRule,
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServerPolicyRule> GetAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<AuthorizationServerPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthorizationServerPolicyRule> UpdateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule authorizationServerPolicyRule, string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<AuthorizationServerPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Put,
                Payload = authorizationServerPolicyRule,
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ActivateAuthorizationServerPolicyRuleAsync(string authServerId, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateAuthorizationServerPolicyRuleAsync(string authServerId, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Scope> ListOAuth2Scopes(string authServerId, string q = null, string filter = null, string cursor = null, int? limit = -1)
            => GetCollectionClient<IOAuth2Scope>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes",
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Post,
                Payload = oAuth2Scope,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2Scope> GetOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2Scope>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}",
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Put,
                Payload = oAuth2Scope,
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["scopeId"] = scopeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteOAuth2ScopeAsync(string authServerId, string scopeId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/scopes/{scopeId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authServerId"] = authServerId,
                    ["scopeId"] = scopeId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
