// <copyright file="InlineHookChannelConfig.Generated.cs" company="Okta, Inc">
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
    public sealed partial class InlineHookChannelConfig : Resource, IInlineHookChannelConfig
    {
        /// <inheritdoc/>
        public IInlineHookChannelConfigAuthScheme AuthScheme 
        {
            get => GetResourceProperty<InlineHookChannelConfigAuthScheme>("authScheme");
            set => this["authScheme"] = value;
        }
        
        /// <inheritdoc/>
        public IList<IInlineHookChannelConfigHeaders> Headers 
        {
            get => GetArrayProperty<IInlineHookChannelConfigHeaders>("headers");
            set => this["headers"] = value;
        }
        
        /// <inheritdoc/>
        public string Method 
        {
            get => GetStringProperty("method");
            set => this["method"] = value;
        }
        
        /// <inheritdoc/>
        public string Uri 
        {
            get => GetStringProperty("uri");
            set => this["uri"] = value;
        }
        
    }
}
