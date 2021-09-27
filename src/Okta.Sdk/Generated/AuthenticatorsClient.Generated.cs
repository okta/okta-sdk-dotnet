// <copyright file="AuthenticatorsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class AuthenticatorsClient : OktaClient, IAuthenticatorsClient
    {
        // Remove parameterless constructor
        private AuthenticatorsClient()
        {
        }

        internal AuthenticatorsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IAuthenticator> ListAuthenticators()
            => GetCollectionClient<IAuthenticator>(new HttpRequest
            {
                Uri = "/api/v1/authenticators",
                Verb = HttpVerb.Get,
                
            });
                    
        /// <inheritdoc />
        public async Task<IAuthenticator> GetAuthenticatorAsync(string authenticatorId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Authenticator>(new HttpRequest
            {
                Uri = "/api/v1/authenticators/{authenticatorId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authenticatorId"] = authenticatorId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthenticator> ActivateAuthenticatorAsync(string authenticatorId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Authenticator>(new HttpRequest
            {
                Uri = "/api/v1/authenticators/{authenticatorId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authenticatorId"] = authenticatorId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IAuthenticator> DeactivateAuthenticatorAsync(string authenticatorId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Authenticator>(new HttpRequest
            {
                Uri = "/api/v1/authenticators/{authenticatorId}/lifecycle/deactivate",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["authenticatorId"] = authenticatorId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
