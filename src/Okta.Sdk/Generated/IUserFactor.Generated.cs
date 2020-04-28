// <copyright file="IUserFactor.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a UserFactor resource in the Okta API.</summary>
    public partial interface IUserFactor : IResource
    {
        DateTimeOffset? Created { get; }

        FactorType FactorType { get; set; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        FactorProvider Provider { get; set; }

        FactorStatus Status { get; }

        IVerifyFactorRequest Verify { get; set; }

        Task<IUserFactor> ActivateAsync(ActivateFactorRequest activateFactorRequest, 
            string userId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IVerifyUserFactorResponse> VerifyAsync(VerifyFactorRequest verifyFactorRequest, 
            string userId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken));

    }
}
