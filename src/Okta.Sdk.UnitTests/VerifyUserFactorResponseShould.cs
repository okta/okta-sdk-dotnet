// <copyright file="VerifyUserFactorResponseShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class VerifyUserFactorResponseShould
    {
        [Fact]
        public async Task ExtractTransationIdCorrectly()
        {
            var rawResponse = @"{
                  ""expiresAt"": ""2015-04-01T15:57:32.000Z"",
                  ""factorResult"": ""WAITING"",
                  ""profile"":{
                     ""credentialId"":""jane.doe@example.com""
                  },
                  ""_links"": {
                    ""poll"": {
                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/opfh52xcuft3J4uZc0g3/transactions/verificationTransactionId"",
                      ""hints"": {
                        ""allow"": [
                          ""GET""
                        ]
                      }
                    },
                    ""cancel"": {
                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/opfh52xcuft3J4uZc0g3/transactions/v2mst.GldKV5VxTrifyeZmWSQguA"",
                      ""hints"": {
                        ""allow"": [
                          ""DELETE""
                        ]
                      }
                    }
                  }
                }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var factorVerifyResponse = await client.UserFactors.VerifyFactorAsync("userId", "pushFactorId");
            factorVerifyResponse.GetTransactionId().Should().Be("verificationTransactionId");
        }
    }
}
