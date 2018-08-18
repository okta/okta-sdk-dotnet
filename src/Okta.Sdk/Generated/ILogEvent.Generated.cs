// <copyright file="ILogEvent.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a LogEvent resource in the Okta API.</summary>
    public partial interface ILogEvent : IResource
    {
        ILogActor Actor { get; }

        ILogAuthenticationContext AuthenticationContext { get; }

        ILogClientInfo ClientInfo { get; }

        ILogDebugContext DebugContext { get; }

        string DisplayMessage { get; }

        string EventType { get; }

        string LegacyEventType { get; }

        ILogOutcome Outcome { get; }

        DateTimeOffset? Published { get; }

        ILogRequest Request { get; }

        ILogSecurityContext SecurityContext { get; }

        LogSeverity Severity { get; }

        IList<ILogTarget> Target { get; }

        ILogTransaction Transaction { get; }

        string Uuid { get; }

        string Version { get; }

    }
}
