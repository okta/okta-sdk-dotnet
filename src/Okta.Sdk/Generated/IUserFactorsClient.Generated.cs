// <copyright file="IUserFactorsClient.Generated.cs" company="Okta, Inc">
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
    /// <summary>A client that works with Okta UserFactor resources.</summary>
    public partial interface IUserFactorsClient
    {
        /// <summary>
        /// Enumerates all the enrolled factors for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IUserFactor"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IUserFactor> ListFactors(string userId);

        /// <summary>
        /// Enrolls a user with a supported factor.
        /// </summary>
        /// <param name="userFactor">The <see cref="IUserFactor"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="updatePhone"></param>
        /// <param name="templateId">id of SMS template (only for SMS factor)</param>
        /// <param name="tokenLifetimeSeconds"></param>
        /// <param name="activate"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserFactor"/> response.</returns>
        Task<IUserFactor> EnrollFactorAsync(IUserFactor userFactor, string userId, bool? updatePhone = false, string templateId = null, int? tokenLifetimeSeconds = 300, bool? activate = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enumerates all the supported factors that can be enrolled for the specified user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A collection of <see cref="IUserFactor"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<IUserFactor> ListSupportedFactors(string userId);

        /// <summary>
        /// Enumerates all available security questions for a user's `question` factor
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
        /// <returns>The <see cref="IUserFactor"/> response.</returns>
        Task<IUserFactor> GetFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// The `sms` and `token:software:totp` factor types require activation to complete the enrollment process.
        /// </summary>
        /// <param name="activateFactorRequest">The <see cref="IActivateFactorRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserFactor"/> response.</returns>
        Task<IUserFactor> ActivateFactorAsync(IActivateFactorRequest activateFactorRequest, string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Polls factors verification transaction for status.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="transactionId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IVerifyUserFactorResponse"/> response.</returns>
        Task<IVerifyUserFactorResponse> GetFactorTransactionStatusAsync(string userId, string factorId, string transactionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Verifies an OTP for a `token` or `token:hardware` factor
        /// </summary>
        /// <param name="verifyFactorRequest">The <see cref="IVerifyFactorRequest"/> resource.</param>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="templateId"></param>
        /// <param name="tokenLifetimeSeconds"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IVerifyUserFactorResponse"/> response.</returns>
        Task<IVerifyUserFactorResponse> VerifyFactorAsync(IVerifyFactorRequest verifyFactorRequest, string userId, string factorId, string templateId = null, int? tokenLifetimeSeconds = 300, CancellationToken cancellationToken = default(CancellationToken));

    }
}
