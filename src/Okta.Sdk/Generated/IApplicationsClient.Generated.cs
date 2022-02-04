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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IApplicationsClient
    {
        /// <summary>
        /// Activate Application Activates an inactive application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ActivateApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Assign User to Application for SSO &amp; Provisioning Assigns an user to an application with [credentials](#application-user-credentials-object) and an app-specific [profile](#application-user-profile-object). Profile mappings defined for the application are first applied before applying any profile properties specified in the request.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="appId"></param>
        ///  <returns>Task of IAppUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAppUser> AssignUserToApplicationAsync(IAppUser body, string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Clone Application Key Credential Clones a X.509 certificate for an application key credential from a source application to target application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="keyId"></param>
        /// <param name="targetAid">Unique key of the target Application</param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> CloneApplicationKeyAsync(string appId, string keyId, string targetAid, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add Application Adds a new application to your Okta organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="oktaAccessGatewayAgent"> (optional)</param>
        /// <param name="activate">Executes activation lifecycle operation when creating the app (optional, default to true)</param>
        ///  <returns>Task of IApplication</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IApplication> CreateApplicationAsync(IApplication body, string oktaAccessGatewayAgent = null, bool? activate = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Assign Group to Application Assigns a group to an application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="groupId"></param>
        /// <param name="body"> (optional)</param>
        ///  <returns>Task of IApplicationGroupAssignment</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(string appId, string groupId, IApplicationGroupAssignment body = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deactivate Application Deactivates an active application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeactivateApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete Application Removes an inactive application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Remove Group from Application Removes a group assignment from an application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="groupId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteApplicationGroupAssignmentAsync(string appId, string groupId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Remove User from Application Removes an assignment for a user from an application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="sendEmail"> (optional, default to false)</param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteApplicationUserAsync(string appId, string userId, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Generates a new X.509 certificate for an application key credential
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="validityYears"> (optional)</param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> GenerateApplicationKeyAsync(string appId, int? validityYears = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Generate Certificate Signing Request for Application Generates a new key pair and returns the Certificate Signing Request for it.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="appId"></param>
        ///  <returns>Task of ICsr</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ICsr> GenerateCsrForApplicationAsync(ICsrMetadata body, string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Application Fetches an application from your Okta organization by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IApplication</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IApplication> GetApplicationAsync(string appId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Assigned Group for Application Fetches an application group assignment
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="groupId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IApplicationGroupAssignment</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IApplicationGroupAssignment> GetApplicationGroupAssignmentAsync(string appId, string groupId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Key Credential for Application Gets a specific application key credential by kid
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="keyId"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> GetApplicationKeyAsync(string appId, string keyId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Assigned User for Application Fetches a specific user assignment for application by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IAppUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAppUser> GetApplicationUserAsync(string appId, string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Certificate Signing Request Fetches a certificate signing request for the app by &#x60;id&#x60;.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        ///  <returns>Task of ICsr</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ICsr> GetCsrForApplicationAsync(string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets a token for the specified application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="tokenId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IOAuth2Token</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2Token> GetOAuth2TokenForApplicationAsync(string appId, string tokenId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Fetches a single scope consent grant for the application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="grantId"></param>
        /// <param name="expand"> (optional)</param>
        ///  <returns>Task of IOAuth2ScopeConsentGrant</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2ScopeConsentGrant> GetScopeConsentGrantAsync(string appId, string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Grants consent for the application to request an OAuth 2.0 Okta scope
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="appId"></param>
        ///  <returns>Task of IOAuth2ScopeConsentGrant</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IOAuth2ScopeConsentGrant> GrantConsentToScopeAsync(IOAuth2ScopeConsentGrant body, string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List Groups Assigned to Application Enumerates group assignments for an application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="q"> (optional)</param>
        /// <param name="after">Specifies the pagination cursor for the next page of assignments (optional)</param>
        /// <param name="limit">Specifies the number of results for a page (optional, default to -1)</param>
        /// <param name="expand"> (optional)</param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IApplicationGroupAssignment> ListApplicationGroupAssignments(string appId, string q = null, string after = null, int? limit = null, string expand = null);
        /// <summary>
        /// List Key Credentials for Application Enumerates key credentials for an application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IJsonWebKey> ListApplicationKeys(string appId);
        /// <summary>
        /// List Users Assigned to Application Enumerates all assigned [application users](#application-user-model) for an application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="q"> (optional)</param>
        /// <param name="queryScope"> (optional)</param>
        /// <param name="after">specifies the pagination cursor for the next page of assignments (optional)</param>
        /// <param name="limit">specifies the number of results for a page (optional, default to -1)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="expand"> (optional)</param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IAppUser> ListApplicationUsers(string appId, string q = null, string queryScope = null, string after = null, int? limit = null, string filter = null, string expand = null);
        /// <summary>
        /// List Applications Enumerates apps added to your organization with pagination. A subset of apps can be returned that match a supported filter expression or query.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="q"> (optional)</param>
        /// <param name="after">Specifies the pagination cursor for the next page of apps (optional)</param>
        /// <param name="limit">Specifies the number of results for a page (optional, default to -1)</param>
        /// <param name="filter">Filters apps by status, user.id, group.id or credentials.signing.kid expression (optional)</param>
        /// <param name="expand">Traverses users link relationship and optionally embeds Application User resource (optional)</param>
        /// <param name="includeNonDeleted"> (optional, default to false)</param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IApplication> ListApplications(string q = null, string after = null, int? limit = null, string filter = null, string expand = null, bool? includeNonDeleted = null);
        /// <summary>
        /// List Certificate Signing Requests for Application Enumerates Certificate Signing Requests for an application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ICsr> ListCsrsForApplication(string appId);
        /// <summary>
        ///  Lists all tokens for the application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="expand"> (optional)</param>
        /// <param name="after"> (optional)</param>
        /// <param name="limit"> (optional, default to 20)</param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2Token> ListOAuth2TokensForApplication(string appId, string expand = null, string after = null, int? limit = null);
        /// <summary>
        ///  Lists all scope consent grants for the application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="expand"> (optional)</param>
        /// A collection of <see cref="IApplicationsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IOAuth2ScopeConsentGrant> ListScopeConsentGrants(string appId, string expand = null);
        /// <summary>
        /// Publish Certificate Signing Request Updates a certificate signing request for the app with a signed X.509 certificate and adds it into the application key credentials
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        ///  <returns>Task of IJsonWebKey</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IJsonWebKey> PublishCsrFromApplicationAsync(string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Revoke Certificate Signing Request Revokes a certificate signing request and deletes the key pair from the application.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="csrId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeCsrFromApplicationAsync(string appId, string csrId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes the specified token for the specified application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="tokenId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeOAuth2TokenForApplicationAsync(string appId, string tokenId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes all tokens for the specified application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeOAuth2TokensForApplicationAsync(string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Revokes permission for the application to request the given scope
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="appId"></param>
        /// <param name="grantId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RevokeScopeConsentGrantAsync(string appId, string grantId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update Application Updates an application in your organization.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="appId"></param>
        ///  <returns>Task of IApplication</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IApplication> UpdateApplicationAsync(IApplication body, string appId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update Application Profile for Assigned User Updates a user&#x27;s profile for an application
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        ///  <returns>Task of IAppUser</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IAppUser> UpdateApplicationUserAsync(IAppUser body, string appId, string userId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

