// <copyright file="TestResource.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.UnitTests
{
    public class TestResource : Resource
    {
        public TestResource()
            : base(ResourceDictionaryType.ChangeTracking)
        {
        }

        public string Foo
        {
            get => GetStringProperty("foo");
            set => SetProperty("foo", value);
        }

        public bool? Bar
        {
            get => GetBooleanProperty("bar");
            set => SetProperty("bar", value);
        }
    }
}
