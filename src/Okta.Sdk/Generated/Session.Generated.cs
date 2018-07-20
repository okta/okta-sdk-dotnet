// <copyright file="Session.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Session : Resource, ISession
    {
        /// <inheritdoc/>
        public IList<SessionAuthenticationMethod> AuthenticationMethodReference => GetArrayProperty<SessionAuthenticationMethod>("amr");
        
        /// <inheritdoc/>
        public DateTimeOffset? CreatedAt => GetDateTimeProperty("createdAt");
        
        /// <inheritdoc/>
        public DateTimeOffset? ExpiresAt => GetDateTimeProperty("expiresAt");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public ISessionIdentityProvider Idp => GetResourceProperty<SessionIdentityProvider>("idp");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastFactorVerification => GetDateTimeProperty("lastFactorVerification");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastPasswordVerification => GetDateTimeProperty("lastPasswordVerification");
        
        /// <inheritdoc/>
        public string Login => GetStringProperty("login");
        
        /// <inheritdoc/>
        public SessionStatus Status => GetEnumProperty<SessionStatus>("status");
        
        /// <inheritdoc/>
        public string UserId => GetStringProperty("userId");
        
        /// <inheritdoc />
        public Task<ISession> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Sessions.RefreshSessionAsync(Id, cancellationToken);
        
    }
}
