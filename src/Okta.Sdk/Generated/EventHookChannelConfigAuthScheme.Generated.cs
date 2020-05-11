// <copyright file="EventHookChannelConfigAuthScheme.Generated.cs" company="Okta, Inc">
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
    public sealed partial class EventHookChannelConfigAuthScheme : Resource, IEventHookChannelConfigAuthScheme
    {
        /// <inheritdoc/>
        public string Key 
        {
            get => GetStringProperty("key");
            set => this["key"] = value;
        }
        
        /// <inheritdoc/>
        public EventHookChannelConfigAuthSchemeType Type 
        {
            get => GetEnumProperty<EventHookChannelConfigAuthSchemeType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc/>
        public string Value 
        {
            get => GetStringProperty("value");
            set => this["value"] = value;
        }
        
    }
}
