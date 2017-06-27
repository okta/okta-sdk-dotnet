// <copyright file="UserCredentials.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a UserCredentials resource in the Okta API.</summary>
    public sealed partial class UserCredentials : Resource, IUserCredentials
    {
        public PasswordCredential Password
        {
            get => GetResourceProperty<PasswordCredential>("password");
            set => this["password"] = value;
        }

        public AuthenticationProvider Provider
        {
            get => GetResourceProperty<AuthenticationProvider>("provider");
            set => this["provider"] = value;
        }

        public RecoveryQuestionCredential RecoveryQuestion
        {
            get => GetResourceProperty<RecoveryQuestionCredential>("recovery_question");
            set => this["recovery_question"] = value;
        }

    }
}
