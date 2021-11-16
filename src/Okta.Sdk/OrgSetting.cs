// <copyright file="OrgSetting.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc cref="OrgSetting"/>
    public partial class OrgSetting : IOrgSetting
    {
        /// <inheritdoc/>
        public Task UpdateOrgLogoAsync(FileStream file, CancellationToken cancellationToken = default)
            => GetClient().Orgs.UpdateOrgLogoAsync(file, cancellationToken);
    }
}
