using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class SchemaScenarios
    {
        private SchemaApi _schemaApi;

        public SchemaScenarios()
        {
            _schemaApi = new SchemaApi();
        }

        [Fact]
        public async Task GetUserSchema()
        {
            var userSchema = await _schemaApi.GetUserSchemaAsync("default");

            userSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
            userSchema.Name.Should().Be("user");
            userSchema.Title.Should().Be("User");
            userSchema.Id.Should().NotBeNullOrEmpty();
            userSchema.Type.Should().Be("object");
            userSchema.Definitions.Base.Id.Should().Be("#base");
            userSchema.Definitions.Base.Type.Should().Be("object");
            userSchema.Definitions.Base.Properties.Login.Title.Should().Be("Username");
            userSchema.Definitions.Base.Properties.Login.Type.Value.Should().Be("string");
            userSchema.Definitions.Base.Properties.Login.Required.Should().BeTrue();
            userSchema.Definitions.Base.Properties.Login.Mutability.Should().Be("READ_WRITE");
            userSchema.Definitions.Base.Properties.Login.Scope.Value.Should().Be("NONE");
            userSchema.Definitions.Base.Properties.Login.MinLength.Should().Be(5);
            userSchema.Definitions.Base.Properties.Login.MaxLength.Should().Be(100);
            userSchema.Definitions.Base.Properties.Login.Permissions.FirstOrDefault().Principal.Should().Be("SELF");
            userSchema.Definitions.Base.Properties.Login.Permissions.FirstOrDefault().Action.Should().Be("READ_ONLY");
            userSchema.Definitions.Base.Required.Should().Contain("login");
        }

        [Fact]
        public async Task UpdateUserProfileSchemaProperty()
        {
            var testAttributeName = $"{nameof(UpdateUserProfileSchemaProperty)}_test_{RandomString(6)}";
            var userSchema = await _schemaApi.GetUserSchemaAsync("default");
            var guid = Guid.NewGuid();

            // Add custom attribute
            var customAttributeDetails = new UserSchemaAttribute()
            {
                Title = testAttributeName,
                Type = "string",
                Description = guid.ToString(),
                MinLength = 1,
                MaxLength = 20,
                Permissions = new List<UserSchemaAttributePermission>
                {
                    new UserSchemaAttributePermission
                    {
                        Action = "READ_WRITE",
                        Principal = "SELF",
                    },
                },
            };

            var customAttribute = new Dictionary<string, UserSchemaAttribute>();
            customAttribute[testAttributeName] = customAttributeDetails;
            userSchema.Definitions.Custom.Properties = customAttribute;

            var updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", userSchema);

            var retrievedCustomAttribute = updatedUserSchema.Definitions.Custom.Properties[testAttributeName];
            retrievedCustomAttribute.Title.Should().Be(testAttributeName);
            retrievedCustomAttribute.Type.Value.Should().Be("string");
            retrievedCustomAttribute.Description.Should().Be(guid.ToString());
            retrievedCustomAttribute.Required.Should().BeFalse();
            retrievedCustomAttribute.MinLength.Should().Be(1);
            retrievedCustomAttribute.MaxLength.Should().Be(20);
            retrievedCustomAttribute.Permissions.FirstOrDefault().Principal.Should().Be("SELF");
            retrievedCustomAttribute.Permissions.FirstOrDefault().Action.Should().Be("READ_WRITE");

            // Wait for job to be finished
            Thread.Sleep(6000);

            // Remove custom attribute
            customAttribute[testAttributeName] = null;
            updatedUserSchema.Definitions.Custom.Properties = customAttribute;
            updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", updatedUserSchema);
            updatedUserSchema.Definitions.Custom.Properties.ContainsKey(testAttributeName).Should().BeFalse();
        }

        [Fact]
        public async Task AddArrayProperty()
        {
            var testAttributeName = $"{nameof(AddArrayProperty)}_test_{RandomString(6)}";
            var userSchema = await _schemaApi.GetUserSchemaAsync("default");
            var guid = Guid.NewGuid();

            // Add custom attribute
            var customAttributeDetails = new UserSchemaAttribute()
            {
                Title = testAttributeName,
                Type = UserSchemaAttributeType.Array,
                Description = guid.ToString(),
                Permissions = new List<UserSchemaAttributePermission>
                {
                    new UserSchemaAttributePermission
                    {
                        Action = "READ_WRITE",
                        Principal = "SELF",
                    },
                },
                Items = new UserSchemaAttributeItems { Type = "string" }
            };

            var customAttribute = new Dictionary<string, UserSchemaAttribute>();
            customAttribute[testAttributeName] = customAttributeDetails;
            userSchema.Definitions.Custom.Properties = customAttribute;

            var updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", userSchema);

            var retrievedCustomAttribute = updatedUserSchema.Definitions.Custom.Properties[testAttributeName];
            retrievedCustomAttribute.Title.Should().Be(testAttributeName);
            retrievedCustomAttribute.Type.Value.Should().Be("array");
            retrievedCustomAttribute.Description.Should().Be(guid.ToString());
            retrievedCustomAttribute.Required.Should().BeFalse();
            
            /*
            retrievedCustomAttribute.MinLength.Should().BeNull();
            retrievedCustomAttribute.MaxLength.Should().BeNull();
            */

            retrievedCustomAttribute.Permissions.FirstOrDefault().Principal.Should().Be("SELF");
            retrievedCustomAttribute.Permissions.FirstOrDefault().Action.Should().Be("READ_WRITE");

            // Wait for job to be finished
            Thread.Sleep(6000);

            // Remove custom attribute
            customAttribute[testAttributeName] = null;
            updatedUserSchema.Definitions.Custom.Properties = customAttribute;
            updatedUserSchema = await _schemaApi.UpdateUserProfileAsync("default", updatedUserSchema);
            updatedUserSchema.Definitions.Custom.Properties.ContainsKey(testAttributeName).Should().BeFalse();
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
