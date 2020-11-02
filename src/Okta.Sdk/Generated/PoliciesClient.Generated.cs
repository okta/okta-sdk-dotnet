// <copyright file="PoliciesClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PoliciesClient : OktaClient, IPoliciesClient
    {
        // Remove parameterless constructor
        private PoliciesClient()
        {
        }

        internal PoliciesClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IAuthorizationServerPolicy> ListPolicies(string type, string status = null, string expand = "")
            => GetCollectionClient<IAuthorizationServerPolicy>(new HttpRequest
            {
                Uri = "/api/v1/policies",
                Verb = HttpVerb.Get,
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["type"] = type,
                    ["status"] = status,
                    ["expand"] = expand,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IPolicy> CreatePolicyAsync(IPolicy policy, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Policy>(new HttpRequest
            {
                Uri = "/api/v1/policies",
                Verb = HttpVerb.Post,
                Payload = policy,
                QueryParameters = new Dictionary<string, object>()
                {
                    ["activate"] = activate,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeletePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IPolicy> GetPolicyAsync(string policyId, string expand = "", CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Policy>(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IPolicy> UpdatePolicyAsync(IPolicy policy, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<Policy>(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}",
                Verb = HttpVerb.Put,
                Payload = policy,
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ActivatePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivatePolicyAsync(string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IPolicyRule> ListPolicyRules(string policyId)
            => GetCollectionClient<IPolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IPolicyRule> CreatePolicyRuleAsync(IPolicyRule policyRule, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<PolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules",
                Verb = HttpVerb.Post,
                Payload = policyRule,
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeletePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IPolicyRule> GetPolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<PolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IPolicyRule> UpdatePolicyRuleAsync(IPolicyRule policyRule, string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<PolicyRule>(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules/{ruleId}",
                Verb = HttpVerb.Put,
                Payload = policyRule,
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ActivatePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules/{ruleId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivatePolicyRuleAsync(string policyId, string ruleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["policyId"] = policyId,
                    ["ruleId"] = ruleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
