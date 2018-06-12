// <copyright file="TestClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Configuration;

namespace Okta.Sdk.IntegrationTests
{
    public static class TestClient
    {
        public static IOktaClient Create(OktaClientConfiguration configuration = null)
        {
            // Configuration is expected to be stored in environment variables on the test machine.
            // A few tests pass in a configuration object, but this is just to override and test specific things.
            return new OktaClient(configuration);
        }
    }
}
