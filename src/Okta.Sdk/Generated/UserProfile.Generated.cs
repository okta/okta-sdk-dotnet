// <copyright file="UserProfile.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>Represents a UserProfile resource in the Okta API.</summary>
    public sealed partial class UserProfile : Resource, IUserProfile
    {
        public UserProfile()
            : base(ResourceBehavior.ChangeTracking)
        {
        }
        public string Email
        {
            get => GetStringProperty("email");
            set => this["email"] = value;
        }

        public string FirstName
        {
            get => GetStringProperty("firstName");
            set => this["firstName"] = value;
        }

        public string LastName
        {
            get => GetStringProperty("lastName");
            set => this["lastName"] = value;
        }

        public string Login
        {
            get => GetStringProperty("login");
            set => this["login"] = value;
        }

        public string MobilePhone
        {
            get => GetStringProperty("mobilePhone");
            set => this["mobilePhone"] = value;
        }

        public string SecondEmail
        {
            get => GetStringProperty("secondEmail");
            set => this["secondEmail"] = value;
        }

    }
}
