// <copyright file="IApiErrorCause.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an errorCause element in an API error.
    /// </summary>
    public interface IApiErrorCause : IResource
    {
        /// <summary>
        /// Gets the error summary.
        /// </summary>
        /// <value>The error summary.</value>
        string ErrorSummary { get; }
    }
}
