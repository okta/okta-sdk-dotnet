// <copyright file="OrgsClient.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <inheritdoc cref="OrgsClient"/>
    public partial class OrgsClient : IOrgsClient
    {
        /// <inheritdoc />
        public async Task UpdateOrgLogoAsync(FileStream file, CancellationToken cancellationToken = default)
        {
            byte[] fileBytes = new byte[file.Length];
            await file.ReadAsync(fileBytes, 0, (int)file.Length, cancellationToken).ConfigureAwait(false);

            var request = new MultipartHttpRequest
            {
                Uri = "/api/v1/org/logo",
                Payload = fileBytes,
                ContentType = "multipart/form-data",
                Verb = HttpVerb.Post,
                FileName = file.Name,
            };

            await PostAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
