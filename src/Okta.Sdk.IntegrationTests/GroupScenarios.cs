// <copyright file="GroupScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

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

        [Fact(Skip = "TODO")]
        public async Task ListGroups()
        {
            throw new NotImplementedException();
        }

        [Fact(Skip = "TODO")]
        public async Task SearchGroups()
        {
            throw new NotImplementedException();
        }

        [Fact(Skip = "TODO")]
        public async Task UpdateGroup()
        {
            throw new NotImplementedException();
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
