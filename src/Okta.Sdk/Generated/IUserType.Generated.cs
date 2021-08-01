// <copyright file="IUserType.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a UserType resource in the Okta API.</summary>
    public partial interface IUserType : IResource
    {
        DateTimeOffset? Created { get; }

        string CreatedBy { get; }

        bool? Default { get; }

        string Description { get; set; }

        string DisplayName { get; set; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string LastUpdatedBy { get; }

        string Name { get; set; }

        Task<IUserType> ReplaceUserTypeAsync(IUserType userType, 
            string typeId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
