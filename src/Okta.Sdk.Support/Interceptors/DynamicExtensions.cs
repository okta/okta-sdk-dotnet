using System;
using System.Reflection;

namespace Okta.Sdk.UnitTest.Interceptors;

public static class DynamicExtensions
{
    public static T GetProperty<T>(this object obj, string propertyName)
    {
        Type type = obj.GetType();
        PropertyInfo propertyInfo = type.GetProperty(propertyName);
        if (propertyInfo != null)
        {
            return (T)propertyInfo.GetValue(obj);
        }

        return default(T);
    }
}