// <copyright file="HttpResponse{T}.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name must match first type name
    public class HttpResponse
    {
        public int StatusCode { get; set; }

        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; set; }
    }

    public class HttpResponse<T> : HttpResponse
    {
        public T Payload { get; set; }
    }
#pragma warning restore SA1649 // File name must match first type name
#pragma warning restore SA1402 // File may only contain a single type
}
