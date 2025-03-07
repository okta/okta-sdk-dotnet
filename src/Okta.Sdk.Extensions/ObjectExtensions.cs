using System;
using System.Reflection;

namespace Okta.Sdk.Extensions;

public static class ObjectExtensions
{
    public static T? GetProperty<T>(this object obj, string propertyName)
    {
        Type type = obj.GetType();
        PropertyInfo? propertyInfo = type.GetProperty(propertyName);
        if (propertyInfo != null)
        {
            return (T)propertyInfo.GetValue(obj);
        }

        return default(T);
    }
}