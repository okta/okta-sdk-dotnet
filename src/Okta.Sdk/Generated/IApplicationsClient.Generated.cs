// <copyright file="IApplicationsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

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
        /// Fetches an application from your Okta organization by &#x60;id&#x60;.
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
        /// Enumerates key credentials for an application
        /// </summary>
        /// <param name="appId"></param>
        /// <returns>A collection of <see cref="IJsonWebKey"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IJsonWebKey> ListApplicationKeys(string appId);

        /// <summary>
        /// Gets a specific [application key credential](#application-key-credential-model) by &#x60;kid&#x60;
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
        /// Fetches a specific user assignment for application by &#x60;id&#x60;.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAppUser"/> response.</returns>
        Task<IAppUser> GetApplicationUserAsync(string appId, string userId, string expand = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a user&#x27;s profile for an application
        /// </summary>
        /// <param name="appUser">The <see cref="IAppUser"/> resource.</param>
        /// <param name="appId"></param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IAppUser"/> response.</returns>
        Task<IAppUser> UpdateApplicationUserAsync(IAppUser appUser, string appId, string userId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
