// <copyright file="IInlineHooksClient.Generated.cs" company="Okta, Inc">
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
    public partial interface IInlineHooksClient
    {
        /// <summary>
        ///  Activates the Inline Hook matching the provided id
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="inlineHookId"></param>
        ///  <returns>Task of IInlineHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IInlineHook> ActivateInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        ///  <returns>Task of IInlineHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IInlineHook> CreateInlineHookAsync(IInlineHook body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deactivates the Inline Hook matching the provided id
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="inlineHookId"></param>
        ///  <returns>Task of IInlineHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IInlineHook> DeactivateInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Deletes the Inline Hook matching the provided id. Once deleted, the Inline Hook is unrecoverable. As a safety precaution, only Inline Hooks with a status of INACTIVE are eligible for deletion.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="inlineHookId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Executes the Inline Hook matching the provided inlineHookId using the request body as the input. This will send the provided data through the Channel and return a response if it matches the correct data contract. This execution endpoint should only be used for testing purposes.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="inlineHookId"></param>
        ///  <returns>Task of IInlineHookResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IInlineHookResponse> ExecuteInlineHookAsync(IInlineHookPayload body, string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Gets an inline hook by ID
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="inlineHookId"></param>
        ///  <returns>Task of IInlineHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IInlineHook> GetInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Success
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// A collection of <see cref="IInlineHooksClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IInlineHook> ListInlineHooks(string type = null);
        /// <summary>
        ///  Updates an inline hook by ID
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="inlineHookId"></param>
        ///  <returns>Task of IInlineHook</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IInlineHook> UpdateInlineHookAsync(IInlineHook body, string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));
    }
}

