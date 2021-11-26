// <copyright file="IVerifyUserFactorResponse.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>Represents a VerifyUserFactorResponse resource in the Okta API.</summary>
    public partial interface IVerifyUserFactorResponse : IResource
    {
        /// <summary>
        /// Gets the Transaction Id for Push Factor Verify response.
        /// </summary>
        string TransactionId { get; }
    }
}
