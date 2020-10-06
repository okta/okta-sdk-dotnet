// <copyright file="UserFactorsClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
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
    public sealed partial class UserFactorsClient : OktaClient, IUserFactorsClient
    {
        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddSecurityQuestionFactorOptions securityQuestionFactorOptions, CancellationToken cancellationToken = default)
        {
            if (securityQuestionFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(securityQuestionFactorOptions));
            }

            var profile = new SecurityQuestionUserFactorProfile
            {
                Question = securityQuestionFactorOptions.Question,
                Answer = securityQuestionFactorOptions.Answer,
            };

            var factor = new SecurityQuestionUserFactor
            {
                FactorType = FactorType.Question,
                Provider = FactorProvider.Okta,
                Profile = profile,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddCallFactorOptions callFactorOptions, CancellationToken cancellationToken = default)
        {
            if (callFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(callFactorOptions));
            }

            var profile = new CallUserFactorProfile
            {
                PhoneExtension = callFactorOptions.PhoneExtension,
                PhoneNumber = callFactorOptions.PhoneNumber,
            };

            var factor = new CallUserFactor
            {
                FactorType = FactorType.Call,
                Provider = FactorProvider.Okta,
                Profile = profile,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddEmailFactorOptions emailFactorOptions, CancellationToken cancellationToken = default)
        {
            if (emailFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(emailFactorOptions));
            }

            var profile = new EmailUserFactorProfile
            {
                Email = emailFactorOptions.Email,
            };

            var factor = new EmailUserFactor
            {
                FactorType = FactorType.Email,
                Provider = FactorProvider.Okta,
                Profile = profile,
            };

            return EnrollFactorAsync(factor, userId, tokenLifetimeSeconds: emailFactorOptions.TokenLifetimeSeconds, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddHardwareFactorOptions hardwareFactorOptions, CancellationToken cancellationToken = default)
        {
            if (hardwareFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(hardwareFactorOptions));
            }

            if (hardwareFactorOptions.Provider == null)
            {
                throw new ArgumentNullException(nameof(hardwareFactorOptions.Provider));
            }

            var verify = new VerifyFactorRequest
            {
                PassCode = hardwareFactorOptions.PassCode,
            };

            var factor = new HardwareUserFactor
            {
                FactorType = FactorType.TokenHardware,
                Provider = hardwareFactorOptions.Provider,
                Verify = verify,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddPushFactorOptions pushFactorOptions, CancellationToken cancellationToken = default)
        {
            if (pushFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(pushFactorOptions));
            }

            var factor = new PushUserFactor
            {
                FactorType = FactorType.Push,
                Provider = FactorProvider.Okta,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddSmsFactorOptions smsFactorOptions, CancellationToken cancellationToken = default)
        {
            if (smsFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(smsFactorOptions));
            }

            var profile = new SmsUserFactorProfile
            {
                PhoneNumber = smsFactorOptions.PhoneNumber,
            };

            var factor = new SmsUserFactor
            {
                FactorType = FactorType.Sms,
                Provider = FactorProvider.Okta,
                Profile = profile,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddTokenFactorOptions tokenFactorOptions, CancellationToken cancellationToken = default)
        {
            if (tokenFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(tokenFactorOptions));
            }

            if (tokenFactorOptions.Provider == null)
            {
                throw new ArgumentNullException(nameof(tokenFactorOptions.Provider));
            }

            var profile = new TokenUserFactorProfile
            {
                CredentialId = tokenFactorOptions.CredentialId,
            };

            var verify = new VerifyFactorRequest
            {
                PassCode = tokenFactorOptions.PassCode,
                NextPassCode = tokenFactorOptions.NextPassCode,
            };

            var factor = new TokenUserFactor
            {
                FactorType = FactorType.Token,
                Provider = tokenFactorOptions.Provider,
                Profile = profile,
                Verify = verify,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddTotpFactorOptions totpFactorOptions, CancellationToken cancellationToken = default)
        {
            if (totpFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(totpFactorOptions));
            }

            if (totpFactorOptions.Provider == null)
            {
                throw new ArgumentNullException(nameof(totpFactorOptions.Provider));
            }

            var factor = new TotpUserFactor
            {
                FactorType = FactorType.TokenSoftwareTotp,
                Provider = totpFactorOptions.Provider,
            };

            return EnrollFactorAsync(factor, userId, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserFactor> AddFactorAsync(string userId, AddCustomHotpFactorOptions hotpFactorOptions, CancellationToken cancellationToken = default)
        {
            if (hotpFactorOptions == null)
            {
                throw new ArgumentNullException(nameof(hotpFactorOptions));
            }

            var factorProfile = new CustomHotpUserFactorProfile
            {
                SharedSecret = hotpFactorOptions.ProfileSharedSecret,
            };

            var factor = new CustomHotpUserFactor
            {
                FactorType = FactorType.TokenHotp,
                Provider = FactorProvider.Custom,
                FactorProfileId = hotpFactorOptions.FactorProfileId,
                Profile = factorProfile,
            };

            return EnrollFactorAsync(body: factor, userId: userId, activate: true, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IVerifyUserFactorResponse> VerifyFactorAsync(string userId, string factorId, string templateId = null, CancellationToken cancellationToken = default)
            => VerifyFactorAsync(null, userId, factorId, templateId, null, cancellationToken);

        /// <inheritdoc/>
        public Task<IUserFactor> ActivateFactorAsync(string userId, string factorId, CancellationToken cancellationToken = default(CancellationToken))
            => ActivateFactorAsync(null, userId, factorId, cancellationToken);
    }
}
