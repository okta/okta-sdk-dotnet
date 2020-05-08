// <copyright file="IProtocolEndpoint.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a ProtocolEndpoint resource in the Okta API.</summary>
    public partial interface IProtocolEndpoint : IResource
    {
        string Binding { get; set; }

        string Destination { get; set; }

        string Type { get; set; }

        string Url { get; set; }

    }
}
