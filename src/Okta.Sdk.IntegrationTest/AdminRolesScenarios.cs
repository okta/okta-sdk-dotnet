using Okta.Sdk.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Model;
using Xunit;
using Okta.Sdk.Client;

namespace Okta.Sdk.IntegrationTest
{
    public class AdminRolesScenarios
    {
        private RoleApi _roleApi;
        
        public AdminRolesScenarios()
        {
            _roleApi = new RoleApi();
        }

        [Fact]
        public async Task CreateIamRole()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(CreateIamRole)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;
            
            try
            {
               newRole = await _roleApi.CreateRoleAsync(iamRole);

               newRole.Should().NotBeNull();
               newRole.Description.Should().Be("Create Users");

               newRole.Links.Permissions.Should().NotBeNull();

               var permissions = await _roleApi.ListRolePermissionsAsync(newRole.Id);
               permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
               permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();
            }
            finally
            {
                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }
            }
        }

        [Fact]
        public async Task GetIamRole()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(GetIamRole)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            try
            {
                newRole = await _roleApi.CreateRoleAsync(iamRole);

                var createdRole = await _roleApi.GetRoleAsync(newRole.Id);

                createdRole.Should().NotBeNull();
                createdRole.Description.Should().Be("Create Users");

                createdRole.Links.Permissions.Should().NotBeNull();

                var permissions = await _roleApi.ListRolePermissionsAsync(createdRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
                permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();
            }
            finally
            {
                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }
            }
        }


        [Fact]
        public async Task ListRoles()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(ListRoles)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            try
            {
                newRole = await _roleApi.CreateRoleAsync(iamRole);

                var roles = await _roleApi.ListRolesAsync();

                var createdRole = roles.Roles.FirstOrDefault(x => x.Id == newRole.Id);

                createdRole.Should().NotBeNull();
                createdRole.Description.Should().Be("Create Users");

                createdRole.Links.Permissions.Should().NotBeNull();

                var permissions = await _roleApi.ListRolePermissionsAsync(createdRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
                permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();
            }
            finally
            {
                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }
            }
        }

        [Fact]
        public async Task UpdateIamRole()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(UpdateIamRole)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            try
            {
                newRole = await _roleApi.CreateRoleAsync(iamRole);

                newRole.Should().NotBeNull();
                newRole.Description.Should().Be("Create Users");

                newRole.Links.Permissions.Should().NotBeNull();
                var permissions = await _roleApi.ListRolePermissionsAsync(newRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
                permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();

                var updateRole = new UpdateIamRoleRequest
                {
                    Label = newRole.Label + " updated",
                    Description = newRole.Description,
                };

                var updatedRole = await _roleApi.ReplaceRoleAsync(newRole.Id, updateRole);

                updatedRole.Label.Should().Be($"dotnet-sdk: {nameof(UpdateIamRole)} {guid} updated");

                updateRole.Description.Should().Be("Create Users");

                updatedRole.Links.Permissions.Should().NotBeNull();
                permissions = await _roleApi.ListRolePermissionsAsync(updatedRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
                permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();
            }
            finally
            {
                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }
            }
        }

        [Fact]
        public async Task AddPermissions()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(AddPermissions)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            try
            {
                newRole = await _roleApi.CreateRoleAsync(iamRole);
                
                newRole.Should().NotBeNull();
                newRole.Description.Should().Be("Create Users");

                newRole.Links.Permissions.Should().NotBeNull();

                var permissions = await _roleApi.ListRolePermissionsAsync(newRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
                permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();

                await _roleApi.CreateRolePermissionAsync(newRole.Id, "okta.users.manage");
                
                permissions = await _roleApi.ListRolePermissionsAsync(newRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.manage").Should().BeTrue();
            }
            finally
            {
                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }
            }
        }

        [Fact]
        public async Task DeletePermissions()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(AddPermissions)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            IamRole newRole = null;

            try
            {
                newRole = await _roleApi.CreateRoleAsync(iamRole);

                newRole.Should().NotBeNull();
                newRole.Description.Should().Be("Create Users");

                newRole.Links.Permissions.Should().NotBeNull();

                var permissions = await _roleApi.ListRolePermissionsAsync(newRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeTrue();
                permissions._Permissions.Any(x => x.Label == "okta.users.read").Should().BeTrue();

                await _roleApi.DeleteRolePermissionAsync(newRole.Id, "okta.users.create");

                permissions = await _roleApi.ListRolePermissionsAsync(newRole.Id);
                permissions._Permissions.Any(x => x.Label == "okta.users.create").Should().BeFalse();
            }
            finally
            {
                if (newRole != null)
                {
                    await _roleApi.DeleteRoleAsync(newRole.Id);
                }
            }
        }

        [Fact]
        public async Task DeleteRole()
        {
            var guid = Guid.NewGuid();

            var iamRole = new CreateIamRoleRequest
            {
                Label = $"dotnet-sdk: {nameof(DeleteRole)} {guid}",
                Description = "Create Users",
                Permissions = new List<RolePermissionType>()
                {
                    new RolePermissionType("okta.users.create"),
                    new RolePermissionType("okta.users.read"),
                },
            };

            
            var newRole = await _roleApi.CreateRoleAsync(iamRole);

            newRole.Should().NotBeNull();

            await _roleApi.DeleteRoleAsync(newRole.Id);

            // Getting by ID should result in 404 Not found
            await Assert.ThrowsAsync<ApiException>(async () => await _roleApi.GetRoleAsync(newRole.Id));
        }
    }
}
