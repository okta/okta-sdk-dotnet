// <copyright file="AuthenticatorScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class AuthenticatorScenarios
    {
        [Fact]
        public async Task ListAuthenticatorsAsync()
        {
            var client = TestClient.Create();

            var authenticators = await client.Authenticators.ListAuthenticators().ToListAsync();

            authenticators.Should().NotBeNullOrEmpty();
            authenticators.Select(x => x.Type.ToString()).Should().BeSubsetOf(new List<string> { "app", "password", "security_question", "phone", "email", "security_key" });
        }

        [Fact]
        public async Task GetAuthenticatorByIdAsync()
        {
            var client = TestClient.Create();

            var authenticators = await client.Authenticators.ListAuthenticators().ToListAsync();
            // Password should be enabled
            var passwordAuthenticator = authenticators.FirstOrDefault(x => x.Type == AuthenticatorType.Password);

            var retrievedAuthenticator = await client.Authenticators.GetAuthenticatorAsync(passwordAuthenticator.Id);

            retrievedAuthenticator.Key.Should().Be(passwordAuthenticator.Key);
            retrievedAuthenticator.Name.Should().Be(passwordAuthenticator.Name);
            retrievedAuthenticator.Status.Should().Be(passwordAuthenticator.Status);
            retrievedAuthenticator.Created.Should().Be(passwordAuthenticator.Created);
            retrievedAuthenticator.Settings.Should().Be(passwordAuthenticator.Settings);
        }

        [Fact]
        public async Task UpdateAuthenticatorsAsync()
        {
            var client = TestClient.Create();

            var authenticator = await client.Authenticators.ListAuthenticators().FirstOrDefaultAsync();

            var originalName = authenticator.Name;

            authenticator.Name = originalName + "-updated";
            try
            {
                var updatedAuthenticator = await client.Authenticators.UpdateAuthenticatorAsync(authenticator, authenticator.Id);
                updatedAuthenticator.Name.Should().Be(authenticator.Name);
            }
            finally
            {
                authenticator.Name = originalName;
                await client.Authenticators.UpdateAuthenticatorAsync(authenticator, authenticator.Id);
            }
        }
    }
}
