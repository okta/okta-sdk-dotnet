// <copyright file="IdentityProvidersClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class IdentityProvidersClient : OktaClient, IIdentityProvidersClient
    {
        // Remove parameterless constructor
        private IdentityProvidersClient()
        {
        }

        internal IdentityProvidersClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IIdentityProvider> ListIdentityProviders(string q = null, string after = null, int? limit = 20, string type = null)
            => GetCollectionClient<IIdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/idps",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["type"] = type,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IIdentityProvider> CreateIdentityProviderAsync(IIdentityProvider identityProvider, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<IdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/idps",
                Payload = identityProvider,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListIdentityProviderKeys(string after = null, int? limit = 20)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/credentials/keys",
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IJsonWebKey> CreateIdentityProviderKeyAsync(IJsonWebKey jsonWebKey, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/credentials/keys",
                Payload = jsonWebKey,
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteIdentityProviderKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/idps/credentials/keys/{keyId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["keyId"] = keyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> GetIdentityProviderKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/credentials/keys/{keyId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["keyId"] = keyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeleteIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IIdentityProvider> GetIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<IdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IIdentityProvider> UpdateIdentityProviderAsync(IIdentityProvider identityProvider, string idpId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<IdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}",
                Payload = identityProvider,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<ICsr> ListCsrsForIdentityProvider(string idpId)
            => GetCollectionClient<ICsr>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<ICsr> GenerateCsrForIdentityProviderAsync(ICsrMetadata metadata, string idpId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Csr>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs",
                Payload = metadata,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task RevokeCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ICsr> GetCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Csr>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> PublishCerCertForIdentityProviderAsync(string certificate, string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}/lifecycle/publish",
                Payload = certificate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> PublishBinaryCerCertForIdentityProviderAsync(byte[] certificate, string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}/lifecycle/publish",
                Payload = certificate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> PublishDerCertForIdentityProviderAsync(string certificate, string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}/lifecycle/publish",
                Payload = certificate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> PublishBinaryDerCertForIdentityProviderAsync(byte[] certificate, string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}/lifecycle/publish",
                Payload = certificate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> PublishBinaryPemCertForIdentityProviderAsync(byte[] certificate, string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/csrs/{csrId}/lifecycle/publish",
                Payload = certificate,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["csrId"] = csrId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListIdentityProviderSigningKeys(string idpId)
            => GetCollectionClient<IJsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/keys",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IJsonWebKey> GenerateIdentityProviderSigningKeyAsync(string idpId, int? validityYears, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/keys/generate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["validityYears"] = validityYears,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> GetIdentityProviderSigningKeyAsync(string idpId, string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/keys/{keyId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["keyId"] = keyId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IJsonWebKey> CloneIdentityProviderKeyAsync(string idpId, string keyId, string targetIdpId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<JsonWebKey>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/credentials/keys/{keyId}/clone",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["keyId"] = keyId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["targetIdpId"] = targetIdpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IIdentityProvider> ActivateIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<IdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/lifecycle/activate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IIdentityProvider> DeactivateIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<IdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/lifecycle/deactivate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IIdentityProviderApplicationUser> ListIdentityProviderApplicationUsers(string idpId)
            => GetCollectionClient<IIdentityProviderApplicationUser>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/users",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                },
            });
                    
        /// <inheritdoc />
        public async Task UnlinkUserFromIdentityProviderAsync(string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IIdentityProviderApplicationUser> GetIdentityProviderApplicationUserAsync(string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<IdentityProviderApplicationUser>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IIdentityProviderApplicationUser> LinkUserToIdentityProviderAsync(IUserIdentityProviderLinkRequest userIdentityProviderLinkRequest, string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<IdentityProviderApplicationUser>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/users/{userId}",
                Payload = userIdentityProviderLinkRequest,
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<ISocialAuthToken> ListSocialAuthTokens(string idpId, string userId)
            => GetCollectionClient<ISocialAuthToken>(new HttpRequest
            {
                Uri = "/api/v1/idps/{idpId}/users/{userId}/credentials/tokens",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["idpId"] = idpId,
                    ["userId"] = userId,
                },
            });
                    
    }
}
