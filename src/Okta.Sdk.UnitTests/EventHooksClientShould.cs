using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core.Arguments;
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
            mockRequestExecutor.PostAsync(verifyEndpoint,
                Arg.Any<Dictionary<string, string>>(), null, Arg.Any<CancellationToken>()).Returns(Task.FromResult(mockResponse));
            
            var testClient = new TestableOktaClient(mockRequestExecutor);

            await testClient.EventHooks.VerifyEventHookAsync(testEventHookId);
            mockRequestExecutor.Received(1).PostAsync(verifyEndpoint, Arg.Any<Dictionary<string, string>>(), null,
                Arg.Any<CancellationToken>());
        }
    }
}