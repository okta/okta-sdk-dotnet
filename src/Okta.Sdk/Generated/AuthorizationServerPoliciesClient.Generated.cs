// <copyright file="AuthorizationServerPoliciesClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AuthorizationServerPoliciesClient : OktaClient, IAuthorizationServerPoliciesClient
    {
        // Remove parameterless constructor
        private AuthorizationServerPoliciesClient()
        {
        }

        internal AuthorizationServerPoliciesClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
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
        public async Task<IAuthorizationServerPolicyRule> CreateAuthorizationServerPolicyRuleAsync(IAuthorizationServerPolicyRule policyRule, string policyId, string authServerId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<AuthorizationServerPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules",
                Verb = HttpVerb.Post,
                Payload = policyRule,
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
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
        public async Task<IAuthorizationServerPolicyRule> UpdateAuthorizationServerPolicyRuleAsync(string policyId, string authServerId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<AuthorizationServerPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Put,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["authServerId"] = authServerId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
