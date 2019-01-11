using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultHttpClientShould
    {
        [Fact]
        public async Task NotHaveCloseConnectionAsDefaultHeader()
        {
            var client = DefaultHttpClient.Create(30, null, NullLogger.Instance);

            client.DefaultRequestHeaders?.Connection?.Should().BeNullOrEmpty();
        }
    }
}
