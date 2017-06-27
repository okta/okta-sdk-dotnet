// <copyright file="ResourceDictionaryType.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// The types of dictionary behaviors supported by <see cref="Resource"/>s.
    /// </summary>
    public enum ResourceDictionaryType
    {
        /// <summary>
        /// Default behavior (no change tracking).
        /// </summary>
        Default = 0,

        /// <summary>
        /// The resource should track internal changes.
        /// </summary>
        ChangeTracking = 1
    }
}
