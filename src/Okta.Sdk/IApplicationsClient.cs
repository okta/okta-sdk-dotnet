// <copyright file="IApplicationsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Application resources.</summary>
    public partial interface IApplicationsClient : IAsyncEnumerable<IApplication>
    {
        /// <summary>
        /// Gets an application by id
        /// </summary>
        /// <typeparam name="T">The application type</typeparam>
        /// <param name="appId">The application id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<T> GetApplicationAsync<T>(string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IApplication;

        /// <summary>
        /// Updates an application
        /// </summary>
        /// <typeparam name="T">The application type</typeparam>
        /// <param name="application">The application to update</param>
        /// <param name="appId">The application id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<T> UpdateApplicationAsync<T>(IApplication application, string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IApplication;

        /// <summary>
        /// Adds an new application that uses HTTP Basic Authentication Scheme
        /// </summary>
        /// <param name="basicAuthApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateBasicAuthApplicationOptions basicAuthApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds an new bookmark application
        /// </summary>
        /// <param name="bookmarkApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateBookmarkApplicationOptions bookmarkApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a SWA application that requires a plugin
        /// </summary>
        /// <param name="swaApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateSwaApplicationOptions swaApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a SWA application that does not require a browser plugin
        /// </summary>
        /// <param name="swaNoPluginApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateSwaNoPluginApplicationOptions swaNoPluginApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a SWA application that requires a browser plugin and supports 3 CSS selectors for the login form.
        /// </summary>
        /// <param name="swaThreeFieldApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateSwaThreeFieldApplicationOptions swaThreeFieldApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a SWA application. This application is only available to the org that creates it.
        /// </summary>
        /// <param name="swaCustomApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateSwaCustomApplicationOptions swaCustomApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a SAML 2.0 application. This application is only available to the org that creates it.
        /// </summary>
        /// <param name="samlApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateSamlApplicationOptions samlApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds a WS-Federation Passive Requestor Profile application with a SAML 2.0 token.
        /// </summary>
        /// <param name="wsFederationApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateWsFederationApplicationOptions wsFederationApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds an OAuth 2.0 client application. This application is only available to the org that creates it.
        /// </summary>
        /// <param name="openIdApplicationOptions">The application settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplication"/> response.</returns>
        Task<IApplication> CreateApplicationAsync(CreateOpenIdConnectApplication openIdApplicationOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Assigns a group to an application
        /// </summary>
        /// <param name="options">The group assignment settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IApplicationGroupAssignment"/> response.</returns>
        Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(CreateApplicationGroupAssignmentOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Assigns a user without a profile to an application for SSO
        /// </summary>
        /// <param name="options">The user assignment settings helper</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IAppUser"/> response.</returns>
        Task<IAppUser> AssignUserToApplicationAsync(AssignUserToApplicationOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an assignment for a user from an application.
        /// </summary>
        /// <param name="appId">The application ID</param>
        /// <param name="userId">The user ID</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        /// <remarks>Explicit overload to support backward compatibility.</remarks>
        Task DeleteApplicationUserAsync(string appId, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an assignment for a user from an application.
        /// </summary>
        /// <param name="appId">The application ID</param>
        /// <param name="userId">The user ID</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        /// <remarks>Explicit overload to support backward compatibility.</remarks>
        Task DeleteApplicationUserAsync(string appId, string userId);
    }
}
