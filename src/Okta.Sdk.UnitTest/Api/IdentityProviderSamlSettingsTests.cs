// <copyright file="IdentityProviderSamlSettingsTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class IdentityProviderSamlSettingsTests
    {
        private const string BaseUrl = "https://test.okta.com";

        // Minimal SAML IdP response so CreateIdentityProviderAsync can deserialize a result.
        private const string SamlIdpResponseJson = @"{
            ""id"": ""0oaSamlIdp0h7"",
            ""type"": ""SAML2"",
            ""name"": ""Test SAML IdP"",
            ""protocol"": { ""type"": ""SAML2"", ""settings"": { ""honorPersistentNameId"": false } }
        }";

        private static IdentityProvider BuildSamlIdp(SamlSettings settings) => new IdentityProvider
        {
            Type = IdentityProviderType.SAML2,
            Name = "Test SAML IdP",
            Protocol = new IdentityProviderProtocol(new ProtocolSaml
            {
                Type = ProtocolSaml.TypeEnum.SAML2,
                Settings = settings,
            }),
        };

        // Regression test for https://github.com/okta/okta-sdk-dotnet/issues/896.
        // honorPersistentNameId/participateSlo/sendApplicationContext are optional SAML settings
        // (the API applies its own defaults — honorPersistentNameId defaults to true). They were
        // generated as non-nullable `bool`, so the SDK always emitted them (defaulting to false),
        // overriding the API default and giving callers no way to omit them. Making them `bool?`
        // means an unset value is omitted from the request body.

        [Fact]
        public async Task SamlSettings_WhenNotSet_AreOmittedFromRequestBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(SamlIdpResponseJson);
            var idpApi = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Settings present but the optional booleans left unset (null).
            var idp = BuildSamlIdp(new SamlSettings { NameFormat = SamlNameIdFormat._20nameidFormatpersistent });

            // Act
            await idpApi.CreateIdentityProviderAsync(idp);

            // Assert — unset optional booleans must NOT appear in the payload, so the API applies its defaults.
            mockClient.ReceivedBody.Should().NotContain("honorPersistentNameId");
            mockClient.ReceivedBody.Should().NotContain("participateSlo");
            mockClient.ReceivedBody.Should().NotContain("sendApplicationContext");
        }

        [Fact]
        public async Task SamlSettings_WhenHonorPersistentNameIdSetFalse_IsSerialized()
        {
            // Arrange
            var mockClient = new MockAsyncClient(SamlIdpResponseJson);
            var idpApi = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            var idp = BuildSamlIdp(new SamlSettings { HonorPersistentNameId = false });

            // Act
            await idpApi.CreateIdentityProviderAsync(idp);

            // Assert — an explicitly-set value (even false) must be sent so callers can control it.
            mockClient.ReceivedBody.Should().Contain("\"honorPersistentNameId\":false");
        }
    }
}
