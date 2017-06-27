// <copyright file="ISerializer.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A low-level abstraction over a JSON serializer/deserializer.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes the given object to a string.
        /// </summary>
        /// <param name="model">The object to serialize.</param>
        /// <returns>A JSON representation of <paramref name="model"/>.</returns>
        string Serialize(object model);

        /// <summary>
        /// Deserializes the given JSON string to a .NET dictionary.
        /// </summary>
        /// <param name="json">The JSON to deserialize.</param>
        /// <returns>A .NET dictionary containing the keys and values in the JSON object.</returns>
        IDictionary<string, object> Deserialize(string json);

        /// <summary>
        /// Deserializes the given JSON string to an array of .NET dictionaries.
        /// </summary>
        /// <param name="json">The JSON array to deserialize.</param>
        /// <returns>An array of .NET dictionaries containing the keys and values in each item of the JSON array.</returns>
        IEnumerable<IDictionary<string, object>> DeserializeArray(string json);
    }
}
