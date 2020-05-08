// <copyright file="IInlineHook.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a InlineHook resource in the Okta API.</summary>
    public partial interface IInlineHook : IResource
    {
        IInlineHookChannel Channel { get; set; }

        DateTimeOffset? Created { get; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        string Status { get; set; }

        string Type { get; set; }

        string Version { get; set; }

        Task<IInlineHook> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IInlineHook> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IInlineHookResponse> ExecuteAsync(IInlineHookPayload payloadData, 
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
