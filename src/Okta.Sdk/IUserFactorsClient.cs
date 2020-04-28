﻿// <copyright file="IUserFactorsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta UserFactor resources.</summary>
    public partial interface IUserFactorsClient
    {
        /// <summary>
        /// Enrolls a user with a security question factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="securityQuestionFactorOptions">The security question factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddSecurityQuestionFactorOptions securityQuestionFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with a call factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="callFactorOptions">The call factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddCallFactorOptions callFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with an email factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="emailFactorOptions">The email factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddEmailFactorOptions emailFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with a hardware factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="hardwareFactorOptions">The hardware factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddHardwareFactorOptions hardwareFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with a push factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="pushFactorOptions">The push factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddPushFactorOptions pushFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with a sms factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="smsFactorOptions">The sms factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddSmsFactorOptions smsFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with a token factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="tokenFactorOptions">The token factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddTokenFactorOptions tokenFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Enrolls a user with a token:software:totp factor
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="totpFactorOptions">The token:software:totp factor options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="IUserFactor"/> resource</returns>
        Task<IUserFactor> AddFactorAsync(string userId, AddTotpFactorOptions totpFactorOptions, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Verifies an OTP for a &#x60;token&#x60; or &#x60;token:hardware&#x60; factor
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="factorId">The factor ID.</param>
        /// <param name="templateId">The template ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IVerifyUserFactorResponse"/> response.</returns>
        Task<IVerifyUserFactorResponse> VerifyFactorAsync(string userId, string factorId, string templateId = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// The &#x60;sms&#x60; and &#x60;token:software:totp&#x60; factor types require activation to complete the enrollment process.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="factorId">The factor Id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="IUserFactor"/> response.</returns>
        Task<IUserFactor> ActivateFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
