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
    }
}
