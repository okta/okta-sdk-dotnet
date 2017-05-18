// <copyright file="ResourceCreator.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Okta.Sdk.UnitTests
{
    public class ResourceCreator<T>
        where T : Resource, new()
    {
        private readonly IDictionary<string, object> _data = new Dictionary<string, object>();

        public ResourceCreator<T> With(Expression<Func<T, object>> propertySelector, object value)
        {
            var propertyInfo = GetPropertyName(propertySelector);

            _data.Add(propertyInfo.Name, value);

            return this;
        }

        public ResourceCreator<T> With(params (Expression<Func<T, object>> propertySelector, object value)[] setters)
        {
            foreach (var (selector, value) in setters)
            {
                With(selector, value);
            }

            return this;
        }

        public static implicit operator T(ResourceCreator<T> creator)
        {
            var factory = new ResourceFactory();
            return factory.CreateNew<T>(creator._data);
        }

        private static PropertyInfo GetPropertyName<TSource, TProperty>(Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var body = propertyLambda.Body;

#pragma warning disable SA1119 // waiting for StyleCop bugfix
            if (!(body is MemberExpression member))
#pragma warning restore SA1119 // waiting for StyleCop bugfix
            {
                throw new ArgumentException($"Expression '{propertyLambda}' does not refer to a property.");
            }

            var propertyInfo = member.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");
            }

            return propertyInfo;
        }
    }
}
