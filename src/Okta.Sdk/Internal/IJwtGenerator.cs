// <copyright file="JWTGenerator.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Configuration;

namespace Okta.Sdk.Internal
{
    public interface IJwtGenerator
    {
        string GenerateSignedJWT(OktaClientConfiguration configuration);
    }
}