// <copyright file="RecordedScenarioCollection.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [CollectionDefinition(nameof(RecordedScenarioCollection))]
    public sealed class RecordedScenarioCollection : ICollectionFixture<RecordedScenarioFixture>
    {
        // Intentionally left blank. This class only serves as an anchor for CollectionDefinition.
    }
}
