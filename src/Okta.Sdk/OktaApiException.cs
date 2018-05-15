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
    /// Represents an error returned by the Okta API.
    /// </summary>
    public class OktaApiException : OktaException
    {
        private readonly Resource _resource = new Resource();

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaApiException"/> class.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="data">The error data.</param>
        public OktaApiException(int statusCode, Resource data)
            : base(message: OktaApiException.GetMessageText(statusCode, data))
        {
            StatusCode = statusCode;
            _resource = data;
        }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the error code from the Okta error details.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public string ErrorCode => _resource.GetProperty<string>(nameof(ErrorCode));

        /// <summary>
        /// Gets the error summary from the Okta error details.
        /// </summary>
        /// <value>
        /// The error summary.
        /// </value>
        public string ErrorSummary => _resource.GetProperty<string>(nameof(ErrorSummary));

        /// <summary>
        /// Gets the error link from the Okta error details.
        /// </summary>
        /// <value>
        /// The error link.
        /// </value>
        public string ErrorLink => _resource.GetProperty<string>(nameof(ErrorLink));

        /// <summary>
        /// Gets the error ID from the Okta error details.
        /// </summary>
        /// <value>
        /// The error ID.
        /// </value>
        public string ErrorId => _resource.GetProperty<string>(nameof(ErrorId));

        /// <summary>
        /// Gets the list of error causes from the API response.
        /// </summary>
        /// <value>
        /// The list of error causes from the API response
        /// </value>
        public IEnumerable<string> ErrorCauses
        {
            get
            {
                return GetErrorCauses(_resource);
            }
        }

        private static IEnumerable<string> GetErrorCauses(Resource resource)
        {
            if (!(resource?.GetData()["errorCauses"] is IList<object> causes))
            {
                yield break;
            }

            foreach (JObject o in causes.OfType<JObject>())
            {
                yield return o.Value<string>("errorSummary");
            }
        }

        private static string GetMessageText(int statusCode, Resource resource)
        {
            string summary = resource.GetProperty<string>(nameof(ErrorSummary));
            return $"{statusCode}: {summary}\r\n{string.Join("\r\n", GetErrorCauses(resource))}";
        }
    }
}
