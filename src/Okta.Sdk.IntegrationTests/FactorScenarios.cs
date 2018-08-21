// <copyright file="FactorScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
        public async Task CreateSecurityQuestionFactor()
        {
            var client = TestClient.Create();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "Factor-SecurityQuestion",
                Email = "jill-factor-securityquestion@example.com",
                Login = "jill-factor-securityquestion@example.com",
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
        public async Task ListFactorsForNewUser()
        {
            var client = TestClient.Create();

            var profile = new UserProfile
            {
                FirstName = "Jack",
                LastName = "List-Factors",
                Email = "jack-list-factors@example.com",
                Login = "jack-list-factors@example.com",
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
