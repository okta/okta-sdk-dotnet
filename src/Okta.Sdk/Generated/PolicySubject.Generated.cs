// <copyright file="PolicySubject.Generated.cs" company="Okta, Inc">
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
    public sealed partial class PolicySubject : Resource, IPolicySubject
    {
        /// <inheritdoc/>
        public string Filter 
        {
            get => GetStringProperty("filter");
            set => this["filter"] = value;
        }
        
        /// <inheritdoc/>
        public IList<string> Format 
        {
            get => GetArrayProperty<string>("format");
            set => this["format"] = value;
        }
        
        /// <inheritdoc/>
        public string MatchAttribute 
        {
            get => GetStringProperty("matchAttribute");
            set => this["matchAttribute"] = value;
        }
        
        /// <inheritdoc/>
        public PolicySubjectMatchType MatchType 
        {
            get => GetEnumProperty<PolicySubjectMatchType>("matchType");
            set => this["matchType"] = value;
        }
        
        /// <inheritdoc/>
        public IPolicyUserNameTemplate UserNameTemplate 
        {
            get => GetResourceProperty<PolicyUserNameTemplate>("userNameTemplate");
            set => this["userNameTemplate"] = value;
        }
        
    }
}
