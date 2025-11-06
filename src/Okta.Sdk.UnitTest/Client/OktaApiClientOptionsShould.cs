// <copyright file="OktaApiClientOptionsShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Client;

public class OktaApiClientOptionsShould
{
    [Fact]
    public Task UseDefaultConfiguration()
    {
        var forComparison = Configuration.GetConfigurationOrDefault();
        var (userApi, groupApi, applicationApi) = OktaApiClientOptions
            .UseDefaultConfiguration()
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        return Task.CompletedTask;
    }

    [Fact]
    public Task UseSpecifiedConfiguration()
    {
        const string testDomain = "https://my.test.domain.com";
        const string testToken = "my.test.token";

        var testConfiguration = new Configuration()
        {
            OktaDomain = testDomain,
            Token = testToken
        };

        var (userApi, groupApi, applicationApi) = OktaApiClientOptions
            .UseConfiguration((_ => testConfiguration))
            .BuildApis<UserApi, GroupApi, ApplicationApi>();
        
        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        return Task.CompletedTask;
    }

    [Fact]
    public Task UseConfigurationLoader()
    {
        const string testDomain = "https://my.test.domain.com";
        const string testToken = "my.test.token";

        var testConfiguration = new Configuration
        {
            OktaDomain = testDomain,
            Token = testToken
        };

        var (userApi, groupApi, applicationApi) = OktaApiClientOptions
            .UseConfiguration((_ => testConfiguration))
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testToken);

        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(testToken);

        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        return Task.CompletedTask;
    }
}