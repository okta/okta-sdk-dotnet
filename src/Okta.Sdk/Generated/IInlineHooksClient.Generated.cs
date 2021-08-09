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
    /// <summary>A client that works with Okta InlineHook resources.</summary>
    public partial interface IInlineHooksClient
    {
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="type"></param>
        /// <returns>A collection of <see cref="IInlineHook"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IInlineHook> ListInlineHooks(string type = null);

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="inlineHook">The <see cref="IInlineHook"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IInlineHook"/> response.</returns>
        Task<IInlineHook> CreateInlineHookAsync(IInlineHook inlineHook, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an inline hook by ID
        /// </summary>
        /// <param name="inlineHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IInlineHook"/> response.</returns>
        Task<IInlineHook> GetInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an inline hook by ID
        /// </summary>
        /// <param name="inlineHook">The <see cref="IInlineHook"/> resource.</param>
        /// <param name="inlineHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IInlineHook"/> response.</returns>
        Task<IInlineHook> UpdateInlineHookAsync(IInlineHook inlineHook, string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the Inline Hook matching the provided id. Once deleted, the Inline Hook is unrecoverable. As a safety precaution, only Inline Hooks with a status of INACTIVE are eligible for deletion.
        /// </summary>
        /// <param name="inlineHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes the Inline Hook matching the provided inlineHookId using the request body as the input. This will send the provided data through the Channel and return a response if it matches the correct data contract. This execution endpoint should only be used for testing purposes.
        /// </summary>
        /// <param name="inlineHookPayload">The <see cref="IInlineHookPayload"/> resource.</param>
        /// <param name="inlineHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IInlineHookResponse"/> response.</returns>
        Task<IInlineHookResponse> ExecuteInlineHookAsync(IInlineHookPayload inlineHookPayload, string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Activates the Inline Hook matching the provided id
        /// </summary>
        /// <param name="inlineHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IInlineHook"/> response.</returns>
        Task<IInlineHook> ActivateInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivates the Inline Hook matching the provided id
        /// </summary>
        /// <param name="inlineHookId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IInlineHook"/> response.</returns>
        Task<IInlineHook> DeactivateInlineHookAsync(string inlineHookId, CancellationToken cancellationToken = default(CancellationToken));

    }
}
