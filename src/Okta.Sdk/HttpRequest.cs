// <copyright file="HttpRequest.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an HTTP request with a URI and optional payload and parameters.
    /// </summary>
    public class HttpRequest
    {
        public HttpRequest() : this(new DefaultSerializer())
        {
        }

        public HttpRequest(ISerializer serializer)
        {
            Serializer = serializer ?? new DefaultSerializer();
        }

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

        private string _body;

        public string GetBody(ISerializer serializer = null)
        {
            if (serializer != null)
            {
                if (Serializer != serializer)
                {
                    Serializer = serializer;
                    if (Payload != null)
                    {
                        _body = Serializer.Serialize(Payload); // re-serialize the payload if the specified serializer is different from the current 
                    }
                }
            }

            if (Payload != null)
            {
                // don't re-serialize if already done
                if (string.IsNullOrEmpty(_body))
                {
                    _body = Serializer.Serialize(Payload);
                }
            }

            return _body;
        }

        public HttpRequest SetBody(string body)
        {
            _body = body;
            return this;
        }

        public HttpRequest SetSerializer(ISerializer serializer)
        {
            Serializer = serializer;
            return this;
        }

        private ISerializer Serializer { get; set; }
    }
}
