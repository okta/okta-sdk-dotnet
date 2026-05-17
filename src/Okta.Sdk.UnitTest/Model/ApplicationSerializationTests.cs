// <copyright file="ApplicationSerializationTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.UnitTest.Model
{
    /// <summary>
    /// Unit tests for Application model serialization.
    /// Verifies that read-only server-side fields (_links, _embedded, status) are NOT
    /// included when serializing an Application for PUT/POST requests, even after the
    /// object has been populated via deserialization from a GET response.
    /// See: https://github.com/okta/okta-sdk-dotnet/issues/871
    /// </summary>
    public class ApplicationSerializationTests
    {
        // A realistic GET response JSON that includes server-set fields
        private const string GetResponseJson = @"{
            ""id"": ""0oasqfu0z0ELgxGl41d7"",
            ""name"": ""oidc_client"",
            ""label"": ""Test OIDC App"",
            ""status"": ""ACTIVE"",
            ""lastUpdated"": ""2024-01-15T10:00:00.000Z"",
            ""created"": ""2024-01-10T08:00:00.000Z"",
            ""signOnMode"": ""OPENID_CONNECT"",
            ""orn"": ""orn:okta:atko:00o1ab:app:0oasqfu0z0ELgxGl41d7"",
            ""_embedded"": {
                ""user"": {}
            },
            ""_links"": {
                ""appLinks"": [{""name"": ""oidc_client_link"", ""href"": ""https://example.okta.com/home/oidc_client/0oasqfu0z0ELgxGl41d7/aln5z7uhkbM6y7bMy0g7"", ""type"": ""text/html""}],
                ""self"": {""href"": ""https://example.okta.com/api/v1/apps/0oasqfu0z0ELgxGl41d7""}
            }
        }";

        [Fact]
        public void Serialize_AfterDeserializingGetResponse_ShouldNotIncludeStatus()
        {
            // Arrange - simulate the GET→PUT flow
            var app = JsonConvert.DeserializeObject<Application>(GetResponseJson);

            // Act - serialize for PUT body
            var json = JsonConvert.SerializeObject(app);
            var obj = JObject.Parse(json);

            // Assert - status must NOT be in PUT body (it's server-controlled)
            obj.ContainsKey("status").Should().BeFalse(
                "status is a server-managed read-only field and must not be sent in PUT/POST requests");
        }

        [Fact]
        public void Serialize_AfterDeserializingGetResponse_ShouldNotIncludeLinks()
        {
            // Arrange
            var app = JsonConvert.DeserializeObject<Application>(GetResponseJson);

            // Act
            var json = JsonConvert.SerializeObject(app);
            var obj = JObject.Parse(json);

            // Assert - _links must NOT be in PUT body (it's server-generated HAL)
            obj.ContainsKey("_links").Should().BeFalse(
                "_links is a server-generated HAL field and must not be sent in PUT/POST requests");
        }

        [Fact]
        public void Serialize_AfterDeserializingGetResponse_ShouldNotIncludeEmbedded()
        {
            // Arrange
            var app = JsonConvert.DeserializeObject<Application>(GetResponseJson);

            // Act
            var json = JsonConvert.SerializeObject(app);
            var obj = JObject.Parse(json);

            // Assert - _embedded must NOT be in PUT body (it's server-generated)
            obj.ContainsKey("_embedded").Should().BeFalse(
                "_embedded is a server-generated field and must not be sent in PUT/POST requests");
        }

        [Fact]
        public void Serialize_AfterDeserializingGetResponse_ShouldNotIncludeReadOnlyFields()
        {
            // Arrange - simulate GET → PUT flow for an OIDC app (the subtype used in issue #871).
            // When signOnMode is "OPENID_CONNECT", the JSON discriminator resolves the object to
            // OpenIdConnectApplication, which intentionally overrides ShouldSerializeName() so
            // that 'name' IS included (needed for app-type identification). All other server-managed
            // fields must remain absent from the PUT body.
            var app = JsonConvert.DeserializeObject<Application>(GetResponseJson);

            // Act - serialize for PUT body
            var json = JsonConvert.SerializeObject(app);
            var obj = JObject.Parse(json);

            // Assert - all server-managed fields from issue #871 must be absent
            obj.ContainsKey("status").Should().BeFalse("status is a server-managed read-only field");
            obj.ContainsKey("_links").Should().BeFalse("_links is server-generated HAL and must not be sent");
            obj.ContainsKey("_embedded").Should().BeFalse("_embedded is server-generated and must not be sent");
            // Additional read-only fields that must also be absent
            obj.ContainsKey("id").Should().BeFalse("id is read-only");
            obj.ContainsKey("created").Should().BeFalse("created is read-only");
            obj.ContainsKey("lastUpdated").Should().BeFalse("lastUpdated is read-only");
            obj.ContainsKey("orn").Should().BeFalse("orn is read-only");
        }

        [Fact]
        public void Serialize_AfterDeserializingGetResponse_ShouldPreserveWritableFields()
        {
            // Arrange
            var app = JsonConvert.DeserializeObject<Application>(GetResponseJson);

            // Act
            var json = JsonConvert.SerializeObject(app);
            var obj = JObject.Parse(json);

            // Assert - writable fields MUST be preserved in PUT body
            obj.ContainsKey("label").Should().BeTrue("label is a writable field");
            obj["label"]!.ToString().Should().Be("Test OIDC App");
            obj.ContainsKey("signOnMode").Should().BeTrue("signOnMode is a required writable field");
        }

        [Fact]
        public void ShouldSerializeStatus_ReturnsFalse()
        {
            var app = new Application();
            app.ShouldSerializeStatus().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeLinks_ReturnsFalse()
        {
            var app = new Application();
            app.ShouldSerializeLinks().Should().BeFalse();
        }

        [Fact]
        public void ShouldSerializeEmbedded_ReturnsFalse()
        {
            var app = new Application();
            app.ShouldSerializeEmbedded().Should().BeFalse();
        }
    }
}
