// <copyright file="OktaApiException.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>


namespace Okta.Sdk
{
    public class OktaApiException : OktaException
    {
        private readonly Resource _resource = new Resource();

        public OktaApiException(int statusCode, Resource data)
            : base(message: data.GetProperty<string>(nameof(ErrorSummary)))
        {
            StatusCode = statusCode;
            _resource = data;
        }

        public int StatusCode { get; }

        public string ErrorCode => _resource.GetProperty<string>(nameof(ErrorCode));

        public string ErrorSummary => _resource.GetProperty<string>(nameof(ErrorSummary));

        public string ErrorLink => _resource.GetProperty<string>(nameof(ErrorLink));

        public string ErrorId => _resource.GetProperty<string>(nameof(ErrorId));

        // TODO errorCauses (list of ?)
    }
}
