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
                
                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new UserFactorSecurityQuestion()
                {
                    FactorType = UserFactorType.Question,
                    Profile = new UserFactorSecurityQuestionProfile()
                    {
                        Question = "disliked_food",
                        Answer = "mayonnaise"
                    },
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(UserFactorType.Question);
                ((UserFactorSecurityQuestion)createdUserFactor).Profile.Question.Value.Should().Be("disliked_food");
                ((UserFactorSecurityQuestion)createdUserFactor).Profile.QuestionText.Should().Be("What is the food you least liked as a child?");
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

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new UserFactorSMS()
                {
                    FactorType = UserFactorType.Sms,
                    Profile = new UserFactorSMSProfile()
                    {
                        PhoneNumber = "+16284001133",
                    }
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(UserFactorType.Sms);
                ((UserFactorSMS)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");
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
        public async Task EnrollAndActivateWebAuthnFactor()
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
                // Create user
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                // Enroll WebAuthn factor
                var webAuthnFactor = await _userFactorApi.EnrollFactorAsync(
                    createdUser.Id,
                    new UserFactorWebAuthn
                    {
                        FactorType = UserFactorType.Webauthn,
                        Provider = UserFactorWebAuthn.ProviderEnum.FIDO,
                        Profile = new UserFactorWebAuthnProfile
                        {
                            AuthenticatorName = "MacBook Touch ID",
                            CredentialId = "test-credential-id"
                        }
                    });
                webAuthnFactor.Should().NotBeNull();
                webAuthnFactor.FactorType.Should().Be(UserFactorType.Webauthn);
                webAuthnFactor.Provider.Should().Be(UserFactorWebAuthn.ProviderEnum.FIDO);
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

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new UserFactorCall
                {
                    FactorType = UserFactorType.Call,
                    Profile = new UserFactorCallProfile()
                    {
                        PhoneNumber = "+16284001133",
                        PhoneExtension = "1234",
                    }
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(UserFactorType.Call);
                ((UserFactorCall)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");
                ((UserFactorCall)createdUserFactor).Profile.PhoneExtension.Should().Be("1234");
                createdUserFactor.Status.Should().Be(UserFactorStatus.PENDINGACTIVATION);
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
            new object[] { UserFactorType.Tokensoftwaretotp },
            new object[] { UserFactorType.Push }
         };

        [Theory]
        [MemberData(nameof(FactorTypes))]
        public async Task EnrollFactors(UserFactorType factorType)
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

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new UserFactorSMS()
                {
                    FactorType = UserFactorType.Sms,
                    Profile = new UserFactorSMSProfile()
                    {
                        PhoneNumber = "+16284001133",
                    }
                });

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(UserFactorType.Sms);
                ((UserFactorSMS)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");

                // Time window to resend an sms and avoid 429 is 30 secs
                Thread.Sleep(31000);

                var resendUserFactorRequest = new ResendUserFactor()
                {
                    FactorType = ResendUserFactorType.Sms
                };
                
                var resendUserFactor = await _userFactorApi.ResendEnrollFactorAsync(createdUser.Id, createdUserFactor.Id, resendUserFactorRequest);
                resendUserFactor.Should().NotBeNull();
                resendUserFactor.FactorType.Should().Be(UserFactorType.Sms);
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

                var createdUserFactor = await _userFactorApi.EnrollFactorAsync(createdUser.Id, new UserFactorSMS()
                {
                    FactorType = UserFactorType.Sms,
                    Profile = new UserFactorSMSProfile()
                    {
                        PhoneNumber = "+16284001133",
                    }
                }, activate:true);

                createdUserFactor.Should().NotBeNull();
                createdUserFactor.FactorType.Should().Be(UserFactorType.Sms);
                createdUserFactor.Status.Should().Be(UserFactorStatus.ACTIVE);
                ((UserFactorSMS)createdUserFactor).Profile.PhoneNumber.Should().Be("+16284001133");

                var userFactorsCatalog = await _userFactorApi.ListSupportedFactors(createdUser.Id).ToListAsync();

                userFactorsCatalog.Any(x => x.FactorType == UserFactorType.Sms).Should().BeTrue();

                await _userFactorApi.UnenrollFactorAsync(createdUser.Id, createdUserFactor.Id, removeRecoveryEnrollment: true);

                userFactorsCatalog = await _userFactorApi.ListSupportedFactors(createdUser.Id).ToListAsync();

                var smsFactor = userFactorsCatalog.FirstOrDefault(x => x.FactorType == UserFactorType.Sms);

                smsFactor.Should().NotBeNull();
                smsFactor.Status.Should().Be(UserFactorStatus.NOTSETUP);
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
        public async Task ListAllEnrolledFactors()
        {
            User createdUser = null;

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ListFactors",
                    LastName = "TestUser",
                    Login = $"{Guid.NewGuid()}@login.com",
                    Email = $"{Guid.NewGuid()}@email.com"
                }
            };

            try
            {
                // Create user
                createdUser = await _userApi.CreateUserAsync(createUserRequest);

                // Enroll Security Question factor
                var securityQuestionFactor = await _userFactorApi.EnrollFactorAsync(
                    createdUser.Id,
                    new UserFactorSecurityQuestion
                    {
                        FactorType = UserFactorType.Question,
                        Profile = new UserFactorSecurityQuestionProfile
                        {
                            Question = "disliked_food",
                            Answer = "mayonnaise"
                        }
                    });

                // Enroll SMS factor
                var smsFactor = await _userFactorApi.EnrollFactorAsync(
                    createdUser.Id,
                    new UserFactorSMS
                    {
                        FactorType = UserFactorType.Sms,
                        Profile = new UserFactorSMSProfile
                        {
                            PhoneNumber = "+16284001133"
                        }
                    });

                // Enroll Call factor
                var callFactor = await _userFactorApi.EnrollFactorAsync(
                    createdUser.Id,
                    new UserFactorCall
                    {
                        FactorType = UserFactorType.Call,
                        Profile = new UserFactorCallProfile
                        {
                            PhoneNumber = "+16284001133",
                            PhoneExtension = "1234"
                        }
                    });

                // Retrieve all factors
                var factors = await _userFactorApi.ListFactors(createdUser.Id).ToListAsync();

                // Verify all factors are present
                factors.Should().NotBeNull();
                factors.Should().HaveCount(4, "because we enrolled three factors");

                factors.Should().ContainSingle(f =>
                    f.FactorType == UserFactorType.Question &&
                    f is UserFactorSecurityQuestion);

                factors.Should().ContainSingle(f =>
                    f.FactorType == UserFactorType.Sms &&
                    f is UserFactorSMS);

                factors.Should().ContainSingle(f =>
                    f.FactorType == UserFactorType.Call &&
                    f is UserFactorCall); 
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
