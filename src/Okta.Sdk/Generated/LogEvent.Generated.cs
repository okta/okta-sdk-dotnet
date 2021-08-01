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
        public ILogActor Actor 
        {
            get => GetResourceProperty<LogActor>("actor");
            set => this["actor"] = value;
        }
        
        /// <inheritdoc/>
        public ILogAuthenticationContext AuthenticationContext 
        {
            get => GetResourceProperty<LogAuthenticationContext>("authenticationContext");
            set => this["authenticationContext"] = value;
        }
        
        /// <inheritdoc/>
        public ILogClientInfo ClientInfo 
        {
            get => GetResourceProperty<LogClientInfo>("client");
            set => this["client"] = value;
        }
        
        /// <inheritdoc/>
        public ILogDebugContext DebugContext 
        {
            get => GetResourceProperty<LogDebugContext>("debugContext");
            set => this["debugContext"] = value;
        }
        
        /// <inheritdoc/>
        public string DisplayMessage => GetStringProperty("displayMessage");
        
        /// <inheritdoc/>
        public string EventType => GetStringProperty("eventType");
        
        /// <inheritdoc/>
        public string LegacyEventType => GetStringProperty("legacyEventType");
        
        /// <inheritdoc/>
        public ILogOutcome Outcome 
        {
            get => GetResourceProperty<LogOutcome>("outcome");
            set => this["outcome"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Published => GetDateTimeProperty("published");
        
        /// <inheritdoc/>
        public ILogRequest Request 
        {
            get => GetResourceProperty<LogRequest>("request");
            set => this["request"] = value;
        }
        
        /// <inheritdoc/>
        public ILogSecurityContext SecurityContext 
        {
            get => GetResourceProperty<LogSecurityContext>("securityContext");
            set => this["securityContext"] = value;
        }
        
        /// <inheritdoc/>
        public LogSeverity Severity 
        {
            get => GetEnumProperty<LogSeverity>("severity");
            set => this["severity"] = value;
        }
        
        /// <inheritdoc/>
        public IList<ILogTarget> Target => GetArrayProperty<ILogTarget>("target");
        
        /// <inheritdoc/>
        public ILogTransaction Transaction 
        {
            get => GetResourceProperty<LogTransaction>("transaction");
            set => this["transaction"] = value;
        }
        
        /// <inheritdoc/>
        public string Uuid => GetStringProperty("uuid");
        
        /// <inheritdoc/>
        public string Version => GetStringProperty("version");
        
    }
}
