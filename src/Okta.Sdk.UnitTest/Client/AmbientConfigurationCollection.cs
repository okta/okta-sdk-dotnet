// <copyright file="AmbientConfigurationCollection.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.UnitTest.Client
{
    /// <summary>
    /// Groups the test classes that read or change the ambient configuration the SDK resolves from: the
    /// process working directory, because that is where <c>okta.yaml</c> and <c>appsettings.json</c> are
    /// looked for, and the <c>OKTA_*</c> environment variables. Both are process-wide, and xUnit runs
    /// collections in parallel, so without a shared collection one class can change them out from under
    /// another mid-test and the configuration is read from the wrong place.
    /// </summary>
    public static class AmbientConfigurationCollection
    {
        /// <summary>
        /// The collection name to put on every class that reads or changes the ambient configuration.
        /// </summary>
        public const string Name = "AmbientConfiguration";
    }
}
