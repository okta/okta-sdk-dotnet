using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class ResourceSetScenarios
    {
        private ResourceSetApi _resourceSetApi;
        private RoleApi _roleApi;
        private GroupApi _groupApi;

        public ResourceSetScenarios()
        {
            _resourceSetApi = new ResourceSetApi();
            _roleApi = new RoleApi();
            _groupApi = new GroupApi();
        }

        [Fact]
        public async Task CreateResourceSet()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(CreateResourceSet)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);
                createdResourceSet.Label.Should().Be($"{nameof(CreateResourceSet)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task GetResourceSet()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(GetResourceSet)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);
                var retrievedResourceSet = await _resourceSetApi.GetResourceSetAsync(createdResourceSet.Id);

                retrievedResourceSet.Label.Should().Be($"{nameof(GetResourceSet)}{guid}");
                retrievedResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                retrievedResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task UpdateResourceSet()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(UpdateResourceSet)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(UpdateResourceSet)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                createdResourceSet.Label = $"upd-{createdResourceSet.Label}";
                createdResourceSet.Description = $"upd-{createdResourceSet.Description}";

                var updatedResourceSet = await _resourceSetApi.ReplaceResourceSetAsync(createdResourceSet.Id, createdResourceSet);

                updatedResourceSet.Label.Should().StartWith("upd-");
                updatedResourceSet.Description.Should().StartWith("upd-");
                updatedResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteResourceSet()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(DeleteResourceSet)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);
                createdResourceSet.Should().NotBeNull();
                
                await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                
                // Getting by ID should result in 404 Not found
                await Assert.ThrowsAsync<ApiException>(async () => await _resourceSetApi.GetResourceSetAsync(createdResourceSet.Id));
                createdResourceSet = null;
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task ListResourceSets()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(ListResourceSets)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);
                var resourceSets = await _resourceSetApi.ListResourceSetsAsync();

                resourceSets.Should().NotBeNull();
                resourceSets._ResourceSets.Any(x => x.Id == createdResourceSet.Id).Should().BeTrue();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task AddResources()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(AddResources)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(AddResources)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                var resourcesRequest = new ResourceSetResourcePatchRequest
                {
                    Additions = new List<string>
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups",
                    }
                };
                var updatedResourceSet = await _resourceSetApi.AddResourceSetResourceAsync(createdResourceSet.Id, resourcesRequest);
                var resources = await _resourceSetApi.ListResourceSetResourcesAsync(createdResourceSet.Id);
                resources.Resources.Should().HaveCount(2);
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteResource()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(DeleteResource)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups"
                }
            };

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                var resources = await _resourceSetApi.ListResourceSetResourcesAsync(createdResourceSet.Id);
                resources.Resources.Should().HaveCount(2);

                await _resourceSetApi.DeleteResourceSetResourceAsync(createdResourceSet.Id, resources.Resources.First().Id);
                resources = await _resourceSetApi.ListResourceSetResourcesAsync(createdResourceSet.Id);
                resources.Resources.Should().HaveCount(1);

            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }
            }
        }

        [Fact]
        public async Task CreateBinding()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;
            
            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(CreateBinding)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(CreateBinding)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;
            
            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(CreateBinding)} {guid}",
                    Description = $"dotnet-sdk: {nameof(CreateBinding)} {guid}"
                },
            };

            Group createdGroup = null;
            

            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(CreateBinding)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                newRole = await _roleApi.CreateRoleAsync(iamRole);
                createdGroup = await _groupApi.CreateGroupAsync(group);

                var binding = new ResourceSetBindingCreateRequest
                {
                    Members = new List<string>()
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups/{createdGroup.Id}"
                    },
                    Role = newRole.Id,
                };

                var createdBinding = await _resourceSetApi.CreateResourceSetBindingAsync(createdResourceSet.Id, binding);
                createdBinding.Links.Bindings.Href.Should().NotBeNullOrEmpty();

                var retrievedBinding = await _resourceSetApi.ListBindingsAsync(createdResourceSet.Id);
                retrievedBinding.Roles.Should().HaveCount(1);
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }

                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }

                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteBinding()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;

            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(DeleteBinding)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(DeleteBinding)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(DeleteBinding)} {guid}",
                    Description = $"dotnet-sdk: {nameof(DeleteBinding)} {guid}"
                },
            };

            Group createdGroup = null;


            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(DeleteBinding)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                newRole = await _roleApi.CreateRoleAsync(iamRole);
                createdGroup = await _groupApi.CreateGroupAsync(group);

                var binding = new ResourceSetBindingCreateRequest
                {
                    Members = new List<string>()
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups/{createdGroup.Id}"
                    },
                    Role = newRole.Id,
                };

                var createdBinding = await _resourceSetApi.CreateResourceSetBindingAsync(createdResourceSet.Id, binding);
                createdBinding.Links.Bindings.Href.Should().NotBeNullOrEmpty();

                var retrievedBinding = await _resourceSetApi.ListBindingsAsync(createdResourceSet.Id);
                retrievedBinding.Roles.Should().HaveCount(1);

                await _resourceSetApi.DeleteBindingAsync(createdResourceSet.Id, newRole.Id);
                retrievedBinding = await _resourceSetApi.ListBindingsAsync(createdResourceSet.Id);
                retrievedBinding.Roles.Should().BeNullOrEmpty();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }

                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }

                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }

        [Fact]
        public async Task AddMemberToBinding()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;

            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(AddMemberToBinding)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(AddMemberToBinding)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(AddMemberToBinding)} {guid}",
                    Description = $"dotnet-sdk: {nameof(AddMemberToBinding)} {guid}"
                },
            };

            Group createdGroup = null;

            var group2 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: 2 {nameof(AddMemberToBinding)} {guid}",
                    Description = $"dotnet-sdk: 2 {nameof(AddMemberToBinding)} {guid}"
                },
            };

            Group createdGroup2 = null;


            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(AddMemberToBinding)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                newRole = await _roleApi.CreateRoleAsync(iamRole);
                createdGroup = await _groupApi.CreateGroupAsync(group);

                var binding = new ResourceSetBindingCreateRequest
                {
                    Members = new List<string>()
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups/{createdGroup.Id}"
                    },
                    Role = newRole.Id,
                };

                var createdBinding = await _resourceSetApi.CreateResourceSetBindingAsync(createdResourceSet.Id, binding);
                createdBinding.Links.Bindings.Href.Should().NotBeNullOrEmpty();

                var retrievedBinding = await _resourceSetApi.ListBindingsAsync(createdResourceSet.Id);
                retrievedBinding.Roles.Should().HaveCount(1);

                var bindingMembers = await _resourceSetApi.ListMembersOfBindingAsync(createdResourceSet.Id, newRole.Id);
                bindingMembers.Members.Should().HaveCount(1);

                createdGroup2 = await _groupApi.CreateGroupAsync(group2);

                var newBindingRequest = new ResourceSetBindingAddMembersRequest
                {
                    Additions = new List<string>()
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups/{createdGroup2.Id}"
                    }
                };

                _ =  await _resourceSetApi.AddMembersToBindingAsync(createdResourceSet.Id, newRole.Id, newBindingRequest);
                retrievedBinding = await _resourceSetApi.ListBindingsAsync(createdResourceSet.Id);
                retrievedBinding.Roles.Should().HaveCount(1);

                bindingMembers = await _resourceSetApi.ListMembersOfBindingAsync(createdResourceSet.Id, newRole.Id);
                bindingMembers.Members.Should().HaveCount(2);

            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }

                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }

                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }

                if (createdGroup2 != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup2.Id);
                }
            }
        }

        [Fact]
        public async Task GetMemberFromBinding()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;

            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(GetMemberFromBinding)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(GetMemberFromBinding)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(GetMemberFromBinding)} {guid}",
                    Description = $"dotnet-sdk: {nameof(GetMemberFromBinding)} {guid}"
                },
            };

            Group createdGroup = null;


            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(GetMemberFromBinding)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                newRole = await _roleApi.CreateRoleAsync(iamRole);
                createdGroup = await _groupApi.CreateGroupAsync(group);

                var binding = new ResourceSetBindingCreateRequest
                {
                    Members = new List<string>()
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups/{createdGroup.Id}"
                    },
                    Role = newRole.Id,
                };

                var createdBinding = await _resourceSetApi.CreateResourceSetBindingAsync(createdResourceSet.Id, binding);
                createdBinding.Links.Bindings.Href.Should().NotBeNullOrEmpty();

                var bindingMembers = await _resourceSetApi.ListMembersOfBindingAsync(createdResourceSet.Id, newRole.Id);

                var bindingMember = await _resourceSetApi.GetMemberOfBindingAsync(createdResourceSet.Id, newRole.Id, bindingMembers.Members.First().Id);
                bindingMember.Should().NotBeNull();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }

                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }

                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteMemberFromBinding()
        {
            var guid = Guid.NewGuid();
            ResourceSet createdResourceSet = null;

            var resourceSet = new CreateResourceSetRequest
            {
                Label = $"{nameof(DeleteMemberFromBinding)}{guid}",
                Description = "People in the IT department of San Francisco",
                Resources = new List<string>()
                {
                    $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/users",
                }
            };

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(DeleteMemberFromBinding)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(DeleteMemberFromBinding)} {guid}",
                    Description = $"dotnet-sdk: {nameof(DeleteMemberFromBinding)} {guid}"
                },
            };

            Group createdGroup = null;


            try
            {
                createdResourceSet = await _resourceSetApi.CreateResourceSetAsync(resourceSet);

                createdResourceSet.Label.Should().Be($"{nameof(DeleteMemberFromBinding)}{guid}");
                createdResourceSet.Description.Should().Be("People in the IT department of San Francisco");
                createdResourceSet.Links.Resources.Href.Should().NotBeNullOrEmpty();

                newRole = await _roleApi.CreateRoleAsync(iamRole);
                createdGroup = await _groupApi.CreateGroupAsync(group);

                var binding = new ResourceSetBindingCreateRequest
                {
                    Members = new List<string>()
                    {
                        $"{ClientUtils.EnsureTrailingSlash(Environment.GetEnvironmentVariable("okta:OktaDomain"))}api/v1/groups/{createdGroup.Id}"
                    },
                    Role = newRole.Id,
                };

                var createdBinding = await _resourceSetApi.CreateResourceSetBindingAsync(createdResourceSet.Id, binding);
                createdBinding.Links.Bindings.Href.Should().NotBeNullOrEmpty();

                var bindingMembers = await _resourceSetApi.ListMembersOfBindingAsync(createdResourceSet.Id, newRole.Id);
                bindingMembers.Members.Should().HaveCount(1);

                await _resourceSetApi.UnassignMemberFromBindingAsync(createdResourceSet.Id, newRole.Id,
                    bindingMembers.Members.First().Id);
                
                bindingMembers = await _resourceSetApi.ListMembersOfBindingAsync(createdResourceSet.Id, newRole.Id);
                bindingMembers.Members.Should().BeNullOrEmpty();
            }
            finally
            {
                if (createdResourceSet != null)
                {
                    await _resourceSetApi.DeleteResourceSetAsync(createdResourceSet.Id);
                }

                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }

                if (createdGroup != null)
                {
                    await _groupApi.DeleteGroupAsync(createdGroup.Id);
                }
            }
        }
    }
}
