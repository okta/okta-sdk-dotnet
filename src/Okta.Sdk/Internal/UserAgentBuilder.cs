// <copyright file="UserAgentBuilder.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A User-Agent string generator that uses reflection to detect the current assembly version.
    /// </summary>
    public sealed class UserAgentBuilder
    {
        /// <summary>
        /// The standard User-Agent token of the Okta SDK.
        /// </summary>
        public const string OktaSdkUserAgentName = "okta-sdk-dotnet";

        // Lazy ensures this only runs once and is cached.
        private readonly Lazy<string> _cachedUserAgent;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentBuilder"/> class.
        /// </summary>
        /// <param name="logger">An optional logging interface</param>
        public UserAgentBuilder(ILogger logger = null)
        {
            _logger = logger ?? NullLogger.Instance;
            _cachedUserAgent = new Lazy<string>(Generate);
        }

        /// <summary>
        /// Constructs a User-Agent string.
        /// </summary>
        /// <returns>A User-Agent string with the default tokens, and any additional tokens.</returns>
        public string GetUserAgent() => _cachedUserAgent.Value;

        private string Generate()
        {
            string sdkToken = string.Empty;
            string runtimeToken = string.Empty;
            string operatingSystemToken = string.Empty;

            try
            {
                sdkToken = $"{OktaSdkUserAgentName}/{GetSdkVersion()}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred generating the {nameof(sdkToken)} portion of the user-agent string.  Exception: {ex.Message}");
            }

            try
            {
                runtimeToken = $"runtime/{Sanitize(RuntimeInformation.FrameworkDescription)}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred generating the {nameof(runtimeToken)} portion of the user-agent string.  Exception: {ex.Message}");
            }

            try
            {
                operatingSystemToken = $"os/{Sanitize(RuntimeInformation.OSDescription)}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred generating the {nameof(operatingSystemToken)} portion of the user-agent string.  Exception: {ex.Message}");
            }

            return string.Join(
                " ",
                sdkToken,
                runtimeToken,
                operatingSystemToken)
            .Trim();
        }

        private static string GetSdkVersion()
        {
            var sdkVersion = typeof(OktaClient).GetTypeInfo()
                .Assembly.GetName().Version;

            return $"{sdkVersion.Major}.{sdkVersion.Minor}.{sdkVersion.Build}";
        }

        private static readonly char[] IllegalCharacters = new char[] { '/', ':', ';' };

        private static string Sanitize(string input)
            => IllegalCharacters.Aggregate(input, (current, bad) => current.Replace(bad, '-'));
    }
}
