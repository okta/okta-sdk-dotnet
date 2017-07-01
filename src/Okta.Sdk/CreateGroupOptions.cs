// <copyright file="CreateGroupOptions.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Contains the parameters needed to create a new group.
    /// </summary>
    public sealed class CreateGroupOptions
    {
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>
        /// The name of the group.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the group.
        /// </summary>
        /// <value>
        /// The description of the group.
        /// </value>
        public string Description { get; set; }
    }
}
