// <copyright file="HttpRequest.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    public class HttpRequest
    {
        public string Uri { get; set; }

        public object Payload { get; set; }

        public IEnumerable<KeyValuePair<string, object>> QueryParams { get; set; }
            = Enumerable.Empty<KeyValuePair<string, object>>();

        public IEnumerable<KeyValuePair<string, object>> PathParams { get; set; }
            = Enumerable.Empty<KeyValuePair<string, object>>();
    }
}
