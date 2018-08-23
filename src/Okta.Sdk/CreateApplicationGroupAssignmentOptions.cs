// <copyright file="CreateApplicationGroupAssignmentOptions.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Settings helper class to assign a group to an application
    /// </summary>
    public sealed class CreateApplicationGroupAssignmentOptions
    {
        /// <summary>
        /// Gets or sets a priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets an application id
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets a group id
        /// </summary>
        public string GroupId { get; set; }
    }
}
