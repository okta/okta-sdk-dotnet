// <copyright file="OktaApiException.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Okta.Sdk
{
    /// <summary>
    /// An exception wrapping an error returned by the Okta API.
    /// </summary>
    public class OktaApiException : OktaException
    {
        private readonly IApiError _error;

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaApiException"/> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="error">The error data.</param>
        public OktaApiException(int statusCode, IApiError error)
            : base(message: error.ErrorSummary)
        {
            StatusCode = statusCode;
            _error = error;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public int StatusCode { get; }

        /// <summary>
        /// Gets a detailed error message, including the HTTP status code and error causes.
        /// </summary>
        /// <value>A detailed error message.</value>
        public string DetailedMessage
        {
            get
            {
                var message = $"{StatusCode}: {_error.ErrorSummary}";

                var hasErrorCauses = _error?.ErrorCauses?.Any() ?? false;
                if (hasErrorCauses)
                {
                    message += $". Causes: {string.Join(", ", _error.ErrorCauses.Select(x => $"'{x.ErrorSummary}'"))}";
                }

                return message;
            }
        }

        /// <summary>
        /// Gets the error code from the API error response.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public string ErrorCode => _error?.ErrorCode;

        /// <summary>
        /// Gets the error summary from the API error response.
        /// </summary>
        /// <value>
        /// The error summary.
        /// </value>
        public string ErrorSummary => _error?.ErrorSummary;

        /// <summary>
        /// Gets the error link from the API error response.
        /// </summary>
        /// <value>
        /// The error link.
        /// </value>
        public string ErrorLink => _error?.ErrorLink;

        /// <summary>
        /// Gets the error ID from the API error response.
        /// </summary>
        /// <value>
        /// The error ID.
        /// </value>
        public string ErrorId => _error?.ErrorId;

        /// <summary>
        /// Gets the list of error causes from the API error response.
        /// </summary>
        /// <value>
        /// The list of error causes.
        /// </value>
        public IEnumerable<IApiErrorCause> ErrorCauses => _error?.ErrorCauses;
    }
}
