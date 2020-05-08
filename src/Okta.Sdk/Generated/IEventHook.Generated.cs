// <copyright file="IEventHook.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a EventHook resource in the Okta API.</summary>
    public partial interface IEventHook : IResource
    {
        IEventHookChannel Channel { get; set; }

        DateTimeOffset? Created { get; }

        string CreatedBy { get; set; }

        IEventSubscriptions Events { get; set; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        string Status { get; set; }

        string VerificationStatus { get; set; }

        Task<IEventHook> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IEventHook> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IEventHook> VerifyAsync(
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
