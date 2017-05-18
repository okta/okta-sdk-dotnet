// <copyright file="ISerializer.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface ISerializer
    {
        string Serialize(object model);

        IDictionary<string, object> Deserialize(string json);

        IEnumerable<IDictionary<string, object>> DeserializeArray(string json);
    }
}
