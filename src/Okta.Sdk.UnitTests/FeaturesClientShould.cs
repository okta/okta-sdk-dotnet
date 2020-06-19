// <copyright file="FeaturesClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
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
                .PostAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            var testClient = new TestableOktaClient(mockRequestExecutor);

            await testClient.Features.UpdateFeatureLifecycleAsync(featureId, lifecycle);
            _ = await mockRequestExecutor.Received(1).PostAsync(Arg.Is<HttpRequest>(httpRequest => httpRequest.Uri.Equals(featureLifeCycleEndpoint)), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task CallDependenciesEndpoint()
        {
            var featureId = "testFeatureId";
            var dependenciesEndpoint = $"/api/v1/features/{featureId}/dependencies";
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            var mockResponse = Substitute.For<HttpResponse<string>>();
            mockResponse.Payload =
                "[{\"Description\":null,\"Id\":null,\"name\":\"TestFeature\",\"Stage\":{\"State\":null,\"Value\":null},\"Status\":null,\"Type\":null}]";
            mockResponse.StatusCode = 200;
            _ = mockRequestExecutor
                .ExecuteRequestAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            var testClient = new TestableOktaClient(mockRequestExecutor);

            var retrievedDependencies = await testClient.Features.ListFeatureDependencies(featureId).ToListAsync();
            retrievedDependencies.FirstOrDefault().Name.Should().Be("TestFeature");
            _ = await mockRequestExecutor
                .Received(1)
                .ExecuteRequestAsync(Arg.Is<HttpRequest>(httpRequest => httpRequest.Uri.Equals(dependenciesEndpoint)), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task GetDependents()
        {
            var featureId = "testFeatureId";
            var dependentsEndpoint = $"/api/v1/features/{featureId}/dependents";
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            var mockResponse = Substitute.For<HttpResponse<string>>();
            mockResponse.Payload =
                "[{\"Description\":null,\"Id\":null,\"name\":\"TestFeature\",\"Stage\":{\"State\":null,\"Value\":null},\"Status\":null,\"Type\":null}]";
            mockResponse.StatusCode = 200;
            _ = mockRequestExecutor
                .ExecuteRequestAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            var testClient = new TestableOktaClient(mockRequestExecutor);

            var retrievedDependents = await testClient.Features.ListFeatureDependents(featureId).ToListAsync();
            retrievedDependents.FirstOrDefault().Name.Should().Be("TestFeature");
            _ = await mockRequestExecutor.Received(1)
                .Received(1)
                .ExecuteRequestAsync(Arg.Is<HttpRequest>(httpRequest => httpRequest.Uri.Equals(dependentsEndpoint)), Arg.Any<CancellationToken>());
        }
    }
}
