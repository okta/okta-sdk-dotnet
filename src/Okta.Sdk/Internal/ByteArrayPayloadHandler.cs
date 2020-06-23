// <copyright file="ByteArrayPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;

namespace Okta.Sdk.Internal
{
    /// <inheritdoc />
    public abstract class ByteArrayPayloadHandler : PayloadHandler
    {
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
                throw new InvalidOperationException($"request payload should be of type byte array (byte[]), but was {httpRequest.Payload.GetType().FullName}");
            }

            return new ByteArrayContent((byte[])httpRequest.Payload);
        }
    }
}
