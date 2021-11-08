// <copyright file="AuthenticatorClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class AuthenticatorClientShould
    {
        [Fact]
        public async Task ActivateAuthenticatorAsync()
        {
            var rawResponse = @"{
                                ""type"": ""security_key"",
                                ""id"": ""aut1nd8PQhGcQtSxB0g4"",
                                ""key"": ""webauthn"",
                                ""status"": ""ACTIVE"",
                                ""name"": ""Security Key or Biometric"",
                                ""created"": ""2020-07-26T21:16:37.000Z"",
                                ""lastUpdated"": ""2020-07-26T21:59:33.000Z"",
                                ""_links"": {
                                    ""self"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET"",
                                                ""PUT""
                                            ]
                                        }
                                    },
                                    ""methods"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4/methods"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET""
                                            ]
                                        }
                                    },
                                    ""deactivate"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4/lifecycle/deactivate"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""POST""
                                            ]
                                        }
                                    }
                                }
                            }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var authenticator = await client.Authenticators.ActivateAuthenticatorAsync("aut1nd8PQhGcQtSxB0g4");
            authenticator.Id.Should().Be("aut1nd8PQhGcQtSxB0g4");
            authenticator.Status.Should().Be(AuthenticatorStatus.Active);
            authenticator.Key.Should().Be("webauthn");
            authenticator.Name.Should().Be("Security Key or Biometric");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4/lifecycle/activate");
        }

        [Fact]
        public async Task DeactivateAuthenticatorAsync()
        {
            var rawResponse = @"{
                                ""type"": ""security_key"",
                                ""id"": ""aut1nd8PQhGcQtSxB0g4"",
                                ""key"": ""webauthn"",
                                ""status"": ""INACTIVE"",
                                ""name"": ""Security Key or Biometric"",
                                ""created"": ""2020-07-26T21:16:37.000Z"",
                                ""lastUpdated"": ""2020-07-26T21:59:33.000Z"",
                                ""_links"": {
                                    ""self"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET"",
                                                ""PUT""
                                            ]
                                        }
                                    },
                                    ""methods"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4/methods"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET""
                                            ]
                                        }
                                    },
                                    ""deactivate"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4/lifecycle/deactivate"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""POST""
                                            ]
                                        }
                                    }
                                }
                            }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var authenticator = await client.Authenticators.DeactivateAuthenticatorAsync("aut1nd8PQhGcQtSxB0g4");
            authenticator.Id.Should().Be("aut1nd8PQhGcQtSxB0g4");
            authenticator.Status.Should().Be(AuthenticatorStatus.Inactive);
            authenticator.Key.Should().Be("webauthn");
            authenticator.Name.Should().Be("Security Key or Biometric");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/authenticators/aut1nd8PQhGcQtSxB0g4/lifecycle/deactivate");
        }
    }
}
