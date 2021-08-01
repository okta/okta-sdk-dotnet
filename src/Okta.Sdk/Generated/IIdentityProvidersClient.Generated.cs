// <copyright file="IIdentityProvidersClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta IdentityProvider resources.</summary>
    public partial interface IIdentityProvidersClient
    {
        /// <summary>
        /// Enumerates IdPs in your organization with pagination. A subset of IdPs can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q">Searches the name property of IdPs for matching value</param>
        /// <param name="after">Specifies the pagination cursor for the next page of IdPs</param>
        /// <param name="limit">Specifies the number of IdP results in a page</param>
        /// <param name="type">Filters IdPs by type</param>
        /// <returns>A collection of <see cref="IIdentityProvider"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IIdentityProvider> ListIdentityProviders(string q = null, string after = null, int? limit = 20, string type = null);

        /// <summary>
        /// Adds a new IdP to your organization.
        /// </summary>
        /// <param name="identityProvider">The <see cref="IIdentityProvider"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProvider"/> response.</returns>
        Task<IIdentityProvider> CreateIdentityProviderAsync(IIdentityProvider identityProvider, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates IdP key credentials.
        /// </summary>
        /// <param name="after">Specifies the pagination cursor for the next page of keys</param>
        /// <param name="limit">Specifies the number of key results in a page</param>
        /// <returns>A collection of <see cref="IJsonWebKey"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IJsonWebKey> ListIdentityProviderKeys(string after = null, int? limit = 20);

        /// <summary>
        /// Adds a new X.509 certificate credential to the IdP key store.
        /// </summary>
        /// <param name="jsonWebKey">The <see cref="IJsonWebKey"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> CreateIdentityProviderKeyAsync(IJsonWebKey jsonWebKey, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a specific IdP Key Credential by `kid` if it is not currently being used by an Active or Inactive IdP.
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteIdentityProviderKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific IdP Key Credential by `kid`
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> GetIdentityProviderKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an IdP from your organization.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches an IdP by `id`.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProvider"/> response.</returns>
        Task<IIdentityProvider> GetIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the configuration for an IdP.
        /// </summary>
        /// <param name="identityProvider">The <see cref="IIdentityProvider"/> resource.</param>
        /// <param name="idpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProvider"/> response.</returns>
        Task<IIdentityProvider> UpdateIdentityProviderAsync(IIdentityProvider identityProvider, string idpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates Certificate Signing Requests for an IdP
        /// </summary>
        /// <param name="idpId"></param>
        /// <returns>A collection of <see cref="ICsr"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ICsr> ListCsrsForIdentityProvider(string idpId);

        /// <summary>
        /// Generates a new key pair and returns a Certificate Signing Request for it.
        /// </summary>
        /// <param name="csrMetadata">The <see cref="ICsrMetadata"/> resource.</param>
        /// <param name="idpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICsr"/> response.</returns>
        Task<ICsr> GenerateCsrForIdentityProviderAsync(ICsrMetadata csrMetadata, string idpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revoke a Certificate Signing Request and delete the key pair from the IdP
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific Certificate Signing Request model by id
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICsr"/> response.</returns>
        Task<ICsr> GetCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishCerCertForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishBinaryCerCertForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishDerCertForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishBinaryDerCertForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishBinaryPemCertForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates signing key credentials for an IdP
        /// </summary>
        /// <param name="idpId"></param>
        /// <returns>A collection of <see cref="IJsonWebKey"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IJsonWebKey> ListIdentityProviderSigningKeys(string idpId);

        /// <summary>
        /// Generates a new X.509 certificate for an IdP signing key credential to be used for signing assertions sent to the IdP
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="validityYears">expiry of the IdP Key Credential</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> GenerateIdentityProviderSigningKeyAsync(string idpId, int? validityYears, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific IdP Key Credential by `kid`
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="keyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> GetIdentityProviderSigningKeyAsync(string idpId, string keyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Clones a X.509 certificate for an IdP signing key credential from a source IdP to target IdP
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="keyId"></param>
        /// <param name="targetIdpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> CloneIdentityProviderKeyAsync(string idpId, string keyId, string targetIdpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activates an inactive IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProvider"/> response.</returns>
        Task<IIdentityProvider> ActivateIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates an active IdP.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProvider"/> response.</returns>
        Task<IIdentityProvider> DeactivateIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Find all the users linked to an identity provider
        /// </summary>
        /// <param name="idpId"></param>
        /// <returns>A collection of <see cref="IIdentityProviderApplicationUser"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IIdentityProviderApplicationUser> ListIdentityProviderApplicationUsers(string idpId);

        /// <summary>
        /// Removes the link between the Okta user and the IdP user.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnlinkUserFromIdentityProviderAsync(string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a linked IdP user by ID
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProviderApplicationUser"/> response.</returns>
        Task<IIdentityProviderApplicationUser> GetIdentityProviderApplicationUserAsync(string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Links an Okta user to an existing Social Identity Provider. This does not support the SAML2 Identity Provider Type
        /// </summary>
        /// <param name="userIdentityProviderLinkRequest">The <see cref="IUserIdentityProviderLinkRequest"/> resource.</param>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IIdentityProviderApplicationUser"/> response.</returns>
        Task<IIdentityProviderApplicationUser> LinkUserToIdentityProviderAsync(IUserIdentityProviderLinkRequest userIdentityProviderLinkRequest, string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches the tokens minted by the Social Authentication Provider when the user authenticates with Okta via Social Auth.
        /// </summary>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="ISocialAuthToken"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ISocialAuthToken> ListSocialAuthTokens(string idpId, string userId);

    }
}
