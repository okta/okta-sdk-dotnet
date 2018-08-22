// <copyright file="WebLink.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an <a href="https://tools.ietf.org/html/rfc5988">RFC 5988</a> Web Link.
    /// </summary>
    public class WebLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebLink"/> class.
        /// </summary>
        /// <param name="target">The link target.</param>
        /// <param name="relation">The link relation.</param>
        public WebLink(string target, string relation)
        {
            Target = target;
            Relation = relation;
        }

        /// <summary>
        /// Gets the link target.
        /// </summary>
        /// <value>
        /// The link target.
        /// </value>
        public string Target { get; }

        /// <summary>
        /// Gets the link relation.
        /// </summary>
        /// <value>
        /// The link relation.
        /// </value>
        public string Relation { get; }

        /// <inheritdoc/>
        public override string ToString() => Target;
    }
}
