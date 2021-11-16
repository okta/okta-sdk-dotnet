// <copyright file="HttpRequest.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an HTTP request with a URI and optional payload and parameters.
    /// </summary>
    public class HttpRequest
    {
        private string _contentType;
        private string _body;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        public HttpRequest()
        {
            ContentType = "application/json";
        }

        /// <summary>
        /// Gets the payload handler.
        /// </summary>
        protected IPayloadHandler PayloadHandler { get; private set; }

        /// <summary>
        /// Gets or sets the Http verb, also known as the request method.
        /// </summary>
        /// <value>
        /// The request verb.
        /// </value>
        public HttpVerb Verb { get; set; }

        /// <summary>
        /// Gets or sets the request URI.
        /// </summary>
        /// <value>
        /// The request URI.
        /// </value>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the request payload.
        /// </summary>
        /// <value>
        /// The request payload.
        /// </value>
        public object Payload { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType
        {
            get => _contentType;
            set
            {
                _contentType = value;
                PayloadHandler = Internal.PayloadHandler.ForContentType(_contentType);
            }
        }

        /// <summary>
        /// Gets or sets the content encoding.
        /// </summary>
        public string ContentTransferEncoding
        {
            get => GetHeader("Content-Transfer-Encoding");
            set => SetHeader("Content-Transfer-Encoding", value);
        }

        /// <summary>
        /// Gets or sets the set of query parameters to send with the request.
        /// </summary>
        /// <value>
        /// The set of query parameters to send with the request.
        /// </value>
        public IEnumerable<KeyValuePair<string, object>> QueryParameters { get; set; }
            = Enumerable.Empty<KeyValuePair<string, object>>();

        /// <summary>
        /// Gets or sets the set of path parameters to apply to the request URI.
        /// </summary>
        /// <value>
        /// The set of path parameters to apply to the request URI.
        /// </value>
        public IEnumerable<KeyValuePair<string, object>> PathParameters { get; set; }
            = Enumerable.Empty<KeyValuePair<string, object>>();

        /// <summary>
        /// Gets or sets the headers to send with the request.
        /// </summary>
        /// <value>
        /// The headers to send with the request.
        /// </value>
        public IDictionary<string, string> Headers { get; set; }
            = new Dictionary<string, string>();

        /// <summary>
        /// Gets the request body.
        /// </summary>
        /// <returns>The HTTP request body.</returns>
        public string GetBody()
        {
            if (string.IsNullOrEmpty(_body))
            {
                if (PayloadHandler != null)
                {
                    _body = PayloadHandler.GetBody(this);
                }
            }

            return _body;
        }

        /// <summary>
        /// Sets the content of the specified message.
        /// </summary>
        /// <param name="httpRequestMessage">The message whose content is set.</param>
        public virtual void SetHttpRequestMessageContent(HttpRequestMessage httpRequestMessage)
        {
            PayloadHandler.SetHttpRequestMessageContent(this, httpRequestMessage);
        }

        internal HttpRequest SetBody(string body)
        {
            _body = body;
            return this;
        }

        private void SetHeader(string key, string value)
        {
            if (Headers.ContainsKey(key))
            {
                Headers[key] = value;
            }
            else
            {
                Headers.Add(key, value);
            }
        }

        private string GetHeader(string key)
        {
            if (Headers.ContainsKey(key))
            {
                return Headers[key];
            }

            return string.Empty;
        }
    }
}
