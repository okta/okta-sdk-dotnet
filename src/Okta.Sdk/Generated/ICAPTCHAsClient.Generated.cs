// <copyright file="ICAPTCHAsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta CAPTCHA resources.</summary>
    public partial interface ICAPTCHAsClient
    {
        /// <summary>
        /// Enumerates CAPTCHA instances in your organization with pagination. A subset of CAPTCHA instances can be returned that match a supported filter expression or query.
        /// </summary>
        /// <returns>A collection of <see cref="ICAPTCHAInstance"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ICAPTCHAInstance> ListCaptchaInstances();

        /// <summary>
        /// Adds a new CAPTCHA instance to your organization.
In current release, we only allow one CAPTCHA instance per org
        /// </summary>
        /// <param name="captchaInstance">The <see cref="ICAPTCHAInstance"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICAPTCHAInstance"/> response.</returns>
        Task<ICAPTCHAInstance> CreateCaptchaInstanceAsync(ICAPTCHAInstance captchaInstance, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete a CAPTCHA instance by `id`.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteCaptchaInstanceAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a CAPTCHA instance by `id`.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICAPTCHAInstance"/> response.</returns>
        Task<ICAPTCHAInstance> GetCaptchaInstanceAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Partially update a CAPTCHA instance by `id`.
        /// </summary>
        /// <param name="captchaInstance">The <see cref="ICAPTCHAInstance"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICAPTCHAInstance"/> response.</returns>
        Task<ICAPTCHAInstance> PartialUpdateCaptchaInstanceAsync(ICAPTCHAInstance captchaInstance, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update a CAPTCHA instance by `id`.
        /// </summary>
        /// <param name="captchaInstance">The <see cref="ICAPTCHAInstance"/> resource.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ICAPTCHAInstance"/> response.</returns>
        Task<ICAPTCHAInstance> UpdateCaptchaInstanceAsync(ICAPTCHAInstance captchaInstance, CancellationToken cancellationToken = default(CancellationToken));

    }
}
