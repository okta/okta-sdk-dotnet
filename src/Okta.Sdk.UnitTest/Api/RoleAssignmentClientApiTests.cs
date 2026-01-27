// <copyright file="RoleAssignmentClientApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
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
    /// Unit tests for RoleAssignmentClientApi to verify Issue #807 fix and full API coverage.
    /// 
    /// API Endpoints Covered:
    /// - GET    /oauth2/v1/clients/{clientId}/roles                       - ListRolesForClient
    /// - POST   /oauth2/v1/clients/{clientId}/roles                       - AssignRoleToClient
    /// - GET    /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}    - RetrieveClientRole
    /// - DELETE /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}    - DeleteRoleFromClient
    /// 
    /// Issue #807: ListRolesForClientAsync returned null due to incorrect return type.
    /// 
    /// FIX APPLIED:
    /// 1. OpenAPI spec updated to return array type for listRolesForClient
    /// 2. Discriminator mapping added to properly distinguish between StandardRole and CustomRole
    /// 3. useOneOfDiscriminatorLookup enabled in generator config
    /// </summary>
    public class RoleAssignmentClientApiTests
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

        private RoleAssignmentClientApi CreateRoleAssignmentClientApi(Mock<IAsynchronousClient> mockClient = null)
        {
            var client = mockClient ?? CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            return new RoleAssignmentClientApi(client.Object, config);
        }

        #region Issue 807 Fix Verification Tests

        /// <summary>
        /// Issue #807 FIX: This test verifies that ListRolesForClient now returns
        /// a collection type (IOktaCollectionClient) instead of a single object.
        /// 
        /// API: GET /oauth2/v1/clients/{clientId}/roles
        /// </summary>
        [Fact]
        public void Issue807_Fixed_ListRolesForClient_ReturnsCollection()
        {
            var api = CreateRoleAssignmentClientApi();
            
            // Verify the new method exists (non-async version that returns collection)
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("ListRolesForClient");
            methodInfo.Should().NotBeNull("Method ListRolesForClient should exist");
            
            var returnType = methodInfo.ReturnType;
            
            // After the fix, it should return IOktaCollectionClient<ListGroupAssignedRoles200ResponseInner>
            returnType.IsGenericType.Should().BeTrue();
            returnType.GetGenericTypeDefinition().Should().Be(typeof(IOktaCollectionClient<>),
                "ListRolesForClient should return IOktaCollectionClient<T>");
            
            var innerType = returnType.GetGenericArguments()[0];
            innerType.Name.Should().Be("ListGroupAssignedRoles200ResponseInner",
                "The collection item type should be ListGroupAssignedRoles200ResponseInner");
        }

        /// <summary>
        /// Issue #807 FIX: Verifies the new response type can handle discriminator-based deserialization.
        /// </summary>
        [Fact]
        public void Issue807_Fixed_ListGroupAssignedRoles200ResponseInner_HasDiscriminatorLogic()
        {
            // Verify the FromJson method exists with discriminator support
            var responseType = typeof(ListGroupAssignedRoles200ResponseInner);
            var fromJsonMethod = responseType.GetMethod("FromJson", new[] { typeof(string) });
            
            fromJsonMethod.Should().NotBeNull("FromJson method should exist for discriminator-based deserialization");
        }

        /// <summary>
        /// Verifies that StandardRole types are properly deserialized using discriminator.
        /// Tests all standard role types as per API documentation.
        /// </summary>
        [Theory]
        [InlineData("APP_ADMIN", "Application Administrator")]
        [InlineData("HELP_DESK_ADMIN", "Help Desk Administrator")]
        [InlineData("USER_ADMIN", "User Administrator")]
        [InlineData("ORG_ADMIN", "Organization Administrator")]
        [InlineData("SUPER_ADMIN", "Super Administrator")]
        [InlineData("READ_ONLY_ADMIN", "Read Only Administrator")]
        [InlineData("MOBILE_ADMIN", "Mobile Administrator")]
        [InlineData("API_ACCESS_MANAGEMENT_ADMIN", "API Access Management Administrator")]
        [InlineData("REPORT_ADMIN", "Report Administrator")]
        [InlineData("GROUP_MEMBERSHIP_ADMIN", "Group Membership Administrator")]
        public void Issue807_Fixed_StandardRole_DeserializesViaDiscriminator(string roleType, string label)
        {
            // Arrange - Standard role types map to StandardRole via discriminator
            var json = $@"{{
                ""id"": ""ROLE_{roleType}"",
                ""label"": ""{label}"",
                ""type"": ""{roleType}"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-05-01T14:24:54.000Z"",
                ""lastUpdated"": ""2023-05-01T14:24:54.000Z"",
                ""assignmentType"": ""CLIENT""
            }}";

            // Act - Use the new discriminator-based FromJson
            var role = ListGroupAssignedRoles200ResponseInner.FromJson(json);

            // Assert
            role.Should().NotBeNull($"Discriminator should properly deserialize {roleType} as StandardRole");
            role.ActualInstance.Should().BeOfType<StandardRole>($"{roleType} should map to StandardRole");
            
            var standardRole = role.GetStandardRole();
            standardRole.Id.Should().Be($"ROLE_{roleType}");
            standardRole.Type.Value.Should().Be(roleType);
            standardRole.Status.Should().Be(LifecycleStatus.ACTIVE);
            standardRole.AssignmentType.Should().Be(RoleAssignmentType.CLIENT);
        }

        /// <summary>
        /// Verifies that CustomRole types are properly deserialized using discriminator.
        /// </summary>
        [Fact]
        public void Issue807_Fixed_CustomRole_DeserializesViaDiscriminator()
        {
            // Arrange - CUSTOM maps to CustomRole via discriminator
            var json = @"{
                ""id"": ""CUSTOM_ROLE_ID"",
                ""label"": ""My Custom Role"",
                ""type"": ""CUSTOM"",
                ""status"": ""ACTIVE"",
                ""assignmentType"": ""CLIENT"",
                ""role"": ""cr0abc123"",
                ""resource-set"": ""iam/resource-sets/xyz""
            }";

            // Act - Use the new discriminator-based FromJson
            var role = ListGroupAssignedRoles200ResponseInner.FromJson(json);

            // Assert
            role.Should().NotBeNull("Discriminator should properly deserialize CUSTOM as CustomRole");
            role.ActualInstance.Should().BeOfType<CustomRole>("CUSTOM should map to CustomRole");
            
            var customRole = role.GetCustomRole();
            customRole.Id.Should().Be("CUSTOM_ROLE_ID");
            customRole.Type.Value.Should().Be("CUSTOM");
        }

        #endregion

        #region StandardRole Deserialization Tests

        /// <summary>
        /// Verify that StandardRole can be properly deserialized from JSON.
        /// </summary>
        [Fact]
        public void StandardRole_ShouldDeserializeFromJson()
        {
            // Arrange
            var json = @"{
                ""id"": ""IFIFAX2BIRGUSTQ"",
                ""label"": ""Application Administrator"",
                ""type"": ""APP_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-05-01T14:24:54.000Z"",
                ""lastUpdated"": ""2023-05-01T14:24:54.000Z"",
                ""assignmentType"": ""CLIENT""
            }";

            // Act
            var role = JsonConvert.DeserializeObject<StandardRole>(json);

            // Assert
            role.Should().NotBeNull();
            role.Id.Should().Be("IFIFAX2BIRGUSTQ");
            role.Label.Should().Be("Application Administrator");
            role.Type.Should().Be(RoleType.APPADMIN);
            role.Status.Should().Be(LifecycleStatus.ACTIVE);
            role.AssignmentType.Should().Be(RoleAssignmentType.CLIENT);
        }

        /// <summary>
        /// Verify that a list of StandardRole objects can be deserialized from JSON array.
        /// This is critical for the ListRolesForClient endpoint which returns an array.
        /// </summary>
        [Fact]
        public void StandardRoleList_ShouldDeserializeFromJsonArray()
        {
            // Arrange - As per API documentation, this is the response format
            var json = @"[
                {
                    ""id"": ""JBCUYUC7IRCVGS27IFCE2SKO"",
                    ""label"": ""Help Desk Administrator"",
                    ""type"": ""HELP_DESK_ADMIN"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2023-05-01T14:24:54.000Z"",
                    ""lastUpdated"": ""2023-05-01T14:24:54.000Z"",
                    ""assignmentType"": ""CLIENT""
                },
                {
                    ""id"": ""ROLE2"",
                    ""label"": ""User Administrator"",
                    ""type"": ""USER_ADMIN"",
                    ""status"": ""ACTIVE"",
                    ""assignmentType"": ""CLIENT""
                }
            ]";

            // Act
            var roles = JsonConvert.DeserializeObject<List<StandardRole>>(json);

            // Assert
            roles.Should().NotBeNull();
            roles.Should().HaveCount(2);
            roles[0].Id.Should().Be("JBCUYUC7IRCVGS27IFCE2SKO");
            roles[0].Type.Should().Be(RoleType.HELPDESKADMIN);
            roles[1].Type.Should().Be(RoleType.USERADMIN);
        }

        #endregion

        #region API Method Existence Tests (All 4 Endpoints)

        /// <summary>
        /// Verify that ListRolesForClient method exists with correct signature.
        /// API: GET /oauth2/v1/clients/{clientId}/roles
        /// </summary>
        [Fact]
        public void ListRolesForClient_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("ListRolesForClient");
            
            methodInfo.Should().NotBeNull("Method ListRolesForClient should exist");
            
            var parameters = methodInfo.GetParameters();
            parameters.Should().HaveCountGreaterThanOrEqualTo(1);
            parameters[0].Name.Should().Be("clientId");
            parameters[0].ParameterType.Should().Be(typeof(string));
        }

        /// <summary>
        /// Verify that ListRolesForClientWithHttpInfoAsync method exists with correct signature.
        /// API: GET /oauth2/v1/clients/{clientId}/roles
        /// </summary>
        [Fact]
        public void ListRolesForClientWithHttpInfoAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("ListRolesForClientWithHttpInfoAsync");
            
            methodInfo.Should().NotBeNull("Method ListRolesForClientWithHttpInfoAsync should exist");
        }

        /// <summary>
        /// Verify that AssignRoleToClientAsync has the correct method signature.
        /// API: POST /oauth2/v1/clients/{clientId}/roles
        /// </summary>
        [Fact]
        public void AssignRoleToClientAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("AssignRoleToClientAsync");
            
            methodInfo.Should().NotBeNull("Method AssignRoleToClientAsync should exist");
            
            var parameters = methodInfo.GetParameters();
            parameters.Should().HaveCountGreaterThanOrEqualTo(2);
            parameters[0].Name.Should().Be("clientId");
            parameters[0].ParameterType.Should().Be(typeof(string));
            parameters[1].Name.Should().Be("assignRoleToGroupRequest");
            parameters[1].ParameterType.Should().Be(typeof(AssignRoleToGroupRequest));
        }

        /// <summary>
        /// Verify that RetrieveClientRoleAsync has the correct method signature.
        /// API: GET /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}
        /// </summary>
        [Fact]
        public void RetrieveClientRoleAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("RetrieveClientRoleAsync");
            
            methodInfo.Should().NotBeNull("Method RetrieveClientRoleAsync should exist");
            
            var parameters = methodInfo.GetParameters();
            parameters.Should().HaveCountGreaterThanOrEqualTo(2);
            parameters[0].Name.Should().Be("clientId");
            parameters[0].ParameterType.Should().Be(typeof(string));
            parameters[1].Name.Should().Be("roleAssignmentId");
            parameters[1].ParameterType.Should().Be(typeof(string));
        }

        /// <summary>
        /// Verify that DeleteRoleFromClientAsync has the correct method signature.
        /// API: DELETE /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}
        /// </summary>
        [Fact]
        public void DeleteRoleFromClientAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("DeleteRoleFromClientAsync");
            
            methodInfo.Should().NotBeNull("Method DeleteRoleFromClientAsync should exist");
            
            var parameters = methodInfo.GetParameters();
            parameters.Should().HaveCountGreaterThanOrEqualTo(2);
            parameters[0].Name.Should().Be("clientId");
            parameters[0].ParameterType.Should().Be(typeof(string));
            parameters[1].Name.Should().Be("roleAssignmentId");
            parameters[1].ParameterType.Should().Be(typeof(string));
        }

        /// <summary>
        /// Verify that RetrieveClientRoleWithHttpInfoAsync method exists.
        /// API: GET /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}
        /// </summary>
        [Fact]
        public void RetrieveClientRoleWithHttpInfoAsync_ShouldExist()
        {
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("RetrieveClientRoleWithHttpInfoAsync");
            methodInfo.Should().NotBeNull("Method RetrieveClientRoleWithHttpInfoAsync should exist");
        }

        /// <summary>
        /// Verify that DeleteRoleFromClientWithHttpInfoAsync method exists.
        /// API: DELETE /oauth2/v1/clients/{clientId}/roles/{roleAssignmentId}
        /// </summary>
        [Fact]
        public void DeleteRoleFromClientWithHttpInfoAsync_ShouldExist()
        {
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("DeleteRoleFromClientWithHttpInfoAsync");
            methodInfo.Should().NotBeNull("Method DeleteRoleFromClientWithHttpInfoAsync should exist");
        }

        /// <summary>
        /// Verify that AssignRoleToClientWithHttpInfoAsync method exists.
        /// API: POST /oauth2/v1/clients/{clientId}/roles
        /// </summary>
        [Fact]
        public void AssignRoleToClientWithHttpInfoAsync_ShouldExist()
        {
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("AssignRoleToClientWithHttpInfoAsync");
            methodInfo.Should().NotBeNull("Method AssignRoleToClientWithHttpInfoAsync should exist");
        }

        #endregion

        #region Request/Response Model Tests

        /// <summary>
        /// Verify that AssignRoleToGroupRequest can be created for standard roles.
        /// </summary>
        [Fact]
        public void AssignRoleToGroupRequest_ShouldSupportStandardRoles()
        {
            // Arrange - As per API documentation for standard role assignment
            var standardRoleRequest = new StandardRoleAssignmentSchema { Type = "HELP_DESK_ADMIN" };
            
            // Act
            var request = new AssignRoleToGroupRequest(standardRoleRequest);

            // Assert
            request.Should().NotBeNull();
            request.ActualInstance.Should().NotBeNull();
            request.ActualInstance.Should().BeOfType<StandardRoleAssignmentSchema>();
        }

        /// <summary>
        /// Verify that AssignRoleToGroupRequest can be created for custom roles.
        /// </summary>
        [Fact]
        public void AssignRoleToGroupRequest_ShouldSupportCustomRoles()
        {
            // Arrange - As per API documentation for custom role assignment
            var customRoleRequest = new CustomRoleAssignmentSchema 
            { 
                Type = "CUSTOM",
                Role = "cr0abc123",
                ResourceSet = "iam/resource-sets/xyz"
            };
            
            // Act
            var request = new AssignRoleToGroupRequest(customRoleRequest);

            // Assert
            request.Should().NotBeNull();
            request.ActualInstance.Should().NotBeNull();
            request.ActualInstance.Should().BeOfType<CustomRoleAssignmentSchema>();
        }

        /// <summary>
        /// Verify that ListGroupAssignedRoles200ResponseInner wrapper can be created from deserialized StandardRole.
        /// </summary>
        [Fact]
        public void ListGroupAssignedRoles200ResponseInner_ShouldWrapStandardRole()
        {
            // Arrange - Deserialize a StandardRole from JSON (since some properties are read-only)
            var json = @"{
                ""id"": ""ROLE123"",
                ""label"": ""App Admin"",
                ""type"": ""APP_ADMIN"",
                ""status"": ""ACTIVE"",
                ""assignmentType"": ""CLIENT""
            }";
            var standardRole = JsonConvert.DeserializeObject<StandardRole>(json);

            // Act
            var wrapper = new ListGroupAssignedRoles200ResponseInner(standardRole);

            // Assert
            wrapper.Should().NotBeNull();
            wrapper.ActualInstance.Should().Be(standardRole);
            wrapper.GetStandardRole().Should().Be(standardRole);
            wrapper.GetStandardRole().Id.Should().Be("ROLE123");
        }

        /// <summary>
        /// Verify that ListGroupAssignedRoles200ResponseInner wrapper works for CustomRole.
        /// </summary>
        [Fact]
        public void ListGroupAssignedRoles200ResponseInner_ShouldWrapCustomRole()
        {
            // Arrange - Deserialize a CustomRole from JSON (since some properties are read-only)
            var json = @"{
                ""id"": ""CUSTOM123"",
                ""label"": ""My Custom Role"",
                ""type"": ""CUSTOM"",
                ""status"": ""ACTIVE"",
                ""role"": ""cr0abc123""
            }";
            var customRole = JsonConvert.DeserializeObject<CustomRole>(json);

            // Act
            var wrapper = new ListGroupAssignedRoles200ResponseInner(customRole);

            // Assert
            wrapper.Should().NotBeNull();
            wrapper.ActualInstance.Should().Be(customRole);
            wrapper.GetCustomRole().Should().Be(customRole);
            wrapper.GetCustomRole().Id.Should().Be("CUSTOM123");
        }

        #endregion
    }
}
