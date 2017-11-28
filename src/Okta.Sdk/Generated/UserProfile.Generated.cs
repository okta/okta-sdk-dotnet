// <copyright file="UserProfile.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
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
    public sealed partial class UserProfile : Resource, IUserProfile
    {
        /// <inheritdoc/>
        public string Email
        {
            get => GetStringProperty("email");
            set => this["email"] = value;
        }

        /// <inheritdoc/>
        public string FirstName
        {
            get => GetStringProperty("firstName");
            set => this["firstName"] = value;
        }

        /// <inheritdoc/>
        public string LastName
        {
            get => GetStringProperty("lastName");
            set => this["lastName"] = value;
        }

        /// <inheritdoc/>
        public string Login
        {
            get => GetStringProperty("login");
            set => this["login"] = value;
        }

        /// <inheritdoc/>
        public string MobilePhone
        {
            get => GetStringProperty("mobilePhone");
            set => this["mobilePhone"] = value;
        }

        /// <inheritdoc/>
        public string SecondEmail
        {
            get => GetStringProperty("secondEmail");
            set => this["secondEmail"] = value;
        }

    }
}
