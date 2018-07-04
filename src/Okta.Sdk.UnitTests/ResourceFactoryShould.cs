// <copyright file="ResourceFactoryShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Okta.Sdk.Internal;
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
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>();

            Assert.Throws<InvalidOperationException>(() => factory.CreateNew<string>(fakeData));
            Assert.Throws<InvalidOperationException>(() => factory.CreateNew<SomeClass>(fakeData));
        }

        [Fact]
        public void ThrowIfCreateFromExistingDataTDoesNotDeriveFromResource()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>();

            Assert.Throws<InvalidOperationException>(() => factory.CreateFromExistingData<string>(fakeData));
            Assert.Throws<InvalidOperationException>(() => factory.CreateFromExistingData<SomeClass>(fakeData));
        }

        [Fact]
        public void CreateSwaApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);

            var fakeData = new Dictionary<string, object>();
            fakeData.Add("signOnMode", ApplicationSignOnMode.BrowserPlugin);
            fakeData.Add("name", "template_swa");

            var app = factory.CreateFromExistingData<SwaApplication>(fakeData);
            Assert.NotNull(app);
            Assert.IsType<SwaApplication>(app);
        }

        [Fact]
        public void CreateSwaThreeFieldApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);

            var fakeData = new Dictionary<string, object>();
            fakeData.Add("signOnMode", ApplicationSignOnMode.BrowserPlugin);
            fakeData.Add("name", "template_swa3field");

            var app = factory.CreateFromExistingData<SwaThreeFieldApplication>(fakeData);
            Assert.NotNull(app);
            Assert.IsType<SwaThreeFieldApplication>(app);
        }

        [Fact]
        public void CreateBookmarkApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);

            var fakeData = new Dictionary<string, object>();
            fakeData.Add("signOnMode", ApplicationSignOnMode.Bookmark);

            var app = factory.CreateFromExistingData<BookmarkApplication>(fakeData);
            Assert.NotNull(app);
            Assert.IsType<BookmarkApplication>(app);
        }

        [Fact]
        public void CreateBasicApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);

            var fakeData = new Dictionary<string, object>();
            fakeData.Add("signOnMode", ApplicationSignOnMode.BasicAuth);

            var app = factory.CreateFromExistingData<BasicAuthApplication>(fakeData);
            Assert.NotNull(app);
            Assert.IsType<BasicAuthApplication>(app);
        }
    }
}
