﻿using FluentAssertions;
using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class LinkHeaderParserShould
    {
        [Fact]
        public void ParseLink()
        {
            var headerValue = "<https://my-server.dev/api/v1/users?limit=25>; rel=\"self\"";
            var links = LinkHeaderParser.Parse(headerValue);

            links.Count().Should().Be(1);
            links.Single().Target.Should().Be("https://my-server.dev/api/v1/users?limit=25");
            links.Single().Relation.Should().Be("self");
        }

        [Fact]
        public void ParseLinkWithoutRelation()
        {
            var headerValue = "<https://my-server.dev/api/v1/users?limit=25>; rel=\"self\"";
            var links = LinkHeaderParser.Parse(headerValue);

            links.Count().Should().Be(1);
            links.Single().Target.Should().Be("https://my-server.dev/api/v1/users?limit=25");
            links.Single().Relation.Should().Be("self");
        }

        [Fact]
        public void ParseMultipleLinks()
        {
            var headerValues = new List<string>()
            {
                "<https://my-server.dev/api/v1/users?limit=25>; rel=\"self\"",
                "<https://my-server.dev/api/v1/users?after=asdf123&limit=25>; rel=\"next\""
            };
            var links = LinkHeaderParser.Parse(headerValues);

            links.Count().Should().Be(2);

            links.ElementAt(0).Target.Should().Be("https://my-server.dev/api/v1/users?limit=25");
            links.ElementAt(0).Relation.Should().Be("self");

            links.ElementAt(1).Target.Should().Be("https://my-server.dev/api/v1/users?after=asdf123&limit=25");
            links.ElementAt(1).Relation.Should().Be("next");
        }

        [Fact]
        public void ParseMultipleLinksInSingleValue()
        {
            var headerValue = @"
<https://my-server.dev/api/v1/users?after=abc123>; rel=""next"",
  <https://my-server.dev/api/v1/users?after=xyz987>; rel=""self""";
            var links = LinkHeaderParser.Parse(headerValue);

            links.ElementAt(0).Target.Should().Be("https://my-server.dev/api/v1/users?after=abc123");
            links.ElementAt(0).Relation.Should().Be("next");

            links.ElementAt(1).Target.Should().Be("https://my-server.dev/api/v1/users?after=xyz987");
            links.ElementAt(1).Relation.Should().Be("self");
        }

        [Fact]
        public void IgnoreEmptyArgs()
        {
            var links = LinkHeaderParser.Parse();

            links.Count().Should().Be(0);
        }

        [Fact]
        public void IgnoreNullAndEmptyArgs()
        {
            var links = LinkHeaderParser.Parse(string.Empty, null);

            links.Count().Should().Be(0);
        }

        [Fact]
        public void IgnoreEmptyValues()
        {
            var headerValues = new List<string>()
            {
                "",
                string.Empty,
                null,
                "<https://foo.bar>; rel=\"self\""
            };
            var links = LinkHeaderParser.Parse(headerValues);

            links.Count().Should().Be(1);
            links.Single().Target.Should().Be("https://foo.bar");
            links.Single().Relation.Should().Be("self");
        }

        [Fact]
        public void IgnoreBadLinks()
        {
            var headerValues = new List<string>()
            {
                "barbaz",
                "nope!",
                "   ",
                "<https://foo.bar>; rel=\"prev\""
            };
            var links = LinkHeaderParser.Parse(headerValues);

            links.Count().Should().Be(1);
            links.Single().Target.Should().Be("https://foo.bar");
            links.Single().Relation.Should().Be("prev");
        }

        [Fact]
        public void IgnoreBadInlineLinks()
        {
            var headerValue = @"
<https://my-server.dev/api/v1/users?after=abc123>; rel=""next"",,
  definitelyinvalid!";
            var links = LinkHeaderParser.Parse(headerValue);

            links.Count().Should().Be(1);
            links.Single().Target.Should().Be("https://my-server.dev/api/v1/users?after=abc123");
        }

        [Fact]
        public void IgnoreBadInlineLinkValues()
        {
            var headerValue = @"<https://my-server.dev/api/v1/users?after=abc123>;
; foo=""bar""; rel=""next""";
            var links = LinkHeaderParser.Parse(headerValue);

            links.Count().Should().Be(1);
            links.Single().Target.Should().Be("https://my-server.dev/api/v1/users?after=abc123");
            links.Single().Relation.Should().Be("next");
        }
    }
}
