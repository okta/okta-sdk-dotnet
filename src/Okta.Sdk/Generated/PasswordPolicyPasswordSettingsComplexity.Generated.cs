// <copyright file="PasswordPolicyPasswordSettingsComplexity.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PasswordPolicyPasswordSettingsComplexity : Resource, IPasswordPolicyPasswordSettingsComplexity
    {
        /// <inheritdoc/>
        public IPasswordDictionary Dictionary 
        {
            get => GetResourceProperty<PasswordDictionary>("dictionary");
            set => this["dictionary"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> ExcludeAttributes 
        {
            get => GetArrayProperty<string>("excludeAttributes");
            set => this["excludeAttributes"] = value;
        }
        
        /// <inheritdoc/>
        public bool? ExcludeUsername 
        {
            get => GetBooleanProperty("excludeUsername");
            set => this["excludeUsername"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinLength 
        {
            get => GetIntegerProperty("minLength");
            set => this["minLength"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinLowerCase 
        {
            get => GetIntegerProperty("minLowerCase");
            set => this["minLowerCase"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinNumber 
        {
            get => GetIntegerProperty("minNumber");
            set => this["minNumber"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinSymbol 
        {
            get => GetIntegerProperty("minSymbol");
            set => this["minSymbol"] = value;
        }
        
        /// <inheritdoc/>
        public int? MinUpperCase 
        {
            get => GetIntegerProperty("minUpperCase");
            set => this["minUpperCase"] = value;
        }
        
    }
}
