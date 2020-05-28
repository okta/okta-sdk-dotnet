using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class LinkedObjectClientShould
    {
        private const string SdkPrefix = "dotnet_sdk";
        
        [Fact]
        public async Task CallDeleteEndpoint()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            var testClient = new TestableOktaClient(mockRequestExecutor);
            var guid = Guid.NewGuid();
            var testPrimaryName = $"{SdkPrefix}_{nameof(CallDeleteEndpoint)}_primary_{guid}";
            var endPoint = $"/api/v1/meta/schemas/user/linkedObjects/{testPrimaryName}";
            var mockResponse = Substitute.For<HttpResponse<string>>();
            mockResponse.StatusCode = 200;
            mockRequestExecutor
                .DeleteAsync(endPoint, Arg.Any<Dictionary<string, string>>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(testPrimaryName);
            mockRequestExecutor.Received(1).DeleteAsync(endPoint, Arg.Any<Dictionary<string, string>>(), Arg.Any<CancellationToken>());
        }
    }
}