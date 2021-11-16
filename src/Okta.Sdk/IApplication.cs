// <copyright file="IApplication.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Okta.Sdk
{
    public partial interface IApplication
    {
        /// <summary>
        /// Gets the access policy ID or null if it's not applicable.
        /// </summary>
        /// <returns>The access policy ID</returns>
        string GetAccessPolicyId();
    }
}
