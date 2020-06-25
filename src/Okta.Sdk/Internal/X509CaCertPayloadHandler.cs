// <copyright file="X509CaCertPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <inheritdoc />
    public class X509CaCertPayloadHandler : ByteArrayPayloadHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="X509CaCertPayloadHandler"/> class.
        /// </summary>
        public X509CaCertPayloadHandler()
        {
            ContentType = "application/x-x509-ca-cert";
        }
    }
}
