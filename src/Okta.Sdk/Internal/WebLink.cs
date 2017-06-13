// <copyright file="WebLink.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Represents an RFC 5988 web link.
    /// </summary>
    /// <see>https://tools.ietf.org/html/rfc5988</see>
    public struct WebLink
    {
        public WebLink(string target, string relation)
        {
            Target = target;
            Relation = relation;
        }

        public string Target { get; }

        public string Relation { get; }
    }
}
