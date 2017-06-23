// <copyright file="RecordedScenarioFixture.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Okta.Sdk.IntegrationTests
{
#pragma warning disable SA1503 // Braces must not be omitted
    public sealed class RecordedScenarioFixture : IDisposable
    {
        private readonly bool _useLocalServer;
        private readonly Process _localServerProcess;

        private bool _isDisposed = false; // To detect redundant calls

        public RecordedScenarioFixture()
        {
            _useLocalServer = TestConfiguration.UseLocalServer;

            if (!_useLocalServer) return;

            Console.WriteLine("Starting local server...");
            _localServerProcess = StartLocalServer();
        }

        private Process StartLocalServer()
        {
            var environmentPath = Environment.GetEnvironmentVariable("PATH");
            var npmPath = environmentPath
                .Split(';')
                .Select(x => Path.Combine(x, "npm.cmd"))
                .Where(File.Exists)
                .FirstOrDefault();
            Console.WriteLine("Found npm path: ", npmPath);

            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = npmPath,
                Arguments = "run test-server",
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", ".."),
            };

            return Process.Start(startInfo);
        }

        private void CleanUpLocalServer()
        {
            if (!_useLocalServer) return;

            if (_localServerProcess == null || _localServerProcess.HasExited) throw new Exception("The test server is not running.");

            _localServerProcess.Dispose();

            if (!_localServerProcess.HasExited) throw new Exception("The test server could not be stopped.");
            if (_localServerProcess.ExitCode != 0) throw new Exception("Some test scenarios were not exercised.");
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
#pragma warning restore SA1503 // Braces must not be omitted
