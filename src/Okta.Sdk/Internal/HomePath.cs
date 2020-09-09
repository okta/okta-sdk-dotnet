// <copyright file="HomePath.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
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
        /// <returns>A combined path which includes the resolved home directory path (if necessary). If home directory path cannot be resolved, returns null.</returns>
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

            if (!TryGetHomePath(out string homePath))
            {
                return null;
            }

            var newSegments =
                new string[] { pathSegments[0].Replace("~", homePath) }
                .Concat(pathSegments.Skip(1))
                .ToArray();

            return Path.Combine(newSegments);
        }

        /// <summary>
        /// Resolves the current user's home directory path.
        /// Throws an exception if the path cannot be resolved.
        /// </summary>
        /// <returns>The home path.</returns>
        public static string GetHomePath()
        {
            if (TryGetHomePath(out var homePath))
            {
                return homePath;
            }
            else
            {
                throw new Exception("Home directory cannot be found in environment variables.");
            }
        }

        /// <summary>
        /// Tries to resolve the current user's home directory path.
        /// </summary>
        /// <param name="homePath">Output: resolved home path.</param>
        /// <returns>true if home path was resolved; otherwise, false.</returns>
        public static bool TryGetHomePath(out string homePath)
        {
#if NET45
            homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                homePath = Environment.GetEnvironmentVariable("USERPROFILE") ??
                           Path.Combine(Environment.GetEnvironmentVariable("HOMEDRIVE"), Environment.GetEnvironmentVariable("HOMEPATH"));
            }
            else
            {
                homePath = Environment.GetEnvironmentVariable("HOME");
            }
#endif

            return !string.IsNullOrEmpty(homePath);
        }
    }
}
