// <copyright file="OktaApiException.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public class OktaApiException : OktaException
    {
        private readonly Resource _resource = new Resource();

        public OktaApiException(int statusCode, Resource data)
            : base(message: data.GetStringProperty(nameof(ErrorSummary)))
        {
            StatusCode = statusCode;
            _resource = data;
        }

        public int StatusCode { get; }

        public string ErrorCode => _resource.GetStringProperty(nameof(ErrorCode));

        public string ErrorSummary => _resource.GetStringProperty(nameof(ErrorSummary));

        public string ErrorLink => _resource.GetStringProperty(nameof(ErrorLink));

        public string ErrorId => _resource.GetStringProperty(nameof(ErrorId));

        // TODO errorCauses (list of ?)
    }
}
