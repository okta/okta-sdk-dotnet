// <copyright file="TestableCustomTokenProvider.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests
{
    internal class TestableCustomTokenProvider : IOAuthTokenProvider
    {
        public bool TokenRefreshed { get; set; }

        public Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            TokenRefreshed = true;
            return Task.FromResult("NewAccessToken");
        }
    }
}
