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
    /// <summary>A client that works with Okta EventHook resources.</summary>
    public partial interface IEventHooksClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <returns>A collection of <see cref="IEventHook"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IEventHook> ListEventHooks();

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHook">The <see cref="IEventHook"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEventHook"/> response.</returns>
        Task<IEventHook> CreateEventHookAsync(IEventHook eventHook, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEventHook"/> response.</returns>
        Task<IEventHook> GetEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHook">The <see cref="IEventHook"/> resource.</param>
        /// <param name="eventHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEventHook"/> response.</returns>
        Task<IEventHook> UpdateEventHookAsync(IEventHook eventHook, string eventHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEventHook"/> response.</returns>
        Task<IEventHook> ActivateEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEventHook"/> response.</returns>
        Task<IEventHook> DeactivateEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="eventHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IEventHook"/> response.</returns>
        Task<IEventHook> VerifyEventHookAsync(string eventHookId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
