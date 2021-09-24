// <copyright file="ThreatInsightClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ThreatInsightClientShould
    {
        [Fact]
        public async Task GetCurrentConfiguration()
        {
            var rawResponse = @"{
    ""action"": ""audit"",
    ""excludeZones"": [""nzo1q7jEOsoCnoKcj0g4""],
    ""created"": ""2020-08-05 22:18:30"",
    ""lastUpdated"": ""2020-09-08 20:53:20"",
    ""_links"": {
        ""self"": {
            ""href"": ""https://${yourOktaDomain}/api/v1/threats/configuration"",
            ""hints"": {
                ""allow"": [
                    ""GET"",
                    ""POST""
                ]
            }
        }
    }
}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var threatInsightClient = client.ThreatInsights;

            var response = await threatInsightClient.GetCurrentConfigurationAsync();
            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/threats/configuration");
            response.Action.Should().Be("audit");
            response.ExcludeZones.Should().OnlyContain(z => z.Equals("nzo1q7jEOsoCnoKcj0g4"));
        }

        [Fact]
        public async Task UpdateConfiguration()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            var threatInsightClient = client.ThreatInsights;

            var data = new Dictionary<string, object>
            {
                ["action"] = "audit",
                ["excludeZones"] = new string[] { "nzo1q7jEOsoCnoKcj0g4" },
            };

            var factory = new ResourceFactory(null, null);
            var configuration = factory.CreateNew<ThreatInsightConfiguration>(data);

            await threatInsightClient.UpdateConfigurationAsync(configuration);

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/threats/configuration");
            mockRequestExecutor.ReceivedBody.Should().Be(@"{""action"":""audit"",""excludeZones"":[""nzo1q7jEOsoCnoKcj0g4""]}");
        }
    }
}
