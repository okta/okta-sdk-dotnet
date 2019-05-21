// <copyright file="FactorScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(FactorScenarios))]
    public class FactorScenarios
    {
        [Fact]
        public async Task EnrollSecurityQuestionFactor()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "Factor-SecurityQuestion",
                Email = $"jill-factor-securityquestion-dotnet-sdk-{guid}@example.com",
                Login = $"jill-factor-securityquestion-dotnet-sdk-{guid}@example.com",
            };
            profile["nickName"] = "jill-factor-securityquestion";

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            try
            {
                await createdUser.AddFactorAsync(new AddSecurityQuestionFactorOptions
                {
                    Question = "disliked_food",
                    Answer = "mayonnaise",
                });

                var factors = await createdUser.ListFactors().ToArray();
                factors.Count().Should().Be(1);

                var securityQuestionFactor = await createdUser.ListFactors().OfType<ISecurityQuestionFactor>().FirstOrDefault();
                securityQuestionFactor.Should().NotBeNull();
                securityQuestionFactor.Profile.Question.Should().Be("disliked_food");
                securityQuestionFactor.Profile.QuestionText.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task EnrollSmsFactor()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "Factor-Sms",
                Email = $"jill-factor-sms-dotnet-sdk-{guid}@example.com",
                Login = $"jill-factor-sms-dotnet-sdk-{guid}@example.com",
            };
            profile["nickName"] = "jill-factor-sms";

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            try
            {
                await createdUser.AddFactorAsync(new AddSmsFactorOptions()
                {
                    PhoneNumber = "+16284001133‬",
                });

                var factors = await createdUser.ListFactors().ToArray();
                factors.Count().Should().Be(1);

                var smsFactor = await createdUser.ListFactors().OfType<ISmsFactor>().FirstOrDefault();
                smsFactor.Should().NotBeNull();
                smsFactor.FactorType.Should().Be(FactorType.Sms);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ListFactorsForNewUser()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jack",
                LastName = "List-Factors",
                Email = $"jack-list-factors-dotnet-sdk-{guid}@example.com",
                Login = $"jack-list-factors-dotnet-sdk-{guid}@example.com",
            };
            profile["nickName"] = "jack-list-users";

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            try
            {
                var factors = await createdUser.Factors.ToArray();
                factors.Count().Should().Be(0);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }
    }
}
