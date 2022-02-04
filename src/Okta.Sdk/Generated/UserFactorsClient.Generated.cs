// <copyright file="UserFactorsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserFactorsClient : OktaClient, IUserFactorsClient
    {
        // Remove parameterless constructor
        private UserFactorsClient()
        {
        }

        internal UserFactorsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<IUserFactor> ActivateFactorAsync(string userId, string factorId, IActivateFactorRequest body = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<UserFactor>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/{factorId}/lifecycle/activate",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["factorId"] = factorId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task DeleteFactorAsync(string userId, string factorId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/{factorId}",
            Verb = HttpVerb.DELETE,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["factorId"] = factorId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IUserFactor> EnrollFactorAsync(IUserFactor body, string userId, bool? updatePhone = null, string templateId = null, int? tokenLifetimeSeconds = null, bool? activate = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<UserFactor>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["updatePhone"] = updatePhone,
                ["templateId"] = templateId,
                ["tokenLifetimeSeconds"] = tokenLifetimeSeconds,
                ["activate"] = activate,
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IUserFactor> GetFactorAsync(string userId, string factorId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<UserFactor>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/{factorId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["factorId"] = factorId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public async Task<IVerifyUserFactorResponse> GetFactorTransactionStatusAsync(string userId, string factorId, string transactionId,CancellationToken cancellationToken = default(CancellationToken))
        
        => await GetAsync<VerifyUserFactorResponse>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/{factorId}/transactions/{transactionId}",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["factorId"] = factorId,
                ["transactionId"] = transactionId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        }, cancellationToken).ConfigureAwait(false);
            
        
        /// <inheritdoc />
        public ICollectionClient<IUserFactor>ListFactors(string userId)
        
        => GetCollectionClient<IUserFactor>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        });
            
        
        /// <inheritdoc />
        public ICollectionClient<IUserFactor>ListSupportedFactors(string userId)
        
        => GetCollectionClient<IUserFactor>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/catalog",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        });
            
        
        /// <inheritdoc />
        public ICollectionClient<ISecurityQuestion>ListSupportedSecurityQuestions(string userId)
        
        => GetCollectionClient<ISecurityQuestion>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/questions",
            Verb = HttpVerb.GET,
            
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
            },
        });
            
        
        /// <inheritdoc />
        public async Task<IVerifyUserFactorResponse> VerifyFactorAsync(string userId, string factorId, IVerifyFactorRequest body = null, string xForwardedFor = null, string userAgent = null, string acceptLanguage = null, string templateId = null, int? tokenLifetimeSeconds = null,CancellationToken cancellationToken = default(CancellationToken))
        
        => await PostAsync<VerifyUserFactorResponse>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/factors/{factorId}/verify",
            Verb = HttpVerb.POST,
            Payload = body,
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["factorId"] = factorId,
            },
            
            QueryParameters = new Dictionary<string, object>()
            {
                ["templateId"] = templateId,
                ["tokenLifetimeSeconds"] = tokenLifetimeSeconds,
            },
        }, cancellationToken).ConfigureAwait(false);
            
    }
}
