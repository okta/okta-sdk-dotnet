// <copyright file="EventHook.Generated.cs" company="Okta, Inc">
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
    public sealed partial class EventHook : Resource, IEventHook
    {
        /// <inheritdoc/>
        public IEventHookChannel Channel 
        {
            get => GetResourceProperty<EventHookChannel>("channel");
            set => this["channel"] = value;
        }
        
        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");
        
        /// <inheritdoc/>
        public string CreatedBy 
        {
            get => GetStringProperty("createdBy");
            set => this["createdBy"] = value;
        }
        
        /// <inheritdoc/>
        public IEventSubscriptions Events 
        {
            get => GetResourceProperty<EventSubscriptions>("events");
            set => this["events"] = value;
        }
        
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
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc/>
        public string VerificationStatus 
        {
            get => GetStringProperty("verificationStatus");
            set => this["verificationStatus"] = value;
        }
        
        /// <inheritdoc />
        public Task<IEventHook> ActivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().EventHooks.ActivateEventHookAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEventHook> DeactivateAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().EventHooks.DeactivateEventHookAsync(Id, cancellationToken);
        
        /// <inheritdoc />
        public Task<IEventHook> VerifyAsync(
            CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().EventHooks.VerifyEventHookAsync(Id, cancellationToken);
        
    }
}
