// <copyright file="IJwtGenerator.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Client
{
    /// <summary>
    /// Interface for JWT generators.
    /// </summary>
    public interface IJwtGenerator
    {
        /// <summary>
        /// Generates a signed JWT.
        /// </summary>
        /// <returns>The generated signed JWT.</returns>
        string GenerateSignedJWT();
    }
}
