// <copyright file="IOrgsClient.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc cref="IOrgsClient"/>
    public partial interface IOrgsClient
    {
        /// <summary>
        /// Updates an org logo.
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task.</returns>
        Task UpdateOrgLogoAsync(FileStream file, CancellationToken cancellationToken = default);
    }
}
