// <copyright file="RoleBTargetClientApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    /// <summary>
    /// Unit tests for RoleBTargetClientApi to verify proper type handling.
    /// These tests verify Issue #810 - ensuring that ListAppTargetRoleToClient
    /// and ListGroupTargetRoleForClient return the correct types (CatalogApplication
    /// and Group respectively), not ModelClient.
    /// </summary>
    public class RoleBTargetClientApiTests
    {
        private Mock<IAsynchronousClient> CreateMockAsyncClient()
        {
            return new Mock<IAsynchronousClient>();
        }

        private Configuration CreateTestConfiguration()
        {
            return new Configuration
            {
                OktaDomain = "https://test.okta.com"
            };
        }

        private RoleBTargetClientApi CreateRoleBTargetClientApi(Mock<IAsynchronousClient> mockClient = null)
        {
            var client = mockClient ?? CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            return new RoleBTargetClientApi(client.Object, config);
        }

        #region CatalogApplication Deserialization Tests

        [Fact]
        public void CatalogApplication_ShouldDeserializeCorrectly()
        {
            // Arrange - This is the expected JSON response format from Okta API for catalog applications
            var json = @"[
                {
                    ""name"": ""facebook"",
                    ""displayName"": ""Facebook"",
                    ""description"": ""Social networking"",
                    ""status"": ""ACTIVE"",
                    ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                    ""category"": ""Social"",
                    ""verificationStatus"": ""OKTA_VERIFIED"",
                    ""website"": ""https://www.facebook.com"",
                    ""signOnModes"": [""SAML_2_0""],
                    ""features"": [""PUSH_NEW_USERS""],
                    ""_links"": {
                        ""logo"": [{ ""href"": ""https://example.com/logo.png"" }]
                    }
                }
            ]";

            // Act
            var applications = JsonConvert.DeserializeObject<List<CatalogApplication>>(json);

            // Assert
            applications.Should().NotBeNull();
            applications.Should().HaveCount(1);
            
            var app = applications[0];
            app.Should().NotBeNull();
            app.Should().BeOfType<CatalogApplication>();
            app.Name.Should().Be("facebook");
            app.DisplayName.Should().Be("Facebook");
            app.Description.Should().Be("Social networking");
        }

        [Fact]
        public void CatalogApplication_ShouldNotDeserializeAsModelClient()
        {
            // Arrange - This test verifies that CatalogApplication is a distinct type from ModelClient
            // Issue #810 claims the API returns ModelClient, but these are different models
            var catalogAppJson = @"{
                ""name"": ""facebook"",
                ""displayName"": ""Facebook"",
                ""description"": ""Social networking""
            }";

            var modelClientJson = @"{
                ""client_id"": ""0oa1234"",
                ""client_name"": ""My OAuth App"",
                ""client_uri"": ""https://example.com""
            }";

            // Act
            var catalogApp = JsonConvert.DeserializeObject<CatalogApplication>(catalogAppJson);
            var modelClient = JsonConvert.DeserializeObject<ModelClient>(modelClientJson);

            // Assert - These are different types with different properties
            catalogApp.Should().BeOfType<CatalogApplication>();
            modelClient.Should().BeOfType<ModelClient>();
            
            // CatalogApplication has Name, DisplayName, Description (OIN catalog app properties)
            catalogApp.Name.Should().Be("facebook");
            catalogApp.DisplayName.Should().Be("Facebook");
            
            // ModelClient has ClientId, ClientName, ClientUri (OAuth client properties)
            modelClient.ClientId.Should().Be("0oa1234");
            modelClient.ClientName.Should().Be("My OAuth App");
        }

        #endregion

        #region Group Deserialization Tests

        [Fact]
        public void Group_ShouldDeserializeCorrectly()
        {
            // Arrange
            var json = @"[
                {
                    ""id"": ""00g1234567890"",
                    ""created"": ""2023-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                    ""lastMembershipUpdated"": ""2023-01-15T10:30:00.000Z"",
                    ""objectClass"": [""okta:user_group""],
                    ""type"": ""OKTA_GROUP"",
                    ""profile"": {
                        ""name"": ""Test Group"",
                        ""description"": ""A test group""
                    }
                }
            ]";

            // Act
            var groups = JsonConvert.DeserializeObject<List<Group>>(json);

            // Assert
            groups.Should().NotBeNull();
            groups.Should().HaveCount(1);
            
            var group = groups[0];
            group.Should().NotBeNull();
            group.Should().BeOfType<Group>();
            group.Id.Should().Be("00g1234567890");
            group.Type.Should().Be(GroupType.OKTAGROUP);
            
            // Access profile properties through the wrapper
            var oktaProfile = group.Profile?.GetOktaUserGroupProfile();
            oktaProfile?.Name.Should().Be("Test Group");
            oktaProfile?.Description.Should().Be("A test group");
        }

        #endregion

        #region API Method Return Type Tests

        [Fact]
        public void ListAppTargetRoleToClient_ReturnType_ShouldBeCatalogApplicationCollection()
        {
            // Arrange
            var api = CreateRoleBTargetClientApi();
            
            // Act - This test verifies at compile time that the return type is correct
            // If this compiles, the return type is IOktaCollectionClient<CatalogApplication>
            // Issue #810 claims this returns ModelClient which is incorrect
            IOktaCollectionClient<CatalogApplication> result = api.ListAppTargetRoleToClient(
                clientId: "testClientId", 
                roleAssignmentId: "testRoleAssignmentId");
            
            // Assert - The fact that this compiles proves the return type is correct
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<CatalogApplication>>();
        }

        [Fact]
        public void ListGroupTargetRoleForClient_ReturnType_ShouldBeGroupCollection()
        {
            // Arrange
            var api = CreateRoleBTargetClientApi();
            
            // Act - This test verifies at compile time that the return type is correct
            // If this compiles, the return type is IOktaCollectionClient<Group>
            // Issue #810 claims this returns ModelClient which is incorrect
            IOktaCollectionClient<Group> result = api.ListGroupTargetRoleForClient(
                clientId: "testClientId", 
                roleAssignmentId: "testRoleAssignmentId");
            
            // Assert - The fact that this compiles proves the return type is correct
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<Group>>();
        }

        [Fact]
        public void ListAppTargetRoleToClient_ShouldNotReturnModelClient()
        {
            // This test demonstrates that ListAppTargetRoleToClient returns CatalogApplication, not ModelClient
            // Issue #810 claims the method returns ModelClient which is incorrect
            
            var api = CreateRoleBTargetClientApi();
            var result = api.ListAppTargetRoleToClient(
                clientId: "testClientId", 
                roleAssignmentId: "testRoleAssignmentId");
            
            // Verify the return type is specifically CatalogApplication
            result.Should().BeAssignableTo<IOktaCollectionClient<CatalogApplication>>();
            
            // Note: The following would NOT compile if the method returned ModelClient:
            // IOktaCollectionClient<ModelClient> wrongType = api.ListAppTargetRoleToClient(...);
            // This is a compile-time proof that the SDK is correctly typed.
        }

        [Fact]
        public void ListGroupTargetRoleForClient_ShouldNotReturnModelClient()
        {
            // This test demonstrates that ListGroupTargetRoleForClient returns Group, not ModelClient
            // Issue #810 claims the method returns ModelClient which is incorrect
            
            var api = CreateRoleBTargetClientApi();
            var result = api.ListGroupTargetRoleForClient(
                clientId: "testClientId", 
                roleAssignmentId: "testRoleAssignmentId");
            
            // Verify the return type is specifically Group
            result.Should().BeAssignableTo<IOktaCollectionClient<Group>>();
            
            // Note: The following would NOT compile if the method returned ModelClient:
            // IOktaCollectionClient<ModelClient> wrongType = api.ListGroupTargetRoleForClient(...);
            // This is a compile-time proof that the SDK is correctly typed.
        }

        #endregion

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            // Arrange
            var config = CreateTestConfiguration();

            // Act
            Action act = () => new RoleBTargetClientApi(null, config);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();

            // Act
            Action act = () => new RoleBTargetClientApi(mockClient.Object, null);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();

            // Act
            var api = new RoleBTargetClientApi(mockClient.Object, config);

            // Assert
            api.Should().NotBeNull();
            api.Should().BeAssignableTo<IRoleBTargetClientApiAsync>();
        }

        #endregion
    }
}
