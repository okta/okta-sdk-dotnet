// <copyright file="IUserFactorsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta UserFactor resources.</summary>
    public partial interface IUserFactorsClient
    {
        /// <summary>
        /// Enumerates all the enrolled factors for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IFactor"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IFactor> ListFactors(string userId);

        /// <summary>
        /// Enrolls a user with a supported [factor](#list-factors-to-enroll)
        /// </summary>
        /// <param name="factor">The <see cref="IFactor"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="updatePhone"></param>
        /// <param name="templateId">id of SMS template (only for SMS factor)</param>
        /// <param name="tokenLifetimeSeconds"></param>
        /// <param name="activate"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IFactor"/> response.</returns>
        Task<IFactor> AddFactorAsync(IFactor factor, string userId, bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all the [supported factors](#supported-factors-for-providers) that can be enrolled for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IFactor"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IFactor> ListSupportedFactors(string userId);

        /// <summary>
        /// Enumerates all available security questions for a user&#x27;s &#x60;question&#x60; factor
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="ISecurityQuestion"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions(string userId);

        /// <summary>
        /// Unenrolls an existing factor for the specified user, allowing the user to enroll a new factor.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task DeleteFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetches a factor for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IFactor"/> response.</returns>
        Task<IFactor> GetFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// The &#x60;sms&#x60; and &#x60;token:software:totp&#x60; [factor types](#factor-type) require activation to complete the enrollment process.
        /// </summary>
        /// <param name="verifyFactorRequest">The <see cref="IVerifyFactorRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IFactor"/> response.</returns>
        Task<IFactor> ActivateFactorAsync(IVerifyFactorRequest verifyFactorRequest, string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Verifies an OTP for a &#x60;token&#x60; or &#x60;token:hardware&#x60; factor
        /// </summary>
        /// <param name="verifyFactorRequest">The <see cref="IVerifyFactorRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="templateId"></param>
        /// <param name="tokenLifetimeSeconds"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IVerifyFactorResponse"/> response.</returns>
        Task<IVerifyFactorResponse> VerifyFactorAsync(IVerifyFactorRequest verifyFactorRequest, string userId, string factorId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken));

    }
}
