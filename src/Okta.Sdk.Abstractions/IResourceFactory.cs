using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk.Abstractions
{
    public interface IResourceFactory
    {
        T Create<T>(IDictionary<string, object> data);
    }
}
