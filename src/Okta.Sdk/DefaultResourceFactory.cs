using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class DefaultResourceFactory : IResourceFactory
    {
        private ChangeTrackingDictionary NewDictionary()
            => new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase);

        public T Create<T>(IDictionary<string, object> data)
            where T : Resource
        {
            var model = Activator.CreateInstance(typeof(T), data ?? NewDictionary(), this);
            return (T)model;
        }
    }
}
