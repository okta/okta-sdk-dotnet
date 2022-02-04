// <copyright file="ISessionsClient.Generated.cs" company="Okta, Inc">
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
    public partial interface ISessionsClient
    {
        /// <summary>
        /// Create Session with Session Token Creates a new session for a user with a valid session token. Use this API if, for example, you want to set the session cookie yourself instead of allowing Okta to set it, or want to hold the session ID in order to delete a session via the API instead of visiting the logout URL.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of ISession</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISession> CreateSessionAsync(ICreateSessionRequest body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// End Session End a session.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task EndSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get Session Get details about a session.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        ///  <returns>Task of ISession</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISession> GetSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Refresh Session Refresh a session.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        ///  <returns>Task of ISession</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ISession> RefreshSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

