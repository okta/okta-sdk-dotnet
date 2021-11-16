// <copyright file="Application.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public partial class Application : IApplication
    {
        /// <inheritdoc/>
        public string GetAccessPolicyId() =>

            this.GetProperty<Resource>("_links")?
                .GetProperty<Resource>("accessPolicy")?
                .GetProperty<string>("href")?
                .Split('/')?
                .LastOrDefault() ?? null;
    }
}
