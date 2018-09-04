// <copyright file="ResourceFactoryShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using FluentAssertions;
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

        /// <summary>
        /// Tests whether resource types that do not require resolution are instantiated correctly.
        /// </summary>
        [Fact]
        public void CreateUserFromExistingData()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>
            {
                { "id", "foobar" },
            };

            var user = factory.CreateFromExistingData<User>(fakeData);

            user.Should().NotBeNull();
            user.Should().BeOfType<User>();
            user.Id.Should().Be("foobar");
        }

        /// <summary>
        /// Tests whether resource types that require resolution are instantiated correctly.
        /// </summary>
        [Fact]
        public void CreateSwaApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>
            {
                { "signOnMode", ApplicationSignOnMode.BrowserPlugin },
                { "name", "template_swa" },
            };

            var app = factory.CreateFromExistingData<Application>(fakeData);

            app.Should().NotBeNull();
            app.Should().BeOfType<SwaApplication>();
        }

        [Fact]
        public void CreateSwaThreeFieldApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>
            {
                { "signOnMode", ApplicationSignOnMode.BrowserPlugin },
                { "name", "template_swa3field" },
            };

            var app = factory.CreateFromExistingData<Application>(fakeData);

            app.Should().NotBeNull();
            app.Should().BeOfType<SwaThreeFieldApplication>();
        }

        [Fact]
        public void CreateBookmarkApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>
            {
                { "signOnMode", ApplicationSignOnMode.Bookmark },
            };

            var app = factory.CreateFromExistingData<Application>(fakeData);

            app.Should().NotBeNull();
            app.Should().BeOfType<BookmarkApplication>();
        }

        [Fact]
        public void CreateBasicApplicationFromExistingData()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>
            {
                { "signOnMode", ApplicationSignOnMode.BasicAuth },
            };

            var app = factory.CreateFromExistingData<IApplication>(fakeData);

            app.Should().NotBeNull();
            app.Should().BeOfType<BasicAuthApplication>();
        }

        [Fact]
        public void CreateSecurityQuestionFactor()
        {
            var factory = new ResourceFactory(null, null);
            var fakeData = new Dictionary<string, object>();
            fakeData.Add("factorType", FactorType.Question);

            var app = factory.CreateFromExistingData<IFactor>(fakeData);

            app.Should().NotBeNull();
            app.Should().BeOfType<SecurityQuestionFactor>();
        }
    }
}
