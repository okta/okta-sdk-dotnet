// <copyright file="InlineHook.Generated.cs" company="Okta, Inc">
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
    public sealed partial class InlineHook : Resource, IInlineHook
    {
        /// <inheritdoc/>
        public IInlineHookChannel Channel 
        {
            get => GetResourceProperty<InlineHookChannel>("channel");
            set => this["channel"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string Id => GetStringProperty("id");
        
        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");
        
        /// <inheritdoc/>
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        /// <inheritdoc/>
        public InlineHookStatus Status 
        {
            get => GetEnumProperty<InlineHookStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public InlineHookType Type 
        {
            get => GetEnumProperty<InlineHookType>("type");
            set => this["type"] = value;
        }
        
        /// <inheritdoc/>
        public string Version 
        {
            get => GetStringProperty("version");
            set => this["version"] = value;
        }
        
        /// <inheritdoc />
        public Task<IInlineHook> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().InlineHooks.ActivateInlineHookAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IInlineHook> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().InlineHooks.DeactivateInlineHookAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IInlineHookResponse> ExecuteAsync(IInlineHookPayload payloadData, 
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().InlineHooks.ExecuteInlineHookAsync(payloadData, Id, cancellationToken);
        
    }
}
