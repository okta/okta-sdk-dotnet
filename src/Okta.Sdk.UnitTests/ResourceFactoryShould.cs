// <copyright file="ResourceFactoryShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceFactoryShould
    {
        public class SomeClass // Does not derive from Resource
        {
            public string Foo { get; set; }
        }

        [Fact]
        public void ThrowIfCreateNewTDoesNotDeriveFromResource()
        {
            var factory = new ResourceFactory();
            var fakeData = new Dictionary<string, object>();

            Assert.Throws<InvalidOperationException>(() => factory.CreateNew<string>(fakeData));
            Assert.Throws<InvalidOperationException>(() => factory.CreateNew<SomeClass>(fakeData));
        }

        [Fact]
        public void ThrowIfCreateFromExistingDataTDoesNotDeriveFromResource()
        {
            var factory = new ResourceFactory();
            var fakeData = new Dictionary<string, object>();

            Assert.Throws<InvalidOperationException>(() => factory.CreateFromExistingData<string>(fakeData));
            Assert.Throws<InvalidOperationException>(() => factory.CreateFromExistingData<SomeClass>(fakeData));
        }
    }
}
