// <copyright file="ILogAuthenticationContext.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a LogAuthenticationContext resource in the Okta API.</summary>
    public partial interface ILogAuthenticationContext : IResource
    {
        LogAuthenticationProvider AuthenticationProvider { get; }

        int? AuthenticationStep { get; }

        IList<LogCredentialProvider> CredentialProvider { get; }

        IList<LogCredentialType> CredentialType { get; }

        string ExternalSessionId { get; }

        string Interface { get; }

        ILogIssuer Issuer { get; }

    }
}
