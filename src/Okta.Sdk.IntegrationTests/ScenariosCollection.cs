// <copyright file="ScenariosCollection.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    /// <summary>
    /// This collection is used group all integration tests that can run against a single shared instance of a local test server.
    /// </summary>
    [CollectionDefinition(nameof(ScenariosCollection))]
    public sealed class ScenariosCollection
    {
        // Intentionally left blank. This class only serves as an anchor for CollectionDefinition.
    }
}
