// <copyright file="TokenPayLoadDataContextAllOfProtocolOriginalGrantTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Newtonsoft.Json;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.UnitTest.Model
{
    /// <summary>
    /// Unit tests for TokenPayLoadDataContextAllOfProtocolOriginalGrant
    /// Verifies that the model correctly deserializes JSON with the 'authorization' field
    /// as returned by the Okta API for token inline hooks.
    /// See: https://github.com/okta/okta-sdk-dotnet/issues/816
    /// </summary>
    public class TokenPayLoadDataContextAllOfProtocolOriginalGrantTests
    {
        [Fact]
        public void Deserialize_WithAuthorizationField_ShouldMapCorrectly()
        {
            // Arrange - JSON as returned by Okta API for token inline hooks
            var json = @"{
                ""authorization"": {
                    ""scope"": ""openid profile email"",
                    ""redirect_uri"": ""https://example.com/callback"",
                    ""response_type"": ""code"",
                    ""response_mode"": ""query"",
                    ""state"": ""xyz123"",
                    ""client_id"": ""0oa1client123""
                },
                ""refresh_token"": {
                    ""jti"": ""oarRefreshTokenJti123""
                }
            }";

            // Act
            var result = JsonConvert.DeserializeObject<TokenPayLoadDataContextAllOfProtocolOriginalGrant>(json);

            // Assert
            result.Should().NotBeNull();
            result.Authorization.Should().NotBeNull();
            result.Authorization.Scope.Should().Be("openid profile email");
            result.Authorization.RedirectUri.Should().Be("https://example.com/callback");
            result.Authorization.ResponseType.Value.Should().Be("code");
            result.Authorization.ResponseMode.Value.Should().Be("query");
            result.Authorization.State.Should().Be("xyz123");
            result.Authorization.ClientId.Should().Be("0oa1client123");
            
            result.RefreshToken.Should().NotBeNull();
            result.RefreshToken.Jti.Should().Be("oarRefreshTokenJti123");
        }

        [Fact]
        public void Deserialize_WithOnlyAuthorizationField_ShouldMapCorrectly()
        {
            // Arrange
            var json = @"{
                ""authorization"": {
                    ""scope"": ""openid"",
                    ""redirect_uri"": ""https://example.com/callback""
                }
            }";

            // Act
            var result = JsonConvert.DeserializeObject<TokenPayLoadDataContextAllOfProtocolOriginalGrant>(json);

            // Assert
            result.Should().NotBeNull();
            result.Authorization.Should().NotBeNull();
            result.Authorization.Scope.Should().Be("openid");
            result.Authorization.RedirectUri.Should().Be("https://example.com/callback");
            result.RefreshToken.Should().BeNull();
        }

        [Fact]
        public void Serialize_ShouldOutputAuthorizationField()
        {
            // Arrange
            var model = new TokenPayLoadDataContextAllOfProtocolOriginalGrant
            {
                Authorization = new TokenProtocolRequest
                {
                    Scope = "openid profile",
                    RedirectUri = "https://example.com/callback"
                },
                RefreshToken = new RefreshToken
                {
                    Jti = "testJti123"
                }
            };

            // Act
            var json = JsonConvert.SerializeObject(model);

            // Assert
            json.Should().Contain("\"authorization\":");
            json.Should().Contain("\"openid profile\"");
            json.Should().Contain("\"https://example.com/callback\"");
            json.Should().Contain("\"refresh_token\":");
            json.Should().Contain("\"testJti123\"");
            
            // Ensure the old incorrect field name is NOT present
            json.Should().NotContain("\"request\":");
        }

        [Fact]
        public void Deserialize_WithOldRequestField_ShouldNotMap()
        {
            // Arrange - JSON with old incorrect 'request' field name
            // This should NOT deserialize to Authorization property
            var json = @"{
                ""request"": {
                    ""scope"": ""openid profile"",
                    ""redirect_uri"": ""https://example.com/callback""
                }
            }";

            // Act
            var result = JsonConvert.DeserializeObject<TokenPayLoadDataContextAllOfProtocolOriginalGrant>(json);

            // Assert - Authorization should be null since we're looking for 'authorization' not 'request'
            result.Should().NotBeNull();
            result.Authorization.Should().BeNull();
        }
    }
}
