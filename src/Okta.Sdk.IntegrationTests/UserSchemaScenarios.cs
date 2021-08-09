// <copyright file="UserSchemaScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class UserSchemaScenarios
    {
        [Fact]
        public async Task GetUserSchema()
        {
            var testClient = TestClient.Create();

            var userSchema = await testClient.UserSchemas.GetUserSchemaAsync("default");

            userSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
            userSchema.Name.Should().Be("user");
            userSchema.Title.Should().Be("User");
            userSchema.Id.Should().NotBeNullOrEmpty();
            userSchema.Type.Should().Be("object");
            userSchema.Definitions.Base.Id.Should().Be("#base");
            userSchema.Definitions.Base.Type.Should().Be("object");
            userSchema.Definitions.Base.Properties.Login.Title.Should().Be("Username");
            userSchema.Definitions.Base.Properties.Login.Type.ToString().Should().Be("string");
            userSchema.Definitions.Base.Properties.Login.Required.Should().BeTrue();
            userSchema.Definitions.Base.Properties.Login.Mutability.Should().Be("READ_WRITE");
            userSchema.Definitions.Base.Properties.Login.Scope.Should().Be("NONE");
            userSchema.Definitions.Base.Properties.Login.MinLength.Should().Be(5);
            userSchema.Definitions.Base.Properties.Login.MaxLength.Should().Be(100);
            userSchema.Definitions.Base.Properties.Login.Permissions.FirstOrDefault().Principal.Should().Be("SELF");
            userSchema.Definitions.Base.Properties.Login.Permissions.FirstOrDefault().Action.Should().Be("READ_ONLY");
            userSchema.Definitions.Base.Required.Should().Contain("login");
        }

        [Fact]
        public async Task UpdateUserProfileSchemaProperty()
        {
            var testClient = TestClient.Create();

            var userSchema = await testClient.UserSchemas.GetUserSchemaAsync("default");
            var guid = Guid.NewGuid();

            // Add custom attribute
            var customAttributeDetails = new UserSchemaAttribute()
            {
                Title = "Twitter username",
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
            customAttribute["twitterUserName"] = customAttributeDetails;
            userSchema.Definitions.Custom.Properties = customAttribute;

            var updatedUserSchema = await testClient.UserSchemas.UpdateUserProfileAsync(userSchema, "default");

            var retrievedCustomAttribute = updatedUserSchema.Definitions.Custom.Properties.GetProperty<UserSchemaAttribute>("twitterUserName");
            retrievedCustomAttribute.Title.Should().Be("Twitter username");
            retrievedCustomAttribute.Type.ToString().Should().Be("string");
            retrievedCustomAttribute.Description.Should().Be(guid.ToString());
            retrievedCustomAttribute.Required.Should().BeNull();
            retrievedCustomAttribute.MinLength.Should().Be(1);
            retrievedCustomAttribute.MaxLength.Should().Be(20);
            retrievedCustomAttribute.Permissions.FirstOrDefault().Principal.Should().Be("SELF");
            retrievedCustomAttribute.Permissions.FirstOrDefault().Action.Should().Be("READ_WRITE");

            // Remove custom attribute
            customAttribute["twitterUserName"] = null;
            updatedUserSchema.Definitions.Custom.Properties = customAttribute;
            updatedUserSchema = await testClient.UserSchemas.UpdateUserProfileAsync(updatedUserSchema, "default");
            updatedUserSchema.Definitions.Custom.Properties.GetProperty<UserSchemaAttribute>("twitterUserName").Should().BeNull();
        }
    }
}
