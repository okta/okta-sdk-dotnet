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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IIdentityProvidersClient
    {
        /// <summary>
        /// Activate Identity Provider Activates an inactive IdP.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        ///  <returns>Task of IIdentityProvider</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProvider> ActivateIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Clone Signing Key Credential for IdP Clones a X.509 certificate for an IdP signing key credential from a source IdP to target IdP
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="keyId"></param>
        /// <param name="targetIdpId"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> CloneIdentityProviderKeyAsync(string idpId, string keyId, string targetIdpId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add Identity Provider Adds a new IdP to your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IIdentityProvider</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProvider> CreateIdentityProviderAsync(IIdentityProvider body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add X.509 Certificate Public Key Adds a new X.509 certificate credential to the IdP key store.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> CreateIdentityProviderKeyAsync(IJsonWebKey body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deactivate Identity Provider Deactivates an active IdP.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        ///  <returns>Task of IIdentityProvider</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProvider> DeactivateIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete Identity Provider Removes an IdP from your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete Key Deletes a specific IdP Key Credential by &#x60;kid&#x60; if it is not currently being used by an Active or Inactive IdP.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="keyId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteIdentityProviderKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Generate Certificate Signing Request for IdP Generates a new key pair and returns a Certificate Signing Request for it.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="idpId"></param>
        ///  <returns>Task of ICsr</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ICsr> GenerateCsrForIdentityProviderAsync(ICsrMetadata body, string idpId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Generate New IdP Signing Key Credential Generates a new X.509 certificate for an IdP signing key credential to be used for signing assertions sent to the IdP
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="validityYears">expiry of the IdP Key Credential</param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> GenerateIdentityProviderSigningKeyAsync(string idpId, int? validityYears, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets a specific Certificate Signing Request model by id
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        ///  <returns>Task of ICsr</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ICsr> GetCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Identity Provider Fetches an IdP by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        ///  <returns>Task of IIdentityProvider</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProvider> GetIdentityProviderAsync(string idpId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Fetches a linked IdP user by ID
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of IIdentityProviderApplicationUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProviderApplicationUser> GetIdentityProviderApplicationUserAsync(string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Key Gets a specific IdP Key Credential by &#x60;kid&#x60;
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="keyId"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> GetIdentityProviderKeyAsync(string keyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Signing Key Credential for IdP Gets a specific IdP Key Credential by &#x60;kid&#x60;
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="keyId"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> GetIdentityProviderSigningKeyAsync(string idpId, string keyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Link a user to a Social IdP without a transaction Links an Okta user to an existing Social Identity Provider. This does not support the SAML2 Identity Provider Type
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of IIdentityProviderApplicationUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProviderApplicationUser> LinkUserToIdentityProviderAsync(IUserIdentityProviderLinkRequest body, string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List Certificate Signing Requests for IdP Enumerates Certificate Signing Requests for an IdP
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// A collection of <see cref="IIdentityProvidersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ICsr> ListCsrsForIdentityProvider(string idpId);
        /// <summary>
        /// Find Users Find all the users linked to an identity provider
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// A collection of <see cref="IIdentityProvidersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IIdentityProviderApplicationUser> ListIdentityProviderApplicationUsers(string idpId);
        /// <summary>
        /// List Keys Enumerates IdP key credentials.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="after">Specifies the pagination cursor for the next page of keys (optional)</param>
        /// <param name="limit">Specifies the number of key results in a page (optional, default to 20)</param>
        /// A collection of <see cref="IIdentityProvidersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IJsonWebKey> ListIdentityProviderKeys(string after = null, int? limit = null);
        /// <summary>
        /// List Signing Key Credentials for IdP Enumerates signing key credentials for an IdP
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// A collection of <see cref="IIdentityProvidersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IJsonWebKey> ListIdentityProviderSigningKeys(string idpId);
        /// <summary>
        /// List Identity Providers Enumerates IdPs in your organization with pagination. A subset of IdPs can be returned that match a supported filter expression or query.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="q">Searches the name property of IdPs for matching value (optional)</param>
        /// <param name="after">Specifies the pagination cursor for the next page of IdPs (optional)</param>
        /// <param name="limit">Specifies the number of IdP results in a page (optional, default to 20)</param>
        /// <param name="type">Filters IdPs by type (optional)</param>
        /// A collection of <see cref="IIdentityProvidersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IIdentityProvider> ListIdentityProviders(string q = null, string after = null, int? limit = null, string type = null);
        /// <summary>
        /// Social Authentication Token Operation Fetches the tokens minted by the Social Authentication Provider when the user authenticates with Okta via Social Auth.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        /// A collection of <see cref="IIdentityProvidersClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ISocialAuthToken> ListSocialAuthTokens(string idpId, string userId);
        /// <summary>
        ///  Update the Certificate Signing Request with a signed X.509 certificate and add it into the signing key credentials for the IdP.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> PublishCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revoke a Certificate Signing Request and delete the key pair from the IdP
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="csrId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeCsrForIdentityProviderAsync(string idpId, string csrId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Unlink User from IdP Removes the link between the Okta user and the IdP user.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="idpId"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task UnlinkUserFromIdentityProviderAsync(string idpId, string userId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update Identity Provider Updates the configuration for an IdP.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="idpId"></param>
        ///  <returns>Task of IIdentityProvider</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IIdentityProvider> UpdateIdentityProviderAsync(IIdentityProvider body, string idpId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

