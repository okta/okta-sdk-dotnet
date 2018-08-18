// <copyright file="LogEvent.Generated.cs" company="Okta, Inc">
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
    public sealed partial class LogEvent : Resource, ILogEvent
    {
        /// <inheritdoc/>
        public ILogActor Actor => GetResourceProperty<LogActor>("actor");
        
        /// <inheritdoc/>
        public ILogAuthenticationContext AuthenticationContext => GetResourceProperty<LogAuthenticationContext>("authenticationContext");
        
        /// <inheritdoc/>
        public ILogClientInfo ClientInfo => GetResourceProperty<LogClientInfo>("client");
        
        /// <inheritdoc/>
        public ILogDebugContext DebugContext => GetResourceProperty<LogDebugContext>("debugContext");
        
        /// <inheritdoc/>
        public string DisplayMessage => GetStringProperty("displayMessage");
        
        /// <inheritdoc/>
        public string EventType => GetStringProperty("eventType");
        
        /// <inheritdoc/>
        public string LegacyEventType => GetStringProperty("legacyEventType");
        
        /// <inheritdoc/>
        public ILogOutcome Outcome => GetResourceProperty<LogOutcome>("outcome");
        
        /// <inheritdoc/>
        public DateTimeOffset? Published => GetDateTimeProperty("published");
        
        /// <inheritdoc/>
        public ILogRequest Request => GetResourceProperty<LogRequest>("request");
        
        /// <inheritdoc/>
        public ILogSecurityContext SecurityContext => GetResourceProperty<LogSecurityContext>("securityContext");
        
        /// <inheritdoc/>
        public LogSeverity Severity => GetEnumProperty<LogSeverity>("severity");
        
        /// <inheritdoc/>
        public IList<ILogTarget> Target => GetArrayProperty<ILogTarget>("target");
        
        /// <inheritdoc/>
        public ILogTransaction Transaction => GetResourceProperty<LogTransaction>("transaction");
        
        /// <inheritdoc/>
        public string Uuid => GetStringProperty("uuid");
        
        /// <inheritdoc/>
        public string Version => GetStringProperty("version");
        
    }
}
