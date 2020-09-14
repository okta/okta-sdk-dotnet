using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UserFactorsClientShould
    {
        [Fact]
        public async Task EnrollEmailFactor()
        {
            var mockDataStore = Substitute.For<IDataStore>();
            var client = new TestableOktaClient(mockDataStore);
            var factorsClient = client.UserFactors;
            var emailFactorOptions = new AddEmailFactorOptions
            {
                Email = "johndoe@mail.com",
                TokenLifetimeSeconds = 999,
            };
            await factorsClient.AddFactorAsync("UserId", emailFactorOptions);
            await mockDataStore
                .Received(1)
                .PostAsync<UserFactor>(Arg.Is<HttpRequest>(request => RequestMatchOptions(request, emailFactorOptions)), Arg.Any<RequestContext>(), Arg.Any<CancellationToken>());
        }

        private bool RequestMatchOptions(HttpRequest request, AddEmailFactorOptions emailFactorOptions)
        {
            var queryParamsDict = new Dictionary<string, object>(request.QueryParameters, StringComparer.OrdinalIgnoreCase);
            if ((request.Payload is IEmailUserFactor actualUserFactor) &&
                queryParamsDict.TryGetValue(nameof(emailFactorOptions.TokenLifetimeSeconds), out var tokenLifeTimeSeconds))
            {
                return string.Equals(actualUserFactor.Profile?.Email, emailFactorOptions.Email, StringComparison.OrdinalIgnoreCase) &&
                       (int)tokenLifeTimeSeconds == emailFactorOptions.TokenLifetimeSeconds;
            }

            return false;
        }
    }
}
