// <copyright file="UserCredentials.Generated.cs" company="Okta, Inc">
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
    public sealed partial class UserCredentials : Resource, IUserCredentials
    {
        /// <inheritdoc/>
        public IList<IEmailAddress> Emails 
        {
            get => GetArrayProperty<IEmailAddress>("emails");
            set => this["emails"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordCredential Password 
        {
            get => GetResourceProperty<PasswordCredential>("password");
            set => this["password"] = value;
        }
        
        /// <inheritdoc/>
        public IAuthenticationProvider Provider 
        {
            get => GetResourceProperty<AuthenticationProvider>("provider");
            set => this["provider"] = value;
        }
        
        /// <inheritdoc/>
        public IRecoveryQuestionCredential RecoveryQuestion 
        {
            get => GetResourceProperty<RecoveryQuestionCredential>("recovery_question");
            set => this["recovery_question"] = value;
        }
        
    }
}
