// <copyright file="PayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// A class responsible for providing body and message content.
    /// </summary>
    public abstract class PayloadHandler : IPayloadHandler
    {
        private string _body;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadHandler"/> class.
        /// </summary>
        public PayloadHandler()
        {
            Serializer = new DefaultSerializer();
        }

        static PayloadHandler()
        {
            _payloadHandlers.TryAdd("application/json", Default);
        }

        private static readonly ConcurrentDictionary<string, IPayloadHandler> _payloadHandlers = new ConcurrentDictionary<string, IPayloadHandler>();

        private ISerializer Serializer { get; }

        /// <inheritdoc/>
        public string ContentType { get; protected set; }

        /// <summary>
        /// Gets or sets the content transfer encoding.
        /// </summary>
        protected string ContentTransferEncoding { get; set; }
        
        /// <inheritdoc/>
        public virtual string GetBody(HttpRequest httpRequest)
        {
            if (httpRequest.Payload != null && Serializer != null)
            {
                // don't re-serialize if already done
                if (string.IsNullOrEmpty(_body))
                {
                    _body = Serializer.Serialize(httpRequest.Payload);
                }
            }

            return _body;
        }

        /// <summary>
        /// Get content for the specified request.
        /// </summary>
        /// <param name="httpRequest">The request whose content is returned.</param>
        /// <returns>Content for the specified request.</returns>
        protected abstract HttpContent GetRequestHttpContent(HttpRequest httpRequest);

        /// <inheritdoc/>
        public virtual void SetMessageContent(HttpRequest httpRequest, HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Content = GetRequestHttpContent(httpRequest);
            if (!string.IsNullOrEmpty(ContentTransferEncoding))
            {
                httpRequestMessage.Headers.Add("Content-Transfer-Encoding", ContentTransferEncoding);
            }
        }

        /// <summary>
        /// The default payload handler.
        /// </summary>
        public static IPayloadHandler Default => new JsonPayloadHandler();

        /// <summary>
        /// Get the payload handler registered for the specified content type.
        /// </summary>
        /// <param name="contentType">The content type whose payload handler is returned.</param>
        /// <returns>A payload handler.</returns>
        public static IPayloadHandler ForContentType(string contentType)
        {
            if (_payloadHandlers.ContainsKey(contentType))
            {
                return _payloadHandlers[contentType];
            }

            Trace.WriteLine($"Payload handler for the specified content type ({contentType}) is not registered; call PayloadHandler.Register first.  Using default payload handler instead.");
            return Default;
        }

        /// <summary>
        /// Register the specified generic payload handler.
        /// </summary>
        /// <typeparam name="T">The type of the payload handler to register.</typeparam>
        public static bool TryRegister<T>()
            where T : PayloadHandler, new()
        {
            return TryRegister(new T());
        }

        /// <summary>
        /// Register the specified payload handler.
        /// </summary>
        /// <param name="payloadHandler">The payload handler instance to register.</param>
        public static bool TryRegister(IPayloadHandler payloadHandler)
        {
            return _payloadHandlers.TryAdd(payloadHandler.ContentType, payloadHandler);
        }

        /// <summary>
        /// Validate the specified request.
        /// </summary>
        /// <param name="httpRequest">The request to validate.</param>
        /// <remarks>
        /// Throws an ArgumentNullException if the specified request is null.
        /// Throws an InvalidOperationException if the current payload handler is not for the content type of the specified request
        /// </remarks>
        protected void ValidateRequest(HttpRequest httpRequest)
        {
            if (httpRequest == null)
            {
                throw new ArgumentNullException(nameof(httpRequest));
            }

            if (!(httpRequest.ContentType?.Equals(ContentType)).Value)
            {
                throw new InvalidOperationException($"ContentType of specified {nameof(HttpRequest)} should be ({ContentType}) but is ({httpRequest.ContentType})");
            }
        }
    }
}