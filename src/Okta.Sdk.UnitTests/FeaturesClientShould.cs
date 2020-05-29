// <copyright file="FeaturesClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class FeaturesClientShould
    {
        [Fact]
        public async Task CallUpdateFeatureLifeCycleEndpoint()
        {
            var featureId = "testFeatureId";
            var lifecycle = "testLifeCycle";
            var featureLifeCycleEndpoint = $"/api/v1/features/{featureId}/{lifecycle}?";
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            var mockResponse = Substitute.For<HttpResponse<string>>();
            mockResponse.StatusCode = 200;
            _ = mockRequestExecutor
                .PostAsync(featureLifeCycleEndpoint, Arg.Any<Dictionary<string, string>>(), null, Arg.Any<CancellationToken>()).Returns(Task.FromResult(mockResponse));

            var testClient = new TestableOktaClient(mockRequestExecutor);

            await testClient.Features.UpdateFeatureLifecycleAsync(featureId, lifecycle);
            _ = await mockRequestExecutor.Received(1).PostAsync(featureLifeCycleEndpoint, Arg.Any<Dictionary<string, string>>(), null, Arg.Any<CancellationToken>());
        }
    }
}
