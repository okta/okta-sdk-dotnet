// <copyright file="IChangeTrackable.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// The contract for an object that can track internal changes.
    /// </summary>
    public interface IChangeTrackable
    {
        /// <summary>
        /// Resets any changes to the object.
        /// </summary>
        void Reset();

        /// <summary>
        /// Explicitly marks the property as dirty (modified).
        /// </summary>
        /// <param name="key">The property name or key.</param>
        void MarkDirty(string key);

        /// <summary>
        /// Explicitly marks the property as clean (unmodified).
        /// </summary>
        /// <param name="key">The property name or key.</param>
        void MarkClean(string key);

        /// <summary>
        /// Gets the difference (delta) between the original object state and the modified state.
        /// </summary>
        /// <value>
        /// The difference between the original object state and the modified state.
        /// </value>
        object Difference { get; }
    }
}
