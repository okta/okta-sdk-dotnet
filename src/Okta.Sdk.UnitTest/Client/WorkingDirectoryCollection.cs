// <copyright file="WorkingDirectoryCollection.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.UnitTest.Client
{
    /// <summary>
    /// Groups the test classes that change the process working directory, because the SDK looks for
    /// <c>okta.yaml</c> and <c>appsettings.json</c> there. xUnit runs collections in parallel, so
    /// without a shared collection one class can move the working directory out from under another
    /// mid-test and the configuration is read from the wrong place.
    /// </summary>
    public static class WorkingDirectoryCollection
    {
        /// <summary>
        /// The collection name to put on every class that changes the working directory.
        /// </summary>
        public const string Name = "WorkingDirectory";
    }
}
