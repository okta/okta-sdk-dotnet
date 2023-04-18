using FluentAssertions;
using Microsoft.Extensions.Options;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                    await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
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
                    await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                    await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                }
            }
        }
    }
}
