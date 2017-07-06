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
    /// <inheritdoc/>
    public sealed partial class UserCredentials : Resource, IUserCredentials
    {
        /// <inheritdoc/>
        public PasswordCredential Password
        {
            get => GetResourceProperty<PasswordCredential>("password");
            set => this["password"] = value;
        }

        /// <inheritdoc/>
        public AuthenticationProvider Provider
        {
            get => GetResourceProperty<AuthenticationProvider>("provider");
            set => this["provider"] = value;
        }

        /// <inheritdoc/>
        public RecoveryQuestionCredential RecoveryQuestion
        {
            get => GetResourceProperty<RecoveryQuestionCredential>("recovery_question");
            set => this["recovery_question"] = value;
        }

    }
}
