// <copyright file="RecordedScenarioFixture.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk.IntegrationTests
{
    public sealed class RecordedScenarioFixture : IDisposable
    {
        private readonly bool _useLocalServer;

        private bool _isDisposed = false; // To detect redundant calls

        public RecordedScenarioFixture()
        {
            _useLocalServer = TestConfiguration.UseLocalServer;

            if (!_useLocalServer)
            {
                return;
            }

            Console.WriteLine("Starting local server...");
        }

        private void CleanUpLocalServer()
        {
            if (!_useLocalServer)
            {
                return;
            }

            // stop!
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    CleanUpLocalServer();
                }

                _isDisposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}
