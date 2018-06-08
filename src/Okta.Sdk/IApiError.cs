// <copyright file="IApiError.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an error returned by the Okta API.
    /// </summary>
    public interface IApiError : IResource
    {
        /// <summary>
        /// Gets the <c>errorCode</c> property.
        /// </summary>
        /// <value>The error code.</value>
        string ErrorCode { get; }

        /// <summary>
        /// Gets the <c>errorSummary</c> property.
        /// </summary>
        /// <value>The error summary.</value>
        string ErrorSummary { get; }

        /// <summary>
        /// Gets the <c>errorLink</c> property.
        /// </summary>
        /// <value>The error link.</value>
        string ErrorLink { get; }

        /// <summary>
        /// Gets the <c>errorId</c> property.
        /// </summary>
        /// <value>The error ID.</value>
        string ErrorId { get; }

        /// <summary>
        /// Gets the <c>errorCauses</c> array (if any).
        /// </summary>
        /// <value>The list of error causes.</value>
        IEnumerable<IApiErrorCause> ErrorCauses { get; }
    }
}
