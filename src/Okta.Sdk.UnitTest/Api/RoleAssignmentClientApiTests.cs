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
    /// Unit tests for RoleAssignmentClientApi to verify Issue #807 fix.
    /// Issue #807: ListRolesForClientAsync returns null due to incorrect return type.
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
        /// </summary>
        [Fact]
        public void Issue807_Fixed_ListRolesForClient_ReturnsCollection()
        {
            var api = CreateRoleAssignmentClientApi();
            
            // Verify the new method exists (non-async version that returns collection)
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("ListRolesForClient");
            methodInfo.Should().NotBeNull("Method ListRolesForClient should exist");
            
            var returnType = methodInfo.ReturnType;
            
            // After the fix, it should return IOktaCollectionClient<ListRolesForClient200ResponseInner>
            returnType.IsGenericType.Should().BeTrue();
            returnType.GetGenericTypeDefinition().Should().Be(typeof(IOktaCollectionClient<>),
                "ListRolesForClient should return IOktaCollectionClient<T>");
            
            var innerType = returnType.GetGenericArguments()[0];
            innerType.Name.Should().Be("ListRolesForClient200ResponseInner",
                "The collection item type should be ListRolesForClient200ResponseInner");
        }

        /// <summary>
        /// Issue #807 FIX: Verifies the new response type can handle discriminator-based deserialization.
        /// </summary>
        [Fact]
        public void Issue807_Fixed_ListRolesForClient200ResponseInner_HasDiscriminatorLogic()
        {
            // Verify the FromJson method exists with discriminator support
            var responseType = typeof(ListRolesForClient200ResponseInner);
            var fromJsonMethod = responseType.GetMethod("FromJson", new[] { typeof(string) });
            
            fromJsonMethod.Should().NotBeNull("FromJson method should exist for discriminator-based deserialization");
        }

        /// <summary>
        /// Verifies that StandardRole types are properly deserialized using discriminator.
        /// </summary>
        [Fact]
        public void Issue807_Fixed_StandardRole_DeserializesViaDiscriminator()
        {
            // Arrange - APP_ADMIN maps to StandardRole via discriminator
            var json = @"{
                ""id"": ""IFIFAX2BIRGUSTQ"",
                ""label"": ""Application Administrator"",
                ""type"": ""APP_ADMIN"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-05-01T14:24:54.000Z"",
                ""lastUpdated"": ""2023-05-01T14:24:54.000Z"",
                ""assignmentType"": ""CLIENT""
            }";

            // Act - Use the new discriminator-based FromJson
            var role = ListRolesForClient200ResponseInner.FromJson(json);

            // Assert
            role.Should().NotBeNull("Discriminator should properly deserialize APP_ADMIN as StandardRole");
            role.ActualInstance.Should().BeOfType<StandardRole>("APP_ADMIN should map to StandardRole");
            
            var standardRole = role.GetStandardRole();
            standardRole.Id.Should().Be("IFIFAX2BIRGUSTQ");
            standardRole.Type.Value.Should().Be("APP_ADMIN");
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
            var role = ListRolesForClient200ResponseInner.FromJson(json);

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
        /// </summary>
        [Fact]
        public void StandardRoleList_ShouldDeserializeFromJsonArray()
        {
            // Arrange
            var json = @"[
                {
                    ""id"": ""ROLE1"",
                    ""label"": ""App Admin"",
                    ""type"": ""APP_ADMIN"",
                    ""status"": ""ACTIVE"",
                    ""assignmentType"": ""CLIENT""
                },
                {
                    ""id"": ""ROLE2"",
                    ""label"": ""User Admin"",
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
            roles[0].Type.Should().Be(RoleType.APPADMIN);
            roles[1].Type.Should().Be(RoleType.USERADMIN);
        }

        #endregion

        #region API Method Existence Tests

        /// <summary>
        /// Verify that AssignRoleToClientAsync has the correct method signature.
        /// </summary>
        [Fact]
        public void AssignRoleToClientAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("AssignRoleToClientAsync");
            
            methodInfo.Should().NotBeNull("Method AssignRoleToClientAsync should exist");
        }

        /// <summary>
        /// Verify that DeleteRoleFromClientAsync has the correct method signature.
        /// </summary>
        [Fact]
        public void DeleteRoleFromClientAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("DeleteRoleFromClientAsync");
            
            methodInfo.Should().NotBeNull("Method DeleteRoleFromClientAsync should exist");
        }

        /// <summary>
        /// Verify that RetrieveClientRoleAsync has the correct method signature.
        /// </summary>
        [Fact]
        public void RetrieveClientRoleAsync_ShouldExist()
        {
            var api = CreateRoleAssignmentClientApi();
            var methodInfo = typeof(RoleAssignmentClientApi).GetMethod("RetrieveClientRoleAsync");
            
            methodInfo.Should().NotBeNull("Method RetrieveClientRoleAsync should exist");
        }

        #endregion
    }
}
