// <copyright file="ISessionsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Session resources.</summary>
    public partial interface ISessionsClient
    {
        /// <summary>
        /// Creates a new session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID in order to delete a session via the API instead of visiting the logout URL.
        /// </summary>
        /// <param name="createSessionRequest">The <see cref="ICreateSessionRequest"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISession"/> response.</returns>
        Task<ISession> CreateSessionAsync(ICreateSessionRequest createSessionRequest, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task EndSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get details about a session.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISession"/> response.</returns>
        Task<ISession> GetSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISession"/> response.</returns>
        Task<ISession> RefreshSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
