// <copyright file="TestConfiguration.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Okta.Sdk.IntegrationTests
{
    public static class TestConfiguration
    {
        public static bool UseLocalServer
            => bool.TryParse(Environment.GetEnvironmentVariable("OKTA_USE_MOCK"), out var result) && result;
    }
}
