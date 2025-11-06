// <copyright file="SchemaApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

﻿using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class SchemaApiTests
    {
        private readonly SchemaApi _schemaApi = new();
        private readonly ApplicationApi _applicationApi = new();

        [Fact]
        public async Task GivenSchemaApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            // This comprehensive test covers all Schema API endpoints and methods with CRUD operations where applicable
            // Endpoints covered:
            // 1. GET /api/v1/meta/schemas/user/{schemaId} - GetUserSchemaAsync
            // 2. POST /api/v1/meta/schemas/user/{schemaId} - UpdateUserProfileAsync
            // 3. GET /api/v1/meta/schemas/group/default - GetGroupSchemaAsync
            // 4. POST /api/v1/meta/schemas/group/default - UpdateGroupSchemaAsync
            // 5. GET /api/v1/meta/schemas/apps/{appId}/default - GetApplicationUserSchemaAsync
            // 6. POST /api/v1/meta/schemas/apps/{appId}/default - UpdateApplicationUserProfileAsync
            // 7. GET /api/v1/meta/schemas/logStream - ListLogStreamSchemasAsync
            // 8. GET /api/v1/meta/schemas/logStream/{logStreamType} - GetLogStreamSchemaAsync
            
            BasicAuthApplication testApp = null;
            var testAttributeName = $"test_{RandomString(10)}";
            var testAttributeTitle = $"Test Attribute {RandomString(6)}";
            var guid = Guid.NewGuid();

            try
            {
                // ============================================================
                // USER SCHEMA TESTS - Endpoint 1 & 2
                // ============================================================

                // GET User Schema - Retrieve default user schema
                var userSchema = await _schemaApi.GetUserSchemaAsync("default");
                
                userSchema.Should().NotBeNull();
                userSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
                userSchema.Name.Should().Be("user");
                userSchema.Title.Should().Be("User");
                userSchema.Id.Should().NotBeNullOrEmpty();
                userSchema.Type.Should().Be("object");
                userSchema.Definitions.Should().NotBeNull();
                userSchema.Definitions.Base.Should().NotBeNull();
                userSchema.Definitions.Base.Id.Should().Be("#base");
                userSchema.Definitions.Base.Type.Should().Be("object");
                userSchema.Definitions.Base.Properties.Should().NotBeNull();
                userSchema.Definitions.Base.Properties.Login.Should().NotBeNull();
                userSchema.Definitions.Base.Properties.Login.Title.Should().Be("Username");
                userSchema.Definitions.Base.Properties.Login.Type.Value.Should().Be("string");
                userSchema.Definitions.Base.Properties.Login.Required.Should().BeTrue();
                userSchema.Definitions.Base.Properties.Login.Mutability.Should().Be(UserSchemaAttributeMutabilityString.READWRITE);
                userSchema.Definitions.Base.Properties.Login.Scope.Value.Should().Be("NONE");
                userSchema.Definitions.Base.Properties.Login.MinLength.Should().Be(5);
                userSchema.Definitions.Base.Properties.Login.MaxLength.Should().Be(100);
                userSchema.Definitions.Base.Required.Should().Contain("login");

                // POST User Schema - Add custom string attribute
                var customAttributeDetails = new UserSchemaAttribute()
                {
                    Title = testAttributeTitle,
                    Type = "string",
                    Description = guid.ToString(),
                    MinLength = 1,
                    MaxLength = 20,
                    Permissions =
                    [
                        new()
                        {
                            Action = "READ_WRITE",
                            Principal = "SELF"
                        }
                    ]
                };

                var customAttribute = new Dictionary<string, UserSchemaAttribute>
                {
                    [testAttributeName] = customAttributeDetails
                };
                userSchema.Definitions.Custom.Properties = customAttribute;

                var updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", userSchema);
                
                updatedUserSchema.Should().NotBeNull();
                updatedUserSchema.Definitions.Custom.Properties.Should().ContainKey(testAttributeName);
                var retrievedCustomAttribute = updatedUserSchema.Definitions.Custom.Properties[testAttributeName];
                retrievedCustomAttribute.Title.Should().Be(testAttributeTitle);
                retrievedCustomAttribute.Type.Value.Should().Be("string");
                retrievedCustomAttribute.Description.Should().Be(guid.ToString());
                (retrievedCustomAttribute.Required == null || retrievedCustomAttribute.Required == false).Should().BeTrue();
                retrievedCustomAttribute.MinLength.Should().Be(1);
                retrievedCustomAttribute.MaxLength.Should().Be(20);
                retrievedCustomAttribute.Permissions.FirstOrDefault()?.Principal.Should().Be("SELF");
                retrievedCustomAttribute.Permissions.FirstOrDefault()?.Action.Should().Be("READ_WRITE");

                Thread.Sleep(6000); // Wait for schema update to propagate

                // Verify GET returns updated schema
                userSchema = await _schemaApi.GetUserSchemaAsync("default");
                userSchema.Definitions.Custom.Properties.Should().ContainKey(testAttributeName);

                // POST-User Schema - Test array property
                var arrayAttributeName = $"array_{RandomString(10)}";
                var arrayAttributeDetails = new UserSchemaAttribute()
                {
                    Title = $"Array Test {RandomString(6)}",
                    Type = UserSchemaAttributeType.Array,
                    Description = "Array attribute for testing",
                    Permissions =
                    [
                        new()
                        {
                            Action = "READ_WRITE",
                            Principal = "SELF"
                        }
                    ],
                    Items = new UserSchemaAttributeItems
                    {
                        Type = "string"
                    }
                };

                customAttribute[arrayAttributeName] = arrayAttributeDetails;
                userSchema.Definitions.Custom.Properties = customAttribute;
                
                updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", userSchema);
                updatedUserSchema.Definitions.Custom.Properties.Should().ContainKey(arrayAttributeName);
                var retrievedArrayAttribute = updatedUserSchema.Definitions.Custom.Properties[arrayAttributeName];
                retrievedArrayAttribute.Type.Value.Should().Be("array");
                retrievedArrayAttribute.MinLength.Should().BeNull();
                retrievedArrayAttribute.MaxLength.Should().BeNull();

                Thread.Sleep(6000);

                // ============================================================
                // GROUP SCHEMA TESTS - Endpoint 3 & 4
                // ============================================================

                // GET Group Schema - Retrieve default group schema
                var groupSchema = await _schemaApi.GetGroupSchemaAsync();
                
                groupSchema.Should().NotBeNull();
                groupSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
                groupSchema.Name.Should().Be("group");
                groupSchema.Title.Should().Be("Okta group");
                groupSchema.Id.Should().NotBeNullOrEmpty();
                groupSchema.Type.Should().Be("object");
                groupSchema.Definitions.Should().NotBeNull();
                groupSchema.Definitions.Base.Should().NotBeNull();
                groupSchema.Definitions.Base.Id.Should().Be("#base");
                groupSchema.Definitions.Custom.Should().NotBeNull();
                groupSchema.Definitions.Custom.Id.Should().Be("#custom");

                // POST-Group Schema - Add custom attribute
                var groupAttributeName = $"grp_{RandomString(10)}";
                var groupCustomAttributeDetails = new GroupSchemaAttribute()
                {
                    Title = $"Group Test {RandomString(6)}",
                    Type = "string",
                    Description = "Group custom attribute",
                    MinLength = 1,
                    MaxLength = 50
                };

                var groupCustomAttribute = new Dictionary<string, GroupSchemaAttribute>
                {
                    [groupAttributeName] = groupCustomAttributeDetails
                };
                groupSchema.Definitions.Custom.Properties = groupCustomAttribute;

                var updatedGroupSchema = await _schemaApi.UpdateGroupSchemaAsync(groupSchema);
                
                updatedGroupSchema.Should().NotBeNull();
                updatedGroupSchema.Definitions.Custom.Properties.Should().ContainKey(groupAttributeName);
                var retrievedGroupAttribute = updatedGroupSchema.Definitions.Custom.Properties[groupAttributeName];
                retrievedGroupAttribute.Title.Should().Be(groupCustomAttributeDetails.Title);
                retrievedGroupAttribute.Type.Value.Should().Be("string");
                retrievedGroupAttribute.Description.Should().Be(groupCustomAttributeDetails.Description);
                retrievedGroupAttribute.MinLength.Should().Be(1);
                retrievedGroupAttribute.MaxLength.Should().Be(50);

                Thread.Sleep(6000);

                // Verify GET returns updated group schema
                groupSchema = await _schemaApi.GetGroupSchemaAsync();
                groupSchema.Definitions.Custom.Properties.Should().ContainKey(groupAttributeName);

                // ============================================================
                // APPLICATION USER SCHEMA TESTS - Endpoint 5 & 6
                // ============================================================

                // Create test application for app user schema tests
                var app = new BasicAuthApplication
                {
                    Name = "template_basic_auth",
                    Label = $"dotnet-sdk: SchemaApiTests_{RandomString(8)}",
                    SignOnMode = "BASICAUTH",
                    Settings = new BasicApplicationSettings
                    {
                        App = new BasicApplicationSettingsApplication
                        {
                            Url = "https://example.com/login.html",
                            AuthURL = "https://example.com/auth.html"
                        }
                    }
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(app, true);
                testApp = createdApp as BasicAuthApplication;
                testApp.Should().NotBeNull();
                if (testApp != null)
                {
                    testApp.Id.Should().NotBeNullOrEmpty();

                    // GET Application User Schema - Retrieve app user schema
                    var appUserSchema = await _schemaApi.GetApplicationUserSchemaAsync(testApp.Id);

                    appUserSchema.Should().NotBeNull();
                    appUserSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
                    appUserSchema.Id.Should().NotBeNullOrEmpty();
                    appUserSchema.Definitions.Should().NotBeNull();
                    appUserSchema.Definitions.Base.Should().NotBeNull();
                    appUserSchema.Definitions.Custom.Should().NotBeNull();
                    appUserSchema.Type.Should().Be("object");

                    // POST Application User Schema - Add custom attribute
                    var appAttributeName = $"app_{RandomString(10)}";
                    var appCustomAttributeDetails = new UserSchemaAttribute()
                    {
                        Title = $"App Attr {RandomString(6)}",
                        Type = "string",
                        Description = "Application custom attribute",
                        MinLength = 1,
                        MaxLength = 30
                    };

                    var appCustomAttribute = new Dictionary<string, UserSchemaAttribute>
                    {
                        [appAttributeName] = appCustomAttributeDetails
                    };
                    appUserSchema.Definitions.Custom.Properties = appCustomAttribute;

                    var updatedAppUserSchema =
                        await _schemaApi.UpdateApplicationUserProfileAsync(testApp.Id, appUserSchema);

                    updatedAppUserSchema.Should().NotBeNull();
                    updatedAppUserSchema.Definitions.Custom.Properties.Should().ContainKey(appAttributeName);
                    var retrievedAppAttribute = updatedAppUserSchema.Definitions.Custom.Properties[appAttributeName];
                    retrievedAppAttribute.Title.Should().Be(appCustomAttributeDetails.Title);
                    retrievedAppAttribute.Type.Value.Should().Be("string");
                    retrievedAppAttribute.Description.Should().Be(appCustomAttributeDetails.Description);
                    retrievedAppAttribute.MinLength.Should().Be(1);
                    retrievedAppAttribute.MaxLength.Should().Be(30);

                    Thread.Sleep(6000);

                    // Verify GET returns updated app user schema
                    appUserSchema = await _schemaApi.GetApplicationUserSchemaAsync(testApp.Id);
                    appUserSchema.Definitions.Custom.Properties.Should().ContainKey(appAttributeName);

                    // ============================================================
                    // LOG STREAM SCHEMA TESTS (Read-only) - Endpoint 7 & 8
                    // ============================================================

                    // LIST Log Stream Schemas - Retrieve all log stream schemas
                    var logStreamSchemasList = _schemaApi.ListLogStreamSchemas();
                    var logStreamSchemas = await logStreamSchemasList.ToListAsync();

                    logStreamSchemas.Should().NotBeNull();
                    // Log stream schemas may not be available in all org's, so verify the list is returned
                    // If schemas are available, verify their structure
                    if (logStreamSchemas.Any())
                    {
                        var firstSchema = logStreamSchemas.First();
                        firstSchema.Should().NotBeNull();
                        firstSchema.Schema.Should().NotBeNullOrEmpty();
                        firstSchema.Type.Should().Be("object");

                        // Try to get AWS EventBridge schema if available
                        try
                        {
                            var awsLogStreamSchema =
                                await _schemaApi.GetLogStreamSchemaAsync(LogStreamType.AwsEventbridge);
                            awsLogStreamSchema.Should().NotBeNull();
                            awsLogStreamSchema.Title.Should().Be("AWS EventBridge");
                        }
                        catch (ApiException ex) when (ex.ErrorCode == 404)
                        {
                            // AWS EventBridge may not be available in this org
                        }

                        // Try to get Splunk Cloud schema if available
                        try
                        {
                            var splunkLogStreamSchema =
                                await _schemaApi.GetLogStreamSchemaAsync(LogStreamType.SplunkCloudLogstreaming);
                            splunkLogStreamSchema.Should().NotBeNull();
                            splunkLogStreamSchema.Title.Should().Be("Splunk Cloud");
                        }
                        catch (ApiException ex) when (ex.ErrorCode == 404)
                        {
                            // Splunk Cloud may not be available in this org
                        }
                    }

                    // ============================================================
                    // CLEANUP - Remove custom attributes (DELETE operations)
                    // ============================================================

                    // Cleanup: Remove app user schema custom attribute
                    appCustomAttribute[appAttributeName] = null;
                    appUserSchema.Definitions.Custom.Properties = appCustomAttribute;
                    updatedAppUserSchema =
                        await _schemaApi.UpdateApplicationUserProfileAsync(testApp.Id, appUserSchema);
                    updatedAppUserSchema.Definitions.Custom.Properties.Should().NotContainKey(appAttributeName);

                    Thread.Sleep(3000);

                    // Cleanup: Remove group schema custom attribute
                    groupCustomAttribute[groupAttributeName] = null;
                    groupSchema.Definitions.Custom.Properties = groupCustomAttribute;
                    updatedGroupSchema = await _schemaApi.UpdateGroupSchemaAsync(groupSchema);
                    updatedGroupSchema.Definitions.Custom.Properties.Should().NotContainKey(groupAttributeName);

                    Thread.Sleep(3000);

                    // Cleanup: Remove user schema custom attributes (both string and array)
                    customAttribute[testAttributeName] = null;
                    customAttribute[arrayAttributeName] = null;
                    userSchema.Definitions.Custom.Properties = customAttribute;
                    updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", userSchema);
                    updatedUserSchema.Definitions.Custom.Properties.Should().NotContainKey(testAttributeName);
                    updatedUserSchema.Definitions.Custom.Properties.Should().NotContainKey(arrayAttributeName);

                    // ============================================================
                    // FINAL VERIFICATION - Ensure all custom attributes are removed
                    // ============================================================

                    // Final verification - User schema
                    userSchema = await _schemaApi.GetUserSchemaAsync("default");
                    userSchema.Definitions.Custom.Properties.Should().NotContainKey(testAttributeName);
                    userSchema.Definitions.Custom.Properties.Should().NotContainKey(arrayAttributeName);

                    // Final verification - Group schema
                    groupSchema = await _schemaApi.GetGroupSchemaAsync();
                    groupSchema.Definitions.Custom.Properties.Should().NotContainKey(groupAttributeName);

                    // Final verification - App user schema
                    appUserSchema = await _schemaApi.GetApplicationUserSchemaAsync(testApp.Id);
                    appUserSchema.Definitions.Custom.Properties.Should().NotContainKey(appAttributeName);
                }
            }
            finally
            {
                // Cleanup: Delete test application
                if (testApp != null)
                {
                    try
                    {
                        await _applicationApi.DeactivateApplicationAsync(testApp.Id);
                        await _applicationApi.DeleteApplicationAsync(testApp.Id);
                    }
                    catch
                    {
                        // Best effort cleanup
                    }
                }
            }
        }

        private static string RandomString(int length)
        {
            var random = new Random();
            var result = string.Empty;
            for (var i = 0; i < length; i++)
            {
                result += Convert.ToChar(random.Next(97, 122)); // ascii codes for printable alphabet
            }

            return result;
        }
    }
}
