using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class OrgsClientShould
    {
        [Fact]
        public async Task UpdateOrgLogo()
        {
            var rawResponse = "{}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var filePath = @".\Assets\org_logo.png";
            var file = File.OpenRead(filePath);
            await client.Orgs.UpdateOrgLogoAsync(file);

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/org/logo");
        }
    }
}
