using System;
using System.Collections.Generic;

namespace Okta.Sdk.Internal
{
    public class ContentTypePayloadHandler
    {
        public ContentTypePayloadHandler()
        {
        }

        public static Dictionary<string, Func<ISerializer, object, string>> DefaultHandlers { get; set; }
    }
}