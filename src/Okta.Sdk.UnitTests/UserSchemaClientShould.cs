// <copyright file="UserSchemaClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UserSchemaClientShould
    {
        [Fact]
        public async Task GetApplicationUserSchema()
        {
            var rawResponse = @"
                                {
                                  ""id"": ""https://${yourOktaDomain}/meta/schemas/apps/0oa25gejWwdXNnFH90g4/default"",
                                  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
                                  ""name"": ""Example App"",
                                  ""title"": ""Example App User"",
                                  ""lastUpdated"": ""2017-07-18T23:18:43.000Z"",
                                  ""created"": ""2017-07-18T22:35:30.000Z"",
                                  ""definitions"": {
                                    ""base"": {
                                      ""id"": ""#base"",
                                      ""type"": ""object"",
                                      ""properties"": {
                                        ""login"": {
                                          ""title"": ""Username"",
                                          ""type"": ""string"",
                                          ""required"": true,
                                          ""scope"": ""NONE"",
                                          ""minLength"": 5,
                                          ""maxLength"": 100
                                        }
                                      },
                                      ""required"": [
                                        ""login""
                                      ]
                                    },
                                    ""custom"": {
                                      ""id"": ""#custom"",
                                      ""type"": ""object"",
                                      ""properties"": {
                                      },
                                      ""required"": []
                                    }
                                  },
                                  ""type"": ""object"",
                                  ""properties"": {
                                    ""profile"": {
                                      ""allOf"": [
                                        {
                                          ""$ref"": ""#/definitions/base""
                                        },
                                        {
                                          ""$ref"": ""#/definitions/custom""
                                        }
                                      ]
                                    }
                                  }
                                }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var userSchema = await client.UserSchemas.GetApplicationUserSchemaAsync("foo");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/meta/schemas/apps/foo/default");

            userSchema.Schema.Should().Be("http://json-schema.org/draft-04/schema#");
            userSchema.Name.Should().Be("Example App");
            userSchema.Title.Should().Be("Example App User");
            userSchema.Id.Should().NotBeNullOrEmpty();
            userSchema.Type.Should().Be("object");
            userSchema.Definitions.Base.Id.Should().Be("#base");
            userSchema.Definitions.Base.Type.Should().Be("object");
            userSchema.Definitions.Base.Properties.Login.Title.Should().Be("Username");
            userSchema.Definitions.Base.Properties.Login.Type.Should().Be("string");
            userSchema.Definitions.Base.Properties.Login.Required.Should().BeTrue();
            userSchema.Definitions.Base.Properties.Login.Scope.Should().Be("NONE");
            userSchema.Definitions.Base.Properties.Login.MinLength.Should().Be(5);
            userSchema.Definitions.Base.Properties.Login.MaxLength.Should().Be(100);
            userSchema.Definitions.Base.Required.Should().Contain("login");
        }

        [Fact]
        public async Task UpdateApplicationUserSchema()
        {
            var rawResponse = @"
                                {
                                  ""id"": ""https://${yourOktaDomain}/meta/schemas/apps/0oa25gejWwdXNnFH90g4/default"",
                                  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
                                  ""name"": ""Example App"",
                                  ""title"": ""Example App User"",
                                  ""lastUpdated"": ""2017-07-18T23:18:43.000Z"",
                                  ""created"": ""2017-07-18T22:35:30.000Z"",
                                  ""definitions"": {
                                    ""base"": {
                                      ""id"": ""#base"",
                                      ""type"": ""object"",
                                      ""properties"": {
                                        ""userName"": {
                                          ""title"": ""Username"",
                                          ""type"": ""string"",
                                          ""required"": true,
                                          ""scope"": ""NONE"",
                                          ""maxLength"": 100
                                        }
                                      },
                                      ""required"": [
                                        ""userName""
                                      ]
                                    },
                                    ""custom"": {
                                      ""id"": ""#custom"",
                                      ""type"": ""object"",
                                      ""properties"": {
                                        ""twitterUserName"": {
                                          ""title"": ""Twitter username"",
                                          ""description"": ""User's username for twitter.com"",
                                          ""type"": ""string"",
                                          ""scope"": ""NONE"",
                                          ""minLength"": 1,
                                          ""maxLength"": 20
                                        }
                                      },
                                      ""required"": []
                                    }
                                  },
                                  ""type"": ""object"",
                                  ""properties"": {
                                    ""profile"": {
                                      ""allOf"": [
                                        {
                                          ""$ref"": ""#/definitions/base""
                                        },
                                        {
                                          ""$ref"": ""#/definitions/custom""
                                        }
                                      ]
                                    }
                                  }
                                }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);


            // Add custom attribute
            var customAttributeDetails = new UserSchemaAttribute()
            {
                Title = "Twitter username",
                Type = "string",
                Description = "User's username for twitter.com",
                MinLength = 1,
                MaxLength = 20,
            };

            var customAttribute = new Resource();
            customAttribute["twitterUserName"] = customAttributeDetails;
            var userSchema = new UserSchema();
            userSchema.Definitions = new UserSchemaDefinitions
            {
                Custom = new PublicSchema
                {
                    Properties = customAttribute,
                },
            };

            var updatedUserSchema = await client.UserSchemas.UpdateApplicationUserProfileAsync(userSchema, "foo");

            var retrievedCustomAttribute = updatedUserSchema.Definitions.Custom.Properties.GetProperty<UserSchemaAttribute>("twitterUserName");
            retrievedCustomAttribute.Title.Should().Be("Twitter username");
            retrievedCustomAttribute.Type.Should().Be("string");
            retrievedCustomAttribute.Description.Should().Be("User's username for twitter.com");
            retrievedCustomAttribute.Required.Should().BeNull();
            retrievedCustomAttribute.MinLength.Should().Be(1);
            retrievedCustomAttribute.MaxLength.Should().Be(20);
            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/meta/schemas/apps/foo/default");
        }
    }
}
