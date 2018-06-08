// <copyright file="ApiError.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed class ApiError : Resource, IApiError
    {
        /// <inheritdoc/>
        public string ErrorCode => GetStringProperty("errorCode");

        /// <inheritdoc/>
        public string ErrorSummary => GetStringProperty("errorSummary");

        /// <inheritdoc/>
        public string ErrorLink => GetStringProperty("errorLink");

        /// <inheritdoc/>
        public string ErrorId => GetStringProperty("errorId");

        /// <inheritdoc/>
        public IEnumerable<IApiErrorCause> ErrorCauses => GetArrayProperty<ApiErrorCause>("errorCauses");
    }
}
