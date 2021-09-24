// <copyright file="ProfileMappingsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ProfileMappingsClientShould
    {
        [Fact]
        public async Task ListProfileMappings()
        {
            string rawResponse = @"[
    {
        ""id"": ""prm1k47ghydIQOTBW0g4"",
        ""source"": {
                ""id"": ""sourceId"",
            ""name"": ""user"",
            ""type"": ""user"",
            ""_links"": {
                ""self"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/meta/types/user/otysbePhQ3yqt4cVv0g3""
                    },
                ""schema"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/meta/schemas/user/oscsbePhQ3yqt4cVv0g3""
                    }
                }
        },
        ""target"": {
                ""id"": ""targetId"",
            ""name"": ""zendesk"",
            ""type"": ""appuser"",
            ""_links"": {
                    ""self"": {
                        ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oa1xz9cb7yt5SsZV0g4""
                    },
                ""schema"": {
                        ""href"": ""https://${yourOktaDomain}/api/v1/meta/schemas/apps/0oa1xz9cb7yt5SsZV0g4/default""
                }
                }
            },
        ""_links"": {
                ""self"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/mappings/prm1k47ghydIQOTBW0g4""
                }
            }
        },
    {
        ""id"": ""prm1k48weFSOnEUnw0g4"",
        ""source"": {
            ""id"": ""sourceId"",
            ""name"": ""user"",
            ""type"": ""user"",
            ""_links"": {
                ""self"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/meta/types/user/otysbePhQ3yqt4cVv0g3""
                },
                ""schema"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/meta/schemas/user/oscsbePhQ3yqt4cVv0g3""
                }
            }
        },
        ""target"": {
                ""id"": ""targetId"",
            ""name"": ""sevenoffice"",
            ""type"": ""appuser"",
            ""_links"": {
                ""self"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oa1ycesCAeQrbO3s0g4""
                },
                ""schema"": {
                    ""href"": ""https://${yourOktaDomain}/api/v1/meta/schemas/apps/0oa1ycesCAeQrbO3s0g4/default""
                }
            }
        },
        ""_links"": {
            ""self"": {
                ""href"": ""https://${yourOktaDomain}/api/v1/mappings/prm1k48weFSOnEUnw0g4""
            }
        }
    }
]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var profileMappingsClient = client.ProfileMappings;
            var mappings = profileMappingsClient.ListProfileMappings(sourceId: "sourceId", targetId: "targetId");
            var mapping = await mappings.FirstAsync();
            mapping.Source.Id.Should().Be("sourceId");
            mapping.Source.Name.Should().Be("user");
            mapping.Source.Type.Should().Be("user");
            mapping.Target.Id.Should().Be("targetId");
            mapping.Target.Name.Should().Be("zendesk");
            mapping.Target.Type.Should().Be("appuser");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/mappings?limit=-1&sourceId=sourceId&targetId=targetId");
        }

        [Fact]
        public async Task GetProfileMapping()
        {
            string rawResponse = @"{
    ""id"": ""mappingId"",
    ""source"": {
        ""id"": ""sourceId"",
        ""name"": ""user"",
        ""type"": ""user"",
        ""_links"": {
            ""self"": {
                ""href"": ""https://${yourOktaDomain}/api/v1/meta/types/user/sourceId""
            },
            ""schema"": {
                ""href"": ""https://${yourOktaDomain}/api/v1/meta/schemas/user/sourceId""
            }
        }
    },
    ""target"": {
        ""id"": ""targetId"",
        ""name"": ""okta_org2org"",
        ""type"": ""appuser"",
        ""_links"": {
            ""self"": {
                ""href"": ""https://${yourOktaDomain}/api/v1/apps/targetId""
            },
            ""schema"": {
                ""href"": ""https://${yourOktaDomain}/api/v1/meta/schemas/apps/targetId/default""
            }
        }
    },
    ""properties"": {
        ""firstName"": {
            ""expression"": ""user.firstName"",
            ""pushStatus"": ""PUSH""
        },
        ""lastName"": {
            ""expression"": ""user.lastName"",
            ""pushStatus"": ""PUSH""
        }
    },
    ""_links"": {
        ""self"": {
            ""href"": ""https://${yourOktaDomain}/api/v1/mappings/${mappingId}""
        }
    }
}";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var profileMappingsClient = client.ProfileMappings;

            var mapping = await profileMappingsClient.GetProfileMappingAsync("mappingId");
            mapping.Id.Should().Be("mappingId");
            mapping.Source.Id.Should().Be("sourceId");
            mapping.Source.Name.Should().Be("user");
            mapping.Source.Type.Should().Be("user");

            mapping.Target.Id.Should().Be("targetId");
            mapping.Target.Name.Should().Be("okta_org2org");
            mapping.Target.Type.Should().Be("appuser");

            mapping.Properties["firstName"].Should().NotBeNull();
            mapping.Properties["lastName"].Should().NotBeNull();
            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/mappings/mappingId");
        }

        [Fact]
        public async Task UpdateProfileMapping()
        {
            var expectedBody = @"{""properties"":{""fullName"":{""expression"":""user.firstName + user.lastName"",""pushStatus"":""PUSH""},""nickName"":{""expression"":""user.nickName"",""pushStatus"":""PUSH""}}}";
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            var profileMappingsClient = client.ProfileMappings;

            var data = new Dictionary<string, object>
            {
                ["properties"] = new Dictionary<string, object>
                {
                    ["fullName"] = new Dictionary<string, object>
                    {
                        ["expression"] = "user.firstName + user.lastName",
                        ["pushStatus"] = "PUSH",
                    },
                    ["nickName"] = new Dictionary<string, object>
                    {
                        ["expression"] = "user.nickName",
                        ["pushStatus"] = "PUSH",
                    },
                },
            };

            var factory = new ResourceFactory(null, null);
            var mapping = factory.CreateNew<ProfileMapping>(data);

            await profileMappingsClient.UpdateProfileMappingAsync(mapping, "mappingId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/mappings/mappingId");
            mockRequestExecutor.ReceivedBody.Should().Be(expectedBody);
        }
    }
}
