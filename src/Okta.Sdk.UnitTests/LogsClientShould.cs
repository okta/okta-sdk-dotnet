// <copyright file="LogsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class LogsClientShould
    {
        [Fact]
        public async Task DeserializeGetLogsJsonResponse()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetLogsStubResponse());
            var client = new TestableOktaClient(mockRequestExecutor);
            var logs = await client.Logs.GetLogs().ToList();
            logs.Should().HaveCount(1);

            var log = logs.First();
            log.Should().BeOfType<LogEvent>();

            // Actor
            log.Actor.Should().BeOfType<LogActor>();
            log.Actor.Id.Should().Be("0000222244448888000");
            log.Actor.Type.Should().Be("User");
            log.Actor.DisplayName.Should().Be("Jon Okta");
            log.Actor.Detail.GetData().Should().BeEmpty();

            // Client
            log.ClientInfo.Should().BeOfType<LogClientInfo>();
            log.ClientInfo.UserAgent.Should().BeOfType<LogUserAgent>();
            log.ClientInfo.UserAgent.RawUserAgent.Should().Be("okta-sdk-dotnet / 1.0.0 runtime /.NET Core 4.6.x os / Microsoft Windows 10.x");
            log.ClientInfo.UserAgent.OperatingSystem.Should().Be("Windows");
            log.ClientInfo.UserAgent.Browser.Should().Be("UNKNOWN");

            log.ClientInfo.Zone.Should().BeNullOrEmpty();
            log.ClientInfo.Device.Should().Be("Computer");
            log.ClientInfo.IpAddress.Should().Be("127.0.0.1");

            log.ClientInfo.GeographicalContext.Should().BeOfType<LogGeographicalContext>();
            log.ClientInfo.GeographicalContext.City.Should().Be("Toronto");
            log.ClientInfo.GeographicalContext.State.Should().Be("Ontario");
            log.ClientInfo.GeographicalContext.Country.Should().Be("Canada");
            log.ClientInfo.GeographicalContext.PostalCode.Should().Be("M6G");
            log.ClientInfo.GeographicalContext.Geolocation.Should().BeOfType<LogGeolocation>();
            log.ClientInfo.GeographicalContext.Geolocation.Latitude.Should().Be(43.6655);
            log.ClientInfo.GeographicalContext.Geolocation.Longitude.Should().Be(-79.4204);

            log.AuthenticationContext.Should().BeOfType<LogAuthenticationContext>();
            log.AuthenticationContext.AuthenticationProvider.Should().BeNull();
            log.AuthenticationContext.CredentialProvider.Should().BeEmpty();
            log.AuthenticationContext.CredentialType.Should().BeEmpty();
            // This line should be like this:  log.AuthenticationContext.Issuer.Should().BeNull();
            log.AuthenticationContext.Issuer.GetData().Should().BeEmpty();
            log.AuthenticationContext.Interface.Should().BeNull();
            log.AuthenticationContext.AuthenticationStep.Should().Be(0);
            log.AuthenticationContext.ExternalSessionId.Should().Be("trs-T02AyaeRDKxyrAUXkV-yg");

            log.DisplayMessage.Should().Be("Add user to application membership");
            log.EventType.Should().Be("application.user_membership.add");
            log.Outcome.Should().BeOfType<LogOutcome>();
            log.Outcome.Result.Should().Be("SUCCESS");
            log.Outcome.Reason.Should().BeNull();

            log.SecurityContext.Should().BeOfType<LogSecurityContext>();
            log.SecurityContext.AsNumber.Should().BeNull();
            log.SecurityContext.AsOrg.Should().BeNull();
            log.SecurityContext.Isp.Should().BeNull();
            log.SecurityContext.Domain.Should().BeNull();
            log.SecurityContext.IsProxy.Should().BeNull();

            log.DebugContext.Should().BeOfType<LogDebugContext>();
            log.DebugContext.DebugData["requestUri"].Should().Be("/api/v1/users");

            log.Transaction.Should().BeOfType<LogTransaction>();
            log.Transaction.Type.Should().Be("WEB");
            log.Transaction.Id.Should().Be("WiB04-V4MgacZHWciQq8YwAADpA");
            log.Transaction.Detail.GetData().Should().BeEmpty();

            log.Request.Should().BeOfType<LogRequest>();
            log.Request.IpChain.First().Should().BeOfType<LogIpAddress>();
            log.Request.IpChain.First().Ip.Should().Be("127.0.0.1");
            log.Request.IpChain.First().GeographicalContext.Should().BeOfType<LogGeographicalContext>();
            log.Request.IpChain.First().GeographicalContext.City.Should().Be("Toronto");
            log.Request.IpChain.First().GeographicalContext.State.Should().Be("Ontario");
            log.Request.IpChain.First().GeographicalContext.Country.Should().Be("Canada");
            log.Request.IpChain.First().GeographicalContext.PostalCode.Should().Be("M6G");
            log.Request.IpChain.First().GeographicalContext.Geolocation.Should().BeOfType<LogGeolocation>();
            log.Request.IpChain.First().GeographicalContext.Geolocation.Latitude.Should().Be(43.6655);
            log.Request.IpChain.First().GeographicalContext.Geolocation.Longitude.Should().Be(-79.4204);
            log.Request.IpChain.First().Version.Should().Be("V4");
            log.Request.IpChain.First().Source.Should().BeNull();

            log.Target.Should().HaveCount(1);
            log.Target.First().Should().BeOfType<LogTarget>();
            log.Target.First().AlternateId.Should().Be("john-okta@example.com");
            log.Target.First().DisplayName.Should().Be("John Okta");
            log.Target.First().DetailEntry.GetData().Should().BeEmpty();
        }

        private string GetLogsStubResponse()
        {
#pragma warning disable SA1123 // Do not place regions within elements
            #region GetLogs Stub
            var rawResponse = @"[
            {
                ""actor"": {
                    ""id"": ""0000222244448888000"",
                    ""type"": ""User"",
                    ""alternateId"": ""jon.okta@example.com"",
                    ""displayName"": ""Jon Okta"",
                    ""detailEntry"": null
                        },
                ""client"": {
                    ""userAgent"": {
                        ""rawUserAgent"": ""okta-sdk-dotnet / 1.0.0 runtime /.NET Core 4.6.x os / Microsoft Windows 10.x"",
                        ""os"": ""Windows"",
                        ""browser"": ""UNKNOWN""
                            },
                    ""zone"": null,
                    ""device"": ""Computer"",
                    ""id"": null,
                    ""ipAddress"": ""127.0.0.1"",
                    ""geographicalContext"": {
                        ""city"": ""Toronto"",
                        ""state"": ""Ontario"",
                        ""country"": ""Canada"",
                        ""postalCode"": ""M6G"",
                        ""geolocation"": {
                            ""lat"": 43.6655,
                            ""lon"": -79.4204
                        }
                    }
                },
            ""authenticationContext"": {
                ""authenticationProvider"": null,
                ""credentialProvider"": null,
                ""credentialType"": null,
                ""issuer"": null,
                ""interface"": null,
                ""authenticationStep"": 0,
                ""externalSessionId"": ""trs-T02AyaeRDKxyrAUXkV-yg""
            },
            ""displayMessage"": ""Add user to application membership"",
            ""eventType"": ""application.user_membership.add"",
            ""outcome"": {
                ""result"": ""SUCCESS"",
                ""reason"": null
            },
            ""published"": ""2018-07-06T17:12:43.592Z"",
            ""securityContext"": {
                ""asNumber"": null,
                ""asOrg"": null,
                ""isp"": null,
                ""domain"": null,
                ""isProxy"": null
            },
            ""severity"": ""INFO"",
            ""debugContext"": {
                ""debugData"": {
                    ""requestUri"": ""/api/v1/users""
                }
            },
            ""legacyEventType"": ""app.generic.provision.assign_user_to_app"",
            ""transaction"": {
                ""type"": ""WEB"",
                ""id"": ""WiB04-V4MgacZHWciQq8YwAADpA"",
                ""detail"": {}
            },
            ""uuid"": ""9c3ecf7a-c360-4711-b5f8-9cba5d45f826"",
            ""version"": ""0"",
            ""request"": {
                ""ipChain"": [
                    {
                        ""ip"": ""127.0.0.1"",
                        ""geographicalContext"": {
                            ""city"": ""Toronto"",
                            ""state"": ""Ontario"",
                            ""country"": ""Canada"",
                            ""postalCode"": ""M6G"",
                            ""geolocation"": {
                                ""lat"": 43.6655,
                                ""lon"": -79.4204
                            }
                        },
                        ""version"": ""V4"",
                        ""source"": null
                    }
                ]
            },
        ""target"": [
            {
                ""id"": ""00ud384zryL1GFAg30h7"",
                ""type"": ""User"",
                ""alternateId"": ""john-okta@example.com"",
                ""displayName"": ""John Okta"",
                ""detailEntry"": null
            }
        ]}]"
#pragma warning restore SA1123 // Do not place regions within elements
;
            #endregion
            return rawResponse;
        }
    }
}
