// <copyright file="HomePath.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Contains methods for resolving the home directory path.
    /// </summary>
    public static class HomePath
    {
        /// <summary>
        /// Resolves a collection of path segments with a home directory path.
        /// </summary>
        /// <remarks>
        /// Provides support for Unix-like paths on Windows. If the first path segment starts with <c>~</c>, this segment is prepended with the home directory path.
        /// </remarks>
        /// <param name="pathSegments">The path segments.</param>
        /// <returns>A combined path which includes the resolved home directory path (if necessary).</returns>
        public static string Resolve(params string[] pathSegments)
        {
            if (pathSegments.Length == 0)
            {
                return null;
            }

            if (!pathSegments[0].StartsWith("~"))
            {
                return Path.Combine(pathSegments);
            }

            var homePath = GetHomePath();

            var newSegments =
                new string[] { pathSegments[0].Replace("~", homePath) }
                .Concat(pathSegments.Skip(1))
                .ToArray();

            return Path.Combine(newSegments);
        }

        /// <summary>
        /// Resolves the current user's home directory path.
        /// </summary>
        /// <returns>The home path.</returns>
        public static string GetHomePath()
        {
#if NET45
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Environment.GetEnvironmentVariable("USERPROFILE") ??
                    Path.Combine(Environment.GetEnvironmentVariable("HOMEDRIVE"), Environment.GetEnvironmentVariable("HOMEPATH"));
            }

            var home = Environment.GetEnvironmentVariable("HOME");

            if (string.IsNullOrEmpty(home))
            {
                throw new Exception("Home directory not found. The HOME environment variable is not set.");
            }

            return home;
#endif
        }
    }
}
