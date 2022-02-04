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
    /// <summary>A client that works with Okta resources.</summary>
    public partial interface IUserFactorsClient
    {
        /// <summary>
        /// Activate Factor The &#x60;sms&#x60; and &#x60;token:software:totp&#x60; factor types require activation to complete the enrollment process.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="body"> (optional)</param>
        ///  <returns>Task of IUserFactor</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserFactor> ActivateFactorAsync(string userId, string factorId, IActivateFactorRequest body = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Unenrolls an existing factor for the specified user, allowing the user to enroll a new factor.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        ///  <returns>Task of void</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Enroll Factor Enrolls a user with a supported factor.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="body">Factor</param>
        /// <param name="userId"></param>
        /// <param name="updatePhone"> (optional, default to false)</param>
        /// <param name="templateId">id of SMS template (only for SMS factor) (optional)</param>
        /// <param name="tokenLifetimeSeconds"> (optional, default to 300)</param>
        /// <param name="activate"> (optional, default to false)</param>
        ///  <returns>Task of IUserFactor</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserFactor> EnrollFactorAsync(IUserFactor body, string userId, bool? updatePhone = null, string templateId = null, int? tokenLifetimeSeconds = null, bool? activate = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Fetches a factor for the specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        ///  <returns>Task of IUserFactor</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IUserFactor> GetFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Polls factors verification transaction for status.
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="transactionId"></param>
        ///  <returns>Task of IVerifyUserFactorResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IVerifyUserFactorResponse> GetFactorTransactionStatusAsync(string userId, string factorId, string transactionId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        ///  Enumerates all the enrolled factors for the specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUserFactorsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IUserFactor> ListFactors(string userId);
        /// <summary>
        ///  Enumerates all the supported factors that can be enrolled for the specified user
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUserFactorsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<IUserFactor> ListSupportedFactors(string userId);
        /// <summary>
        ///  Enumerates all available security questions for a user&#x27;s &#x60;question&#x60; factor
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// A collection of <see cref="IUserFactorsClient"/> that can be enumerated asynchronously.
        
        ICollectionClient<ISecurityQuestion> ListSupportedSecurityQuestions(string userId);
        /// <summary>
        /// Verify MFA Factor Verifies an OTP for a &#x60;token&#x60; or &#x60;token:hardware&#x60; factor
        /// </summary>
        /// <exception cref="OktaException">Thrown when fails to make API call</exception>
        /// <param name="userId"></param>
        /// <param name="factorId"></param>
        /// <param name="body"> (optional)</param>
        /// <param name="xForwardedFor"> (optional)</param>
        /// <param name="userAgent"> (optional)</param>
        /// <param name="acceptLanguage"> (optional)</param>
        /// <param name="templateId"> (optional)</param>
        /// <param name="tokenLifetimeSeconds"> (optional, default to 300)</param>
        ///  <returns>Task of IVerifyUserFactorResponse</returns>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<IVerifyUserFactorResponse> VerifyFactorAsync(string userId, string factorId, IVerifyFactorRequest body = null, string xForwardedFor = null, string userAgent = null, string acceptLanguage = null, string templateId = null, int? tokenLifetimeSeconds = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

