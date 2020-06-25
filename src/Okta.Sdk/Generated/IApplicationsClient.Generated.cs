// <copyright file="IApplicationsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta Application resources.</summary>
    public partial interface IApplicationsClient
    {
        /// <summary>
        /// Enumerates apps added to your organization with pagination. A subset of apps can be returned that match a supported filter expression or query.
        /// </summary>
        /// <param name="q"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of apps</param>
        /// <param name="limit">Specifies the number of results for a page</param>
        /// <param name="filter">Filters apps by status, user.id, group.id or credentials.signing.kid expression</param>
        /// <param name="expand">Traverses users link relationship and optionally embeds Application User resource</param>
        /// <param name="includeNonDeleted"></param>
        /// <returns>A collection of <see cref="IApplication"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IApplication> ListApplications(string q = null, string after = null, int? limit = -1, string filter = null, string expand = null, bool? includeNonDeleted = false);

        /// <summary>
        /// Adds a new application to your Okta organization.
        /// </summary>
        /// <param name="application">The <see cref="IApplication"/> resource.</param>
        /// <param name="activate">Executes activation lifecycle operation when creating the app</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(IApplication application, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an inactive application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches an application from your Okta organization by `id`.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> GetApplicationAsync(string appId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an application in your organization.
        /// </summary>
        /// <param name="application">The <see cref="IApplication"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> UpdateApplicationAsync(IApplication application, string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates Certificate Signing Requests for an application
        /// </summary>
        /// <param name="appId"></param>
        /// <returns>A collection of <see cref="ICsr"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ICsr> ListCsrsForApplication(string appId);

        /// <summary>
        /// Generates a new key pair and returns the Certificate Signing Request for it.
        /// </summary>
        /// <param name="metadata">The <see cref="ICsrMetadata"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICsr"/> response.</returns>
        Task<ICsr> GenerateCsrForApplicationAsync(ICsrMetadata metadata, string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeCsrFromApplicationAsync(string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICsr"/> response.</returns>
        Task<ICsr> GetCsrForApplicationAsync(string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64EncodedCertificateData">The <see cref="string"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishCerCertAsync(string base64EncodedCertificateData, string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate">The <see cref="byte[]"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishBinaryCerCertAsync(byte[] certificate, string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64EncodedCertificateData">The <see cref="string"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishDerCertAsync(string base64EncodedCertificateData, string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate">The <see cref="byte[]"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishBinaryDerCertAsync(byte[] certificate, string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate">The <see cref="byte[]"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> PublishBinaryPemCertAsync(byte[] certificate, string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates key credentials for an application
        /// </summary>
        /// <param name="appId"></param>
        /// <returns>A collection of <see cref="IJsonWebKey"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IJsonWebKey> ListApplicationKeys(string appId);

        /// <summary>
        /// Generates a new X.509 certificate for an application key credential
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="validityYears"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> GenerateApplicationKeyAsync(string appId, int? validityYears = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific application key credential by kid
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="keyId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> GetApplicationKeyAsync(string appId, string keyId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Clones a X.509 certificate for an application key credential from a source application to target application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="keyId"></param>
        /// <param name="targetAid">Unique key of the target Application</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IJsonWebKey"/> response.</returns>
        Task<IJsonWebKey> CloneApplicationKeyAsync(string appId, string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all scope consent grants for the application
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IOAuth2ScopeConsentGrant"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2ScopeConsentGrant> ListScopeConsentGrants(string appId, string expand = null);

        /// <summary>
        /// Grants consent for the application to request an OAuth 2.0 Okta scope
        /// </summary>
        /// <param name="oAuth2ScopeConsentGrant">The <see cref="IOAuth2ScopeConsentGrant"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2ScopeConsentGrant"/> response.</returns>
        Task<IOAuth2ScopeConsentGrant> GrantConsentToScopeAsync(IOAuth2ScopeConsentGrant oAuth2ScopeConsentGrant, string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revokes permission for the application to request the given scope
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="grantId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeScopeConsentGrantAsync(string appId, string grantId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a single scope consent grant for the application
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="grantId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2ScopeConsentGrant"/> response.</returns>
        Task<IOAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(string appId, string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates group assignments for an application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="q"></param>
        /// <param name="after">Specifies the pagination cursor for the next page of assignments</param>
        /// <param name="limit">Specifies the number of results for a page</param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IApplicationGroupAssignment"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IApplicationGroupAssignment> ListApplicationGroupAssignments(string appId, string q = null, string after = null, int? limit = -1, string expand = null);

        /// <summary>
        /// Removes a group assignment from an application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteApplicationGroupAssignmentAsync(string appId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches an application group assignment
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="groupId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IApplicationGroupAssignment"/> response.</returns>
        Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(string appId, string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Assigns a group to an application
        /// </summary>
        /// <param name="applicationGroupAssignment">The <see cref="IApplicationGroupAssignment"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IApplicationGroupAssignment"/> response.</returns>
        Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(IApplicationGroupAssignment applicationGroupAssignment, string appId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activates an inactive application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task ActivateApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates an active application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeactivateApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Revokes all tokens for the specified application
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeOAuth2TokensForApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all tokens for the application
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="expand"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <returns>A collection of <see cref="IOAuth2Token"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IOAuth2Token> ListOAuth2TokensForApplication(string appId, string expand = null, string after = null, int? limit = 20);

        /// <summary>
        /// Revokes the specified token for the specified application
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="tokenId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task RevokeOAuth2TokenForApplicationAsync(string appId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a token for the specified application
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="tokenId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IOAuth2Token"/> response.</returns>
        Task<IOAuth2Token> GetOAuth2TokenForApplicationAsync(string appId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all assigned [application users](#application-user-model) for an application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="q"></param>
        /// <param name="query_scope"></param>
        /// <param name="after">specifies the pagination cursor for the next page of assignments</param>
        /// <param name="limit">specifies the number of results for a page</param>
        /// <param name="filter"></param>
        /// <param name="expand"></param>
        /// <returns>A collection of <see cref="IAppUser"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IAppUser> ListApplicationUsers(string appId, string q = null, string query_scope = null, string after = null, int? limit = -1, string filter = null, string expand = null);

        /// <summary>
        /// Assigns an user to an application with [credentials](#application-user-credentials-object) and an app-specific [profile](#application-user-profile-object). Profile mappings defined for the application are first applied before applying any profile properties specified in the request.
        /// </summary>
        /// <param name="appUser">The <see cref="IAppUser"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAppUser"/> response.</returns>
        Task<IAppUser> AssignUserToApplicationAsync(IAppUser appUser, string appId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an assignment for a user from an application.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteApplicationUserAsync(string appId, string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a specific user assignment for application by `id`.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAppUser"/> response.</returns>
        Task<IAppUser> GetApplicationUserAsync(string appId, string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a user's profile for an application
        /// </summary>
        /// <param name="appUser">The <see cref="IAppUser"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAppUser"/> response.</returns>
        Task<IAppUser> UpdateApplicationUserAsync(IAppUser appUser, string appId, string userId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
