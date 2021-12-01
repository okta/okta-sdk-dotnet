using System;
using System.Collections.Generic;
using System.Text;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestHttpMultipartRequest : MultipartHttpRequest
    {
        public IPayloadHandler GetPayloadHandler()
        {
            return PayloadHandler;
        }
    }
}
