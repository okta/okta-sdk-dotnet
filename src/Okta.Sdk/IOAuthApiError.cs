// <copyright file="IOAuthApiError.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk
{
    /// <summary>
    /// Represents an error returned by the Okta OAuth API.
    /// </summary>
    public interface IOAuthApiError : IResource
    {
        /// <summary>
        /// Gets the <c>error</c> property.
        /// </summary>
        /// <value>The error.</value>
        string Error { get; }

        /// <summary>
        /// Gets the <c>error_description</c> property.
        /// </summary>
        /// <value>The error description.</value>
        string ErrorDescription { get; }
    }
}
