// <copyright file="CreateUserRequest.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class CreateUserRequest : Resource, ICreateUserRequest
    {
        /// <inheritdoc/>
        public IUserCredentials Credentials 
        {
            get => GetResourceProperty<UserCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> GroupIds 
        {
            get => GetArrayProperty<string>("groupIds");
            set => this["groupIds"] = value;
        }
        
        /// <inheritdoc/>
        public IUserProfile Profile 
        {
            get => GetResourceProperty<UserProfile>("profile");
            set => this["profile"] = value;
        }
        
        /// <inheritdoc/>
        public IUserType Type 
        {
            get => GetResourceProperty<UserType>("type");
            set => this["type"] = value;
        }
        
    }
}
