// <copyright file="PkixCertPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;
using System.Text;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A payload handler for the "application/pkix-cert" content type.
    /// </summary>
    public class PkixCertPayloadHandler : PayloadHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PkixCertPayloadHandler"/> class.
        /// </summary>
        public PkixCertPayloadHandler()
        {
            ContentType = "application/pkix-cert";
            ContentTransferEncoding = "base64";
        }

        /// <summary>
        /// Get base64 encoded content for the specified request.
        /// </summary>
        /// <param name="httpRequest">The request whose content is returned.</param>
        /// <returns>Content for the specified request.</returns>
        /// <remarks>
        /// Throws an ArgumentNullException if request payload is null.
        /// Throws an InvalidOperationException if the payload is not a byte array.
        /// </remarks>
        protected override HttpContent GetRequestHttpContent(HttpRequest httpRequest)
        {
            ValidateRequest(httpRequest);

            if (httpRequest.Payload == null)
            {
                throw new ArgumentNullException("request payload");
            }

            var content = string.Empty;
            if (httpRequest.Payload is string stringPayload)
            {
                content = stringPayload;
            }
            else if (httpRequest.Payload is byte[] bytePayload)
            {
                content = Convert.ToBase64String(bytePayload);
            }

            return new StringContent(content, Encoding.UTF8, ContentType);
        }
    }
}
