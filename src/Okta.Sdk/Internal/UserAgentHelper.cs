// <copyright file="UserAgentHelper.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// User-agent helper
    /// </summary>
    public class UserAgentHelper
    {
        /// <summary>
        /// Returns a normalized framework version description.
        /// </summary>
        /// <param name="runtimeFrameworkDescription">The runtime description.</param>
        /// <param name="runtimeAssemblyCodeBase">The runtime code base.</param>
        /// <returns>The normalized framework desctiption.</returns>
        public static string GetFrameworkDescription(string runtimeFrameworkDescription = "", string runtimeAssemblyCodeBase = "")
        {
            var frameworkDescription = string.IsNullOrEmpty(runtimeFrameworkDescription) ? RuntimeInformation.FrameworkDescription : runtimeFrameworkDescription;
            var assemblyCodeBase = runtimeAssemblyCodeBase;

            // RuntimeInformation.FrameworkDescription only returns the CLI version for .NET Core.
            // We need this workaround to get the product version and have a useful report.
            if (frameworkDescription.StartsWith(".NET Core", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(assemblyCodeBase))
                {
                    assemblyCodeBase = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly?.CodeBase;
                }

                if (assemblyCodeBase != null)
                {
                    var runtimeAssemblyLocation = assemblyCodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    int dotnetCoreAppIndex = Array.IndexOf(runtimeAssemblyLocation, "Microsoft.NETCore.App");

                    if (dotnetCoreAppIndex >= 0 && dotnetCoreAppIndex < runtimeAssemblyLocation.Length - 2)
                    {
                        frameworkDescription = $".NET Core {runtimeAssemblyLocation[dotnetCoreAppIndex + 1]}";
                    }
                }
            }

            return frameworkDescription;
        }
    }
}
