using FluentAssertions;
using Microsoft.Extensions.Options;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class FactorScenarios
    {
        private UserApi _userApi;
        private UserFactorApi _userFactorApi;
        public FactorScenarios()
        {
            _userApi = new UserApi();
            _userFactorApi = new UserFactorApi();
        }

        [Fact]
        public async Task EnrollSecurityQuestionFactor()
        {
            var guid = Guid.NewGuid();
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {

                Profile = new UserProfile
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com",
                    PrimaryPhone = "123-321-4444",
                    MobilePhone = "321-123-5555",
                    Locale = "en_US",
                    SecondEmail = $"{Guid.NewGuid()}@second.com",
                    Timezone = "Japan",
                }
            };

            try
            {
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new SecurityQuestionUserFactor
                {
                    FactorType = FactorType.Question,
                    Profile = new SecurityQuestionUserFactorProfile
                    {
                        Question = "disliked_food",
                        Answer = "mayonnaise"
                    },
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(FactorType.Question);
                ((SecurityQuestionUserFactor)createdUserFactor).Profile.Question.Should().Be("disliked_food");
                ((SecurityQuestionUserFactor)createdUserFactor).Profile.QuestionText.Should().Be("What is the food you least liked as a child?");
            }
            finally
            {
                if (createdUser != null)
                {
                    await _userApi.DeactivateUserAsync(createdUser.Id);
                    await _userApi.DeleteUserAsync(createdUser.Id);
                }
            }
        }

        [Fact]
        public async Task EnrollSmsFactor()
        {
            var guid = Guid.NewGuid();
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {

                Profile = new UserProfile
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com",
                    PrimaryPhone = "123-321-4444",
                    MobilePhone = "321-123-5555",
                    Locale = "en_US",
                    SecondEmail = $"{Guid.NewGuid()}@second.com",
                    Timezone = "Japan",
                }
            };

            try
            {
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new SmsUserFactor
                {
                    FactorType = FactorType.Sms,
                    Profile = new SmsUserFactorProfile
                    {
                        PhoneNumber = "+16284001133",
                    }
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(FactorType.Sms);
                ((SmsUserFactor)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");
            }
            finally
            {
                if (createdUser != null)
                {
                    await _userApi.DeactivateUserAsync(createdUser.Id);
                    await _userApi.DeleteUserAsync(createdUser.Id);
                }
            }
        }

        [Fact]
        public async Task EnrollCallFactor()
        {
            var guid = Guid.NewGuid();
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {

                Profile = new UserProfile
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com",
                    PrimaryPhone = "123-321-4444",
                    MobilePhone = "321-123-5555",
                    Locale = "en_US",
                    SecondEmail = $"{Guid.NewGuid()}@second.com",
                    Timezone = "Japan",
                }
            };

            try
            {
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new CallUserFactor
                {
                    FactorType = FactorType.Call,
                    Profile = new CallUserFactorProfile
                    {
                        PhoneNumber = "+16284001133",
                        PhoneExtension = "1234",
                    }
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(FactorType.Call);
                ((CallUserFactor)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");
                ((CallUserFactor)createdUserFactor).Profile.PhoneExtension.Should().Be("1234");
                createdUserFactor.Status.Should().Be(FactorStatus.PENDINGACTIVATION);
            }
            finally
            {
                if (createdUser != null)
                {
                    await _userApi.DeactivateUserAsync(createdUser.Id);
                    await _userApi.DeleteUserAsync(createdUser.Id);
                }
            }
        }

        public static IEnumerable<object[]> FactorTypes =>
         new List<object[]>
         {
            new object[] {FactorType.Tokensoftwaretotp },
            new object[] {FactorType.Push },
         };

        [Theory]
        [MemberData(nameof(FactorTypes))]
        public async Task EnrollFactors(FactorType factorType)
        {
            var guid = Guid.NewGuid();
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {

                Profile = new UserProfile
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com",
                    PrimaryPhone = "123-321-4444",
                    MobilePhone = "321-123-5555",
                    Locale = "en_US",
                    SecondEmail = $"{Guid.NewGuid()}@second.com",
                    Timezone = "Japan",
                }
            };

            try
            {
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new UserFactor
                {
                    FactorType = factorType,
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(factorType);
            }
            finally
            {
                if (createdUser != null)
                {
                    await _userApi.DeactivateUserAsync(createdUser.Id);
                    await _userApi.DeleteUserAsync(createdUser.Id);
                }
            }
        }


        [Fact]
        public async Task ResendEnrollSmsFactor()
        {
            var guid = Guid.NewGuid();
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {

                Profile = new UserProfile
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com",
                    PrimaryPhone = "123-321-4444",
                    MobilePhone = "321-123-5555",
                    Locale = "en_US",
                    SecondEmail = $"{Guid.NewGuid()}@second.com",
                    Timezone = "Japan",
                }
            };

            try
            {
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new SmsUserFactor
                {
                    FactorType = FactorType.Sms,
                    Profile = new SmsUserFactorProfile
                    {
                        PhoneNumber = "+16284001133",
                    }
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(FactorType.Sms);
                ((SmsUserFactor)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");

                // Time window to resend an sms and avoid 429 is 30 secs
                Thread.Sleep(31000);

                var resendUserFactor = await _userFactorApi.ResendEnrollFactorAsync(createdUser.Id, createdUserFactor.Id, createdUserFactor);
                resendUserFactor.Should().NotBeNull();
                resendUserFactor.FactorType.Should().Be(FactorType.Sms);
                ((SmsUserFactor)resendUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");
            }
            finally
            {
                if (createdUser != null)
                {
                    await _userApi.DeactivateUserAsync(createdUser.Id);
                    await _userApi.DeleteUserAsync(createdUser.Id);
                }
            }
        }

        [Fact]
        public async Task ResetFactor()
        {
            var guid = Guid.NewGuid();
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {

                Profile = new UserProfile
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com",
                    PrimaryPhone = "123-321-4444",
                    MobilePhone = "321-123-5555",
                    Locale = "en_US",
                    SecondEmail = $"{Guid.NewGuid()}@second.com",
                    Timezone = "Japan",
                }
            };

            try
            {
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new SmsUserFactor
                {
                    FactorType = FactorType.Sms,
                    Profile = new SmsUserFactorProfile
                    {
                        PhoneNumber = "+16284001133",
                    }
                }, activate:true);

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(FactorType.Sms);
                createdUserFactor.Status.Should().Be(FactorStatus.ACTIVE);
                ((SmsUserFactor)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");

                var userFactorsCatalog = await _userFactorApi.ListSupportedFactors(createdUser.Id).ToListAsync();

                userFactorsCatalog.Any(x => x.FactorType == FactorType.Sms).Should().BeTrue();

                await _userFactorApi.UnenrollFactorAsync(createdUser.Id, createdUserFactor.Id, removeRecoveryEnrollment: true);

                userFactorsCatalog = await _userFactorApi.ListSupportedFactors(createdUser.Id).ToListAsync();

                var smsFactor = userFactorsCatalog.FirstOrDefault(x => x.FactorType == FactorType.Sms);

                smsFactor.Should().NotBeNull();
                smsFactor.Status.Should().Be(FactorStatus.NOTSETUP);
            }
            finally
            {
                if (createdUser != null)
                {
                    await _userApi.DeactivateUserAsync(createdUser.Id);
                    await _userApi.DeleteUserAsync(createdUser.Id);
                }
            }
        }
    }
}
