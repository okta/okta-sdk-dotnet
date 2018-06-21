// <copyright file="PageOfResults.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Page of results
    /// </summary>
    /// <typeparam name="T">The type of the results</typeparam>
    public class PageOfResults<T>
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public IEnumerable<T> Results
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the continuation token.
        /// </summary>
        /// <value>
        /// The continuation token.
        /// </value>
        public string ContinuationToken
        {
            get;
            set;
        }
    }
}
