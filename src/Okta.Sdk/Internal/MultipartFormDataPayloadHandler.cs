// <copyright file="MultipartFormDataPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Okta.Sdk.Internal
{
    /// <inheritdoc />
    public class MultipartFormDataPayloadHandler : PayloadHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartFormDataPayloadHandler"/> class.
        /// </summary>
        public MultipartFormDataPayloadHandler()
        {
            ContentType = "multipart/form-data";
        }

        /// <inheritdoc/>
        protected override HttpContent GetRequestHttpContent(HttpRequest httpRequest)
        {
            ValidateRequest(httpRequest);

            if (httpRequest.Payload == null)
            {
                throw new ArgumentNullException("request payload");
            }

            if (httpRequest.Payload.GetType() != typeof(byte[]))
            {
                throw new InvalidOperationException($"request payload should be of type , but byte[] was {httpRequest.Payload.GetType().FullName}");
            }

            var fileBytes = (byte[])httpRequest.Payload;
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), "file", ((MultipartHttpRequest)httpRequest).FileName);

            return content;
        }
    }
}
