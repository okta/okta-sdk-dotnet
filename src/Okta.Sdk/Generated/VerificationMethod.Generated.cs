// <copyright file="VerificationMethod.Generated.cs" company="Okta, Inc">
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
    public sealed partial class VerificationMethod : Resource, IVerificationMethod
    {
        /// <inheritdoc/>
        public IList<IAccessPolicyConstraints> Constraints 
        {
            get => GetArrayProperty<IAccessPolicyConstraints>("constraints");
            set => this["constraints"] = value;
        }
        
        /// <inheritdoc/>
        public string FactorMode 
        {
            get => GetStringProperty("factorMode");
            set => this["factorMode"] = value;
        }
        
        /// <inheritdoc/>
        public string ReauthenticateIn 
        {
            get => GetStringProperty("reauthenticateIn");
            set => this["reauthenticateIn"] = value;
        }
        
        /// <inheritdoc/>
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
    }
}
