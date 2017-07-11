// <copyright file="IDeepCloneable.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// An object that can be deep cloned.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    public interface IDeepCloneable<T>
    {
        /// <summary>
        /// Returns a deep clone (copy) of this object.
        /// </summary>
        /// <returns>A deep clone (copy) of this object.</returns>
        T DeepClone();
    }
}
