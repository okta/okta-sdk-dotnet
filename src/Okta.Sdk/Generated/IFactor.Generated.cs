// <copyright file="IFactor.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Factor resource in the Okta API.</summary>
    public partial interface IFactor : IResource
    {
        string Device { get; set; }

        string DeviceType { get; }

        FactorType FactorType { get; set; }

        string Id { get; }

        string MfaStateTokenId { get; set; }

        IFactorProfile Profile { get; set; }

        FactorProvider Provider { get; set; }

        bool? RechallengeExistingFactor { get; set; }

        string SessionId { get; set; }

        FactorStatus Status { get; }

        int? TokenLifetimeSeconds { get; set; }

        string UserId { get; set; }

        IVerifyFactorRequest Verify { get; set; }

        Task<IFactor> ActivateAsync(VerifyFactorRequest verifyFactorRequest, string userId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IVerifyFactorResponse> VerifyAsync(VerifyFactorRequest verifyFactorRequest, string userId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken));

    }
}
