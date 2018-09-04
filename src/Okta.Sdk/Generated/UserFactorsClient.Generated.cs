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
        public ICollectionClient<IFactor> ListFactors(string userId)
            => GetCollectionClient<IFactor>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IFactor> AddFactorAsync(IFactor factor, string userId, bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Factor>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors",
                Payload = factor,
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
        public ICollectionClient<IFactor> ListSupportedFactors(string userId)
            => GetCollectionClient<IFactor>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors/catalog",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions(string userId)
            => GetCollectionClient<ISecurityQuestion>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors/questions",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public async Task DeleteFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors/{factorId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["factorId"] = factorId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IFactor> GetFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Factor>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors/{factorId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["factorId"] = factorId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IFactor> ActivateFactorAsync(IVerifyFactorRequest verifyFactorRequest, string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Factor>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors/{factorId}/lifecycle/activate",
                Payload = verifyFactorRequest,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["factorId"] = factorId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IVerifyFactorResponse> VerifyFactorAsync(IVerifyFactorRequest verifyFactorRequest, string userId, string factorId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<VerifyFactorResponse>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/factors/{factorId}/verify",
                Payload = verifyFactorRequest,
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
