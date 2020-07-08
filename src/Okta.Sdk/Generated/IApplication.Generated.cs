// <copyright file="IApplication.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Application resource in the Okta API.</summary>
    public partial interface IApplication : IResource
    {
        IApplicationAccessibility Accessibility { get; set; }

        DateTimeOffset? Created { get; }

        IApplicationCredentials Credentials { get; set; }

        IList<string> Features { get; set; }

        string Id { get; }

        string Label { get; set; }

        DateTimeOffset? LastUpdated { get; }

        IApplicationLicensing Licensing { get; set; }

        string Name { get; }

        Resource Profile { get; set; }

        IApplicationSettings Settings { get; set; }

        ApplicationSignOnMode SignOnMode { get; set; }

        string Status { get; }

        IApplicationVisibility Visibility { get; set; }

        Task ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IAppUser> ListApplicationUsers(
            string q = null, string query_scope = null, string after = null, int? limit = -1, string filter = null, string expand = null);

        Task<IAppUser> AssignUserToApplicationAsync(IAppUser appUser, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IAppUser> GetApplicationUserAsync(
            string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(IApplicationGroupAssignment applicationGroupAssignment, 
            string groupId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(
            string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> CloneApplicationKeyAsync(
            string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> GetApplicationKeyAsync(
            string keyId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IApplicationGroupAssignment> ListGroupAssignments(
            string q = null, string after = null, int? limit = -1, string expand = null);

        ICollectionClient<IJsonWebKey> ListKeys(
            );

        Task<IJsonWebKey> GenerateKeyAsync(
            int? validityYears = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<ICsr> GenerateCsrAsync(ICsrMetadata metadata, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task<ICsr> GetCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeCsrAsync(
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<ICsr> ListCsrs(
            );

        Task<IJsonWebKey> PublishCerCertAsync(string certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> PublishBinaryCerCertAsync(byte[] certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> PublishDerCertAsync(string certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> PublishBinaryDerCertAsync(byte[] certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IJsonWebKey> PublishBinaryPemCertAsync(byte[] certificate, 
            string csrId, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2Token> ListOAuth2Tokens(
            string expand = null, string after = null, int? limit = 20);

        Task RevokeOAuth2TokenForApplicationAsync(
            string tokenId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2Token> GetOAuth2TokenAsync(
            string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeOAuth2TokensAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<IOAuth2ScopeConsentGrant> ListScopeConsentGrants(
            string expand = null);

        Task<IOAuth2ScopeConsentGrant> GrantConsentToScopeAsync(IOAuth2ScopeConsentGrant oAuth2ScopeConsentGrant, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task RevokeScopeConsentGrantAsync(
            string grantId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IOAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(
            string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}
