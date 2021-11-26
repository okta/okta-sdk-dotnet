// <copyright file="VerifyUserFactorResponse.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public partial class VerifyUserFactorResponse : Resource, IVerifyUserFactorResponse
    {
        private const string TransactionsSegmentName = "transactions";

        /// <inheritdoc/>
        public string TransactionId
        {
            get
            {
                var pathSegments = GetProperty<Resource>("_links")?
                    .GetProperty<Resource>("poll")?
                    .GetProperty<string>("href")?
                    .Split('/')
                    .SkipWhile(s => !s.Equals(TransactionsSegmentName))
                    .Take(2);

                if (pathSegments?.Count() == 2)
                {
                    return pathSegments.Last();
                }

                return null;
            }
        }
    }
}
