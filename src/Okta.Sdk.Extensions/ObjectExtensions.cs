// <copyright file="ObjectExtensions.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Reflection;

namespace Okta.Sdk.Extensions;

public static class ObjectExtensions
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