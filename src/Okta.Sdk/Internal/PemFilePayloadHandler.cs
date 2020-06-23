// <copyright file="PemFilePayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <inheritdoc />
    public class PemFilePayloadHandler : ByteArrayPayloadHandler
    {
        /// <inheritdoc />
        public PemFilePayloadHandler()
        {
            ContentType = "application/x-pem-file";
        }
    }
}
