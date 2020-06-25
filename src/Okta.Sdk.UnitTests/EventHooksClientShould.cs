// <copyright file="EventHooksClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class EventHooksClientShould
    {
        [Fact]
        public async Task CallVerifyEndpoint()
        {
            var testEventHookId = "TestEventHookId";
            var verifyEndpoint = $"/api/v1/eventHooks/{testEventHookId}/lifecycle/verify";
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            var mockResponse = Substitute.For<HttpResponse<string>>();
            mockResponse.StatusCode = 200;
            mockRequestExecutor.PostAsync(Arg.Any<HttpRequest>(), Arg.Any<CancellationToken>()).Returns(Task.FromResult(mockResponse));

            var testClient = new TestableOktaClient(mockRequestExecutor);

            await testClient.EventHooks.VerifyEventHookAsync(testEventHookId);
            await mockRequestExecutor
                .Received(1)
                .PostAsync(Arg.Is<HttpRequest>(request => request.Uri.Equals(verifyEndpoint)), Arg.Any<CancellationToken>());
        }
    }
}
