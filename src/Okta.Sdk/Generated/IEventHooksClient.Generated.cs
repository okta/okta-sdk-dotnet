// <copyright file="IEventHooksClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IEventHooksClient
    {
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="eventHookId"></param>
        ///  <returns>Task of IEventHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEventHook> ActivateEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IEventHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEventHook> CreateEventHookAsync(IEventHook body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="eventHookId"></param>
        ///  <returns>Task of IEventHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEventHook> DeactivateEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="eventHookId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="eventHookId"></param>
        ///  <returns>Task of IEventHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEventHook> GetEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// A collection of <see cref="IEventHooksClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IEventHook> ListEventHooks();
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="eventHookId"></param>
        ///  <returns>Task of IEventHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEventHook> UpdateEventHookAsync(IEventHook body, string eventHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="eventHookId"></param>
        ///  <returns>Task of IEventHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IEventHook> VerifyEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

