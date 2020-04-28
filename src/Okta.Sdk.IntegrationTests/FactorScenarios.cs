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

                var factors = await createdUser.ListFactors().ToArrayAsync();
                factors.Count().Should().Be(1);

                var securityQuestionFactor = await createdUser.ListFactors().OfType<ISecurityQuestionUserFactor>().FirstOrDefaultAsync();
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

                var factors = await createdUser.ListFactors().ToArrayAsync();
                factors.Count().Should().Be(1);

                var smsFactor = await createdUser.ListFactors().OfType<ISmsUserFactor>().FirstOrDefaultAsync();
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
                var factors = await createdUser.Factors.ToArrayAsync();
                factors.Count().Should().Be(0);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task GetFactor()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "GetFactor-SecurityQuestion",
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
                var createdUserFactor = await createdUser.AddFactorAsync(new AddSecurityQuestionFactorOptions
                {
                    Question = "disliked_food",
                    Answer = "mayonnaise",
                });

                var retrievedUserFactor = await createdUser.GetFactorAsync(createdUserFactor.Id);

                retrievedUserFactor.Should().NotBeNull();
                ((SecurityQuestionUserFactor)retrievedUserFactor).Profile.Question.Should().Be("disliked_food");
                ((SecurityQuestionUserFactor)retrievedUserFactor).Profile.QuestionText.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task DeleteFactor()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "DeleteFactor-SecurityQuestion",
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
                var createdUserFactor = await createdUser.AddFactorAsync(new AddSecurityQuestionFactorOptions
                {
                    Question = "disliked_food",
                    Answer = "mayonnaise",
                });

                var retrievedUserFactor = await createdUser.GetFactorAsync(createdUserFactor.Id);

                retrievedUserFactor.Should().NotBeNull();

                await createdUser.DeleteFactorAsync(retrievedUserFactor.Id);

                var factors = await createdUser.ListFactors().ToArrayAsync();
                factors.Count().Should().Be(0);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ResetFactors()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "ResetFactors-SecurityQuestion",
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
                var createdUserFactor = await createdUser.AddFactorAsync(new AddSecurityQuestionFactorOptions
                {
                    Question = "disliked_food",
                    Answer = "mayonnaise",
                });

                var retrievedUserFactor = await createdUser.GetFactorAsync(createdUserFactor.Id);

                retrievedUserFactor.Should().NotBeNull();

                await createdUser.ResetFactorsAsync();

                var factors = await createdUser.ListFactors().ToArrayAsync();
                factors.Count().Should().Be(0);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ListSupportedSecurityQuestions()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "Jill",
                LastName = "ListSupported-SecurityQuestion",
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
                var createdUserFactor = await createdUser.AddFactorAsync(new AddSecurityQuestionFactorOptions
                {
                    Question = "disliked_food",
                    Answer = "mayonnaise",
                });

                var retrievedQuestionsList = await createdUser.ListSupportedSecurityQuestions().ToArrayAsync();

                retrievedQuestionsList.Where(x => x.Question == "disliked_food")
                                    .FirstOrDefault()
                                    .Should()
                                    .NotBeNull();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }
    }
}
