// <copyright file="LoggingFixture.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Xunit.Abstractions;
using Xunit.Sdk;

namespace Okta.Sdk.IntegrationTests
{
    public class LoggingFixture
    {
        private readonly IMessageSink _messageSink;

        public LoggingFixture(IMessageSink messageSink)
        {
            _messageSink = messageSink;
            _messageSink.OnMessage(new DiagnosticMessage("hello world"));
        }

        public void LogMessage(string message)
        {
            _messageSink.OnMessage(new DiagnosticMessage(message));
        }
    }
}
