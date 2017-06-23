// <copyright file="ListUsersShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(RecordedScenarioCollection))]
    public class ListUsersShould : RecordedScenario, IDisposable
    {
        private readonly User _user;

        public ListUsersShould()
            : base(scenarioName: "list-users")
        {
            var client = GetClient();

            var userProfile = new UserProfile
            {
                FirstName = "John",
                LastName = "List-Users",
                Email = "john-list-users@example.com",
                Login = "john-list-users@example.com",
            };
            userProfile["nickName"] = "johny-list-users";

            _user = client.Users.CreateUserAsync(new UserWithPasswordCreationOptions
            {
                Profile = userProfile,
                Password = "Abcd1234",
            }).Result;
        }

        public void Dispose()
        {
            _user.DeactivateAsync().Wait();
            _user.DeactivateOrDeleteAsync().Wait();
        }

        [Fact]
        public async Task SearchUsers()
        {
            var foundUsers = await GetClient()
                .Users
                .ListUsers(search: $"profile.nickName eq \"{_user.Profile.GetProperty<string>("nickName")}\"")
                .ToArray();

            foundUsers.Length.Should().Be(1);
            foundUsers.Single().Id.Should().Be(_user.Id);
        }
    }
}
