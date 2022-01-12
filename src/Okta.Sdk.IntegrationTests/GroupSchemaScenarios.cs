// <copyright file="GroupSchemaScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class GroupSchemaScenarios
    {
        [Fact]
        public async Task GetGroupSchemaAsync()
        {
            var client = TestClient.Create();

            var groupSchema = await client.GroupSchemas.GetGroupSchemaAsync();
            groupSchema.Should().NotBeNull();
            groupSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
            groupSchema.Definitions?.Base?.Id.Should().Be("#base");
            groupSchema.Definitions?.Custom?.Id.Should().Be("#custom");
            groupSchema.Name.Should().Be("group");
        }

        [Fact]
        public async Task UpdatePropertyToGroupSchemaAsync()
        {
            var client = TestClient.Create();

            var groupSchema = await client.GroupSchemas.GetGroupSchemaAsync();
            var guid = Guid.NewGuid();

            // Add custom attribute
            var customAttributeDetails = new GroupSchemaAttribute()
            {
                Title = "Group administrative contact",
                Type = "string",
                Description = guid.ToString(),
                MinLength = 1,
                MaxLength = 20,
                Permissions = new List<IUserSchemaAttributePermission>
                {
                    new UserSchemaAttributePermission
                    {
                        Action = "READ_WRITE",
                        Principal = "SELF",
                    },
                },
            };

            var customAttribute = new Resource();
            customAttribute["groupContact"] = customAttributeDetails;
            groupSchema.Definitions.Custom.Properties = customAttribute;

            var updatedGroupSchema = await client.GroupSchemas.UpdateGroupSchemaAsync(groupSchema);

            var retrievedCustomAttribute = updatedGroupSchema.Definitions.Custom.Properties.GetProperty<GroupSchemaAttribute>("groupContact");
            retrievedCustomAttribute.Title.Should().Be("Group administrative contact");
            retrievedCustomAttribute.Type.Should().Be(UserSchemaAttributeType.String);
            retrievedCustomAttribute.Description.Should().Be(guid.ToString());
            retrievedCustomAttribute.Required.Should().BeNull();
            retrievedCustomAttribute.MinLength.Should().Be(1);
            retrievedCustomAttribute.MaxLength.Should().Be(20);
            retrievedCustomAttribute.Permissions.FirstOrDefault().Principal.Should().Be("SELF");
            retrievedCustomAttribute.Permissions.FirstOrDefault().Action.Should().Be("READ_WRITE");

            // Wait for job to be finished
            Thread.Sleep(6000);

            // Remove custom attribute
            customAttribute["groupContact"] = null;
            updatedGroupSchema.Definitions.Custom.Properties = customAttribute;
            updatedGroupSchema = await client.GroupSchemas.UpdateGroupSchemaAsync(updatedGroupSchema);
            updatedGroupSchema.Definitions.Custom.Properties.GetProperty<UserSchemaAttribute>("groupContact").Should().BeNull();
        }
    }
}
