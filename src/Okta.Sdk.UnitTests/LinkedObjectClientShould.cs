// <copyright file="C:\src\repos\Okta.Net\okta-sdk-dotnet\src\Okta.Sdk.UnitTests\LinkedObjectClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class LinkedObjectClientShould
    {
        private const string SdkPrefix = "dotnet_sdk";

        [Fact]
        public async Task CallDeleteEndpoint()
        {
            var mockRequestExecutor = Substitute.For<IRequestExecutor>();
            var testClient = new TestableOktaClient(mockRequestExecutor);
            var guid = Guid.NewGuid();
            var testPrimaryName = $"{SdkPrefix}_{nameof(CallDeleteEndpoint)}_primary_{guid}";
            var endPoint = $"/api/v1/meta/schemas/user/linkedObjects/{testPrimaryName}";
            var mockResponse = Substitute.For<HttpResponse<string>>();
            mockResponse.StatusCode = 200;
            mockRequestExecutor
                .DeleteAsync(endPoint, Arg.Any<Dictionary<string, string>>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            await testClient.LinkedObjects.DeleteLinkedObjectDefinitionAsync(testPrimaryName);
            _ = await mockRequestExecutor.Received(1).DeleteAsync(endPoint, Arg.Any<Dictionary<string, string>>(), Arg.Any<CancellationToken>());
        }
    }
}