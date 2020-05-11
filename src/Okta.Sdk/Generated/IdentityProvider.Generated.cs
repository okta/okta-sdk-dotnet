// <copyright file="IdentityProvider.Generated.cs" company="Okta, Inc">
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
    public sealed partial class IdentityProvider : Resource, IIdentityProvider
    {
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
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
        public IIdentityProviderPolicy Policy 
        {
            get => GetResourceProperty<IdentityProviderPolicy>("policy");
            set => this["policy"] = value;
        }
        
        /// <inheritdoc/>
        public IProtocol Protocol 
        {
            get => GetResourceProperty<Protocol>("protocol");
            set => this["protocol"] = value;
        }
        
        /// <inheritdoc/>
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc />
        public ICollectionClient<ICsr> ListSigningCsrs(
            )
            => GetClient().IdentityProviders.ListCsrsForIdentityProvider(Id);
        
        /// <inheritdoc />
        public Task<ICsr> GenerateCsrAsync(ICsrMetadata metadata, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.GenerateCsrForIdentityProviderAsync(metadata, Id, cancellationToken);
        
        /// <inheritdoc />
        public Task DeleteSigningCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.RevokeCsrForIdentityProviderAsync(Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public Task<ICsr> GetSigningCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.GetCsrForIdentityProviderAsync(Id, csrId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IJsonWebKey> ListSigningKeys(
            )
            => GetClient().IdentityProviders.ListIdentityProviderSigningKeys(Id);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> GenerateSigningKeyAsync(
            int? validityYears, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.GenerateIdentityProviderSigningKeyAsync(Id, validityYears, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> GetSigningKeyAsync(
            string keyId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.GetIdentityProviderSigningKeyAsync(Id, keyId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IJsonWebKey> CloneKeyAsync(
            string keyId, string targetIdpId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.CloneIdentityProviderKeyAsync(Id, keyId, targetIdpId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IIdentityProvider> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.ActivateIdentityProviderAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IIdentityProvider> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.DeactivateIdentityProviderAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<IIdentityProviderApplicationUser> ListUsers(
            )
            => GetClient().IdentityProviders.ListIdentityProviderApplicationUsers(Id);
        
        /// <inheritdoc />
        public Task UnlinkUserAsync(
            string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.UnlinkUserFromIdentityProviderAsync(Id, userId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IIdentityProviderApplicationUser> GetUserAsync(
            string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.GetIdentityProviderApplicationUserAsync(idpId, userId, cancellationToken);
        
        /// <inheritdoc />
        public Task<IIdentityProviderApplicationUser> LinkUserAsync(IUserIdentityProviderLinkRequest userIdentityProviderLinkRequest, 
            string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().IdentityProviders.LinkUserToIdentityProviderAsync(userIdentityProviderLinkRequest, Id, userId, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<ISocialAuthToken> ListSocialAuthTokens(
            string userId)
            => GetClient().IdentityProviders.ListSocialAuthTokens(Id, userId);
        
    }
}
