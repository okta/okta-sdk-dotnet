// <copyright file="IProtocol.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Protocol resource in the Okta API.</summary>
    public partial interface IProtocol : IResource
    {
        IProtocolAlgorithms Algorithms { get; set; }

        IIdentityProviderCredentials Credentials { get; set; }

        IProtocolEndpoints Endpoints { get; set; }

        IProtocolEndpoint Issuer { get; set; }

        IProtocolRelayState RelayState { get; set; }

        IList<string> Scopes { get; set; }

        IProtocolSettings Settings { get; set; }

        string Type { get; set; }

    }
}
