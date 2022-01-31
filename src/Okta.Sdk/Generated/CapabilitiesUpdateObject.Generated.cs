// <copyright file="CapabilitiesUpdateObject.Generated.cs" company="Okta, Inc">
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
    public sealed partial class CapabilitiesUpdateObject : Resource, ICapabilitiesUpdateObject
    {
        /// <inheritdoc/>
        public ILifecycleDeactivateSettingObject LifecycleDeactivate 
        {
            get => GetResourceProperty<LifecycleDeactivateSettingObject>("lifecycleDeactivate");
            set => this["lifecycleDeactivate"] = value;
        }
        
        /// <inheritdoc/>
        public IPasswordSettingObject Password 
        {
            get => GetResourceProperty<PasswordSettingObject>("password");
            set => this["password"] = value;
        }
        
        /// <inheritdoc/>
        public IProfileSettingObject Profile 
        {
            get => GetResourceProperty<ProfileSettingObject>("profile");
            set => this["profile"] = value;
        }
        
    }
}
