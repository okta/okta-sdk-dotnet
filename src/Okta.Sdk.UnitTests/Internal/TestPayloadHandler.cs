// <copyright file="TestPayloadHandler.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestPayloadHandler : JsonPayloadHandler
    {
        public TestPayloadHandler(string testContent = null)
        {
            ContentType = "foo";
            TestContent = testContent ?? string.Empty;
        }

        public void SetContentTransferEncoding(string value)
        {
            ContentTransferEncoding = value;
        }

        public string TestContent { get; set; }

        protected override HttpContent GetRequestHttpContent(HttpRequest httpRequest)
        {
            return new StringContent(TestContent);
        }
    }
}
