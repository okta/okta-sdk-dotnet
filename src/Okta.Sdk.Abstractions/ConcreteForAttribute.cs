using System;

namespace Okta.Sdk.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ConcreteForAttribute : Attribute
    {
        public ConcreteForAttribute(Type @interface)
        {
            Interface = @interface;
        }

        public Type Interface { get; }
    }
}
