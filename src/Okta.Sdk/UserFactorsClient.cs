// <copyright file="UserFactorsClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta UserFactor resources.</summary>
    public sealed partial class UserFactorsClient : OktaClient, IUserFactorsClient //, IAsyncEnumerable<IFactor> todo
    {
        /// <inheritdoc/>
        public Task<IFactor> AddFactorAsync(string userId, AddSecurityQuestionFactorOptions securityQuestionFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (securityQuestionFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(securityQuestionFactorOptions));
            }

            var profile = new SecurityQuestionFactorProfile
            {
                Question = securityQuestionFactorOptions.Question,
                Answer = securityQuestionFactorOptions.Answer,
            };

            var factor = new SecurityQuestionFactor
            {
                FactorType = FactorType.Question,
                Provider = "OKTA",
                Profile = profile,
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        Task<IFactor> AddFactorAsync(string userId, AddCallFactorOptions callFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (callFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(callFactorOptions));
            }

            var profile = new CallFactorProfile
            {
                PhoneExtension = callFactorOptions.PhoneExtension,
                PhoneNumber = callFactorOptions.PhoneNumber
            };

            var factor = new CallFactor
            {
                FactorType = FactorType.Call,
                Provider = "OKTA",
                Profile = profile,
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        // /// <inheritdoc/>
        // Task<IFactor> AddFactorAsync(string userId, AddEmailFactorOptions emailFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        // {
        //     if (emailFactorOptions == null)
        //     {
        //         throw new ArgumentNullException(nameof(emailFactorOptions));
        //     }

        //     var profile = new EmailFactorProfile
        //     {
        //         Email = emailFactorOptions.Email
        //     };

        //     var factor = new EmailFactor
        //     {
        //         FactorType = "email", // TODO: add this to the FactorType enum
        //         Provider = "OKTA",
        //         Profile = profile,
        //     };

        //     return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        // }

        /// <inheritdoc/>
        Task<IFactor> AddFactorAsync(string userId, AddHardwareFactorOptions hardwareFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hardwareFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(hardwareFactorOptions));
            }

            var profile = new HardwareFactorProfile
            {
                CredentialId = hardwareFactorOptions.CredentialId
            };

            var verify = new VerifyFactorRequest
            {
                PassCode = hardwareFactorOptions.PassCode
            };

            var factor = new HardwareFactor
            {
                FactorType = FactorType.TokenHardware,
                Provider = "YUBICO",
                Profile = profile,
                Verify = verify
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        Task<IFactor> AddFactorAsync(string userId, AddPushFactorOptions pushFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (pushFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(pushFactorOptions));
            }

            var factor = new PushFactor
            {
                FactorType = FactorType.Push,
                Provider = "OKTA"
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        Task<IFactor> AddFactorAsync(string userId, AddSmsFactorOptions smsFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (smsFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(smsFactorOptions));
            }

            var profile = new SmsFactorProfile
            {
                PhoneNumber = smsFactorOptions.PhoneNumber
            };

            var factor = new SmsFactor
            {
                FactorType = FactorType.Sms,
                Provider = "OKTA",
                Profile = profile,
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        Task<IFactor> AddFactorAsync(string userId, AddTokenFactorOptions tokenFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (tokenFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(tokenFactorOptions));
            }

            var profile = new TokenFactorProfile
            {
                CredentialId = tokenFactorOptions.CredentialId
            };

            var verify = new VerifyFactorRequest
            {
                PassCode = tokenFactorOptions.PassCode,
                NextPassCode = tokenFactorOptions.NextPassCode
            };

            var factor = new TokenFactor
            {
                FactorType = FactorType.Token,
                Provider = tokenFactorOptions.Provider,
                Profile = profile,
                Verify = verify
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        Task<IFactor> AddFactorAsync(string userId, AddTotpFactorOptions totpFactorOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (totpFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(totpFactorOptions));
            }

            var profile = new TotpFactorProfile
            {
                CredentialId = totpFactorOptions.CredentialId
            };

            var factor = new TotpFactor
            {
                FactorType = FactorType.TokenSoftwareTotp,
                Provider = "OKTA",
                Profile = profile,
            };

            return AddFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }
    }
}
