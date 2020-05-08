// <copyright file="ICreateUserRequest.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a CreateUserRequest resource in the Okta API.</summary>
    public partial interface ICreateUserRequest : IResource
    {
        IUserCredentials Credentials { get; set; }

        IList<string> GroupIds { get; set; }

        IUserProfile Profile { get; set; }

        IUserType Type { get; set; }

    }
}
