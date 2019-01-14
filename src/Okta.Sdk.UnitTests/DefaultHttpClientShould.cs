// <copyright file="DefaultHttpClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultHttpClientShould
    {
        [Fact]
        public void NotHaveCloseConnectionAsDefaultHeader()
        {
            var client = DefaultHttpClient.Create(30, null, NullLogger.Instance);

            client.DefaultRequestHeaders?.Connection?.Should().BeNullOrEmpty();
        }
    }
}
