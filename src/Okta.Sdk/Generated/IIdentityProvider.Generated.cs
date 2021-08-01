// <copyright file="IIdentityProvider.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a IdentityProvider resource in the Okta API.</summary>
    public partial interface IIdentityProvider : IResource
    {
        DateTimeOffset? Created { get; }

        string Id { get; }

        string IssuerMode { get; set; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        IIdentityProviderPolicy Policy { get; set; }

        IProtocol Protocol { get; set; }

        string Status { get; set; }

        string Type { get; set; }

        ICollectionClient<ICsr> ListSigningCsrs(
            );

        Task<ICsr> GenerateCsrAsync(ICsrMetadata csrMetadata, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteSigningCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        Task<ICsr> GetSigningCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IJsonWebKey> ListSigningKeys(
            );

        Task<IJsonWebKey> GenerateSigningKeyAsync(
            int? validityYears, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> GetSigningKeyAsync(
            string keyId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> CloneKeyAsync(
            string keyId, string targetIdpId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IIdentityProvider> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IIdentityProvider> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IIdentityProviderApplicationUser> ListUsers(
            );

        Task UnlinkUserAsync(
            string userId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IIdentityProviderApplicationUser> GetUserAsync(
            string userId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IIdentityProviderApplicationUser> LinkUserAsync(IUserIdentityProviderLinkRequest userIdentityProviderLinkRequest, 
            string userId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<ISocialAuthToken> ListSocialAuthTokens(
            string userId);

    }
}
