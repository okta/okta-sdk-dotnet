// <copyright file="GroupScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(ScenariosCollection))]
    public class GroupScenarios : ScenarioGroup
    {
        [Fact]
        public async Task GetGroup()
        {
            var client = GetClient("group-get");

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = "Get Test Group",
            });

            try
            {
                var retrievedById = await client.Groups.GetGroupAsync(createdGroup.Id);
                retrievedById.Id.Should().Be(createdGroup.Id);
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task ListGroups()
        {
            var client = GetClient("group-list");

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = "List Test Group",
            });

            try
            {
                var groupList = await client.Groups.ListGroups().ToArray();
                groupList.SingleOrDefault(g => g.Id == createdGroup.Id).Should().NotBeNull();
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task SearchGroups()
        {
            var client = GetClient("group-search");

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = "Search Test Group",
            });

            try
            {
                var groupList = await client.Groups
                    .ListGroups(createdGroup.Profile.GetProperty<string>("name"))
                    .ToArray();
                groupList.SingleOrDefault(g => g.Id == createdGroup.Id).Should().NotBeNull();
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task UpdateGroup()
        {
            var client = GetClient("group-update");

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = "Update Test Group",
            });

            await Task.Delay(1000);
            createdGroup.Profile.Description = "This group has been updated";

            try
            {
                var updatedGroup = await createdGroup.UpdateAsync();
                updatedGroup.LastUpdated.Value.Should().BeAfter(updatedGroup.Created.Value);
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact(Skip = "TODO")]
        public async Task GroupUserOperations()
        {
            throw new NotImplementedException();
        }

        [Fact(Skip = "TODO")]
        public async Task GroupRuleOperations()
        {
            throw new NotImplementedException();
        }
    }
}
