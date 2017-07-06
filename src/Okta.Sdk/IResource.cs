// <copyright file="IResource.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents a resource in the Okta API.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Gets or sets a resource proprety by name.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <returns>The property value, or<c>null</c>.</returns>
        object this[string name] { get; set; }

        /// <summary>
        /// Gets a list or array property from the resource by name.
        /// </summary>
        /// <typeparam name="T">The type of items contained in the list or array.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>A <see cref="IList{T}">list</see> that can be enumerated to obtain the property items.</returns>
        IList<T> GetArrayProperty<T>(string name);

        /// <summary>
        /// Gets the underlying data backing this resource.
        /// </summary>
        /// <returns>The data backing this resource.</returns>
        /// <remarks>
        /// If the resource is initialized with dictionary type <see cref="Internal.ResourceBehavior.ChangeTracking"/>, this returns any updates merged with the original data.
        /// </remarks>
        IDictionary<string, object> GetData();

        /// <summary>
        /// Gets any data that has been modified since the resource was retrieved.
        /// </summary>
        /// <remarks>This has no effect (behaves the same as <see cref="GetData"/>) unless the resource was initialized with dictionary type <see cref="Internal.ResourceBehavior.ChangeTracking"/>.</remarks>
        /// <returns>The modified resource data.</returns>
        IDictionary<string, object> GetModifiedData();

        /// <summary>
        /// Gets a resource property by name.
        /// </summary>
        /// <remarks>In derived classes, use the more specific methods such as <see cref="Resource.GetStringProperty(string)"/> and <see cref="Resource.GetIntegerProperty(string)"/> instead.</remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="name">The property name.</param>
        /// <returns>The strongly-typed property value, or <c>null</c>.</returns>
        T GetProperty<T>(string name);
    }
}