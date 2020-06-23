// <copyright file="TestHttpRequest.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestHttpRequest : HttpRequest
    {
        public IPayloadHandler GetPayloadHandler()
        {
            return PayloadHandler;
        }
    }
}
