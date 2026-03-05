// <copyright file="ClientUtilsShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    public class ClientUtilsShould
    {
        #region SanitizeFilename

        // These tests also serve as a regression guard: they verify the new
        // LastIndexOfAny-based implementation produces identical output to the
        // original Regex.Match(@".*[/\\](.*)$") implementation for every edge case.

        [Theory]
        [InlineData("path/to/file.txt", "file.txt")]
        [InlineData("file.txt", "file.txt")]
        [InlineData("", "")]
        public void SanitizeFilename_WithUnixSeparator(string input, string expected)
        {
            ClientUtils.SanitizeFilename(input).Should().Be(expected);
        }

        [Fact]
        public void SanitizeFilename_WithWindowsBackslashPath_ReturnsFilenameOnly()
        {
            var result = ClientUtils.SanitizeFilename(@"path\to\file.txt");
            result.Should().Be("file.txt");
        }

        [Fact]
        public void SanitizeFilename_WithMixedSeparators_ReturnsSegmentAfterLastSeparator()
        {
            // Last separator is '\', so result is everything after it
            var result = ClientUtils.SanitizeFilename(@"path/to\file.txt");
            result.Should().Be("file.txt");
        }

        [Fact]
        public void SanitizeFilename_WithNoSeparator_ReturnsOriginalFilename()
        {
            var result = ClientUtils.SanitizeFilename("filename.txt");
            result.Should().Be("filename.txt");
        }

        [Fact]
        public void SanitizeFilename_WithTrailingSeparator_ReturnsEmptyString()
        {
            // e.g. a header value that ends with /
            var result = ClientUtils.SanitizeFilename("path/to/");
            result.Should().Be(string.Empty);
        }

        [Fact]
        public void SanitizeFilename_WithConsecutiveSeparators_ReturnsSegmentAfterLastSeparator()
        {
            var result = ClientUtils.SanitizeFilename("path//file.txt");
            result.Should().Be("file.txt");
        }

        [Fact]
        public void SanitizeFilename_WithOnlyASeparator_ReturnsEmptyString()
        {
            ClientUtils.SanitizeFilename("/").Should().Be(string.Empty);
            ClientUtils.SanitizeFilename(@"\").Should().Be(string.Empty);
        }

        #endregion

        #region ParameterToMultiMap

        [Fact]
        public void ParameterToMultiMap_WithMultiCollectionFormat_AddsEachItemSeparately()
        {
            var values = new List<string> { "a", "b", "c" };

            var result = ClientUtils.ParameterToMultiMap("multi", "ids", values);

            result["ids"].Should().BeEquivalentTo(new[] { "a", "b", "c" });
        }

        [Fact]
        public void ParameterToMultiMap_WithDeepObjectFormat_UsesKeyBracketNotation()
        {
            var dict = new Dictionary<string, string>
            {
                { "firstName", "John" },
                { "lastName",  "Doe"  },
            };

            var result = ClientUtils.ParameterToMultiMap("deepObject", "profile", dict);

            result["profile[firstName]"].Should().ContainSingle().Which.Should().Be("John");
            result["profile[lastName]"].Should().ContainSingle().Which.Should().Be("Doe");
        }

        [Fact]
        public void ParameterToMultiMap_WithDictionaryAndNonDeepObjectFormat_UsesKeyDirectly()
        {
            var dict = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var result = ClientUtils.ParameterToMultiMap("csv", "ignored", dict);

            result["key1"].Should().ContainSingle().Which.Should().Be("value1");
            result["key2"].Should().ContainSingle().Which.Should().Be("value2");
        }

        [Fact]
        public void ParameterToMultiMap_WithSingleStringValue_AddsSingleEntry()
        {
            var result = ClientUtils.ParameterToMultiMap("csv", "status", "active");

            result["status"].Should().ContainSingle().Which.Should().Be("active");
        }

        [Fact]
        public void ParameterToMultiMap_WithNonMultiFormatAndCollection_JoinsIntoSingleEntry()
        {
            var values = new List<string> { "a", "b", "c" };

            var result = ClientUtils.ParameterToMultiMap("csv", "ids", values);

            // Non-multi falls through to ParameterToString which joins with ","
            result["ids"].Should().ContainSingle().Which.Should().Be("a,b,c");
        }

        #endregion

        #region ParameterToString

        [Fact]
        public void ParameterToString_WithDateTime_ReturnsIso8601Format()
        {
            var dt = new DateTime(2024, 6, 15, 13, 45, 30, DateTimeKind.Utc);

            var result = ClientUtils.ParameterToString(dt);

            // Default GlobalConfiguration uses "o" (round-trip) format
            result.Should().Contain("2024-06-15");
        }

        [Fact]
        public void ParameterToString_WithDateTimeOffset_ReturnsIso8601Format()
        {
            var dto = new DateTimeOffset(2024, 6, 15, 13, 45, 30, TimeSpan.Zero);

            var result = ClientUtils.ParameterToString(dto);

            result.Should().Contain("2024-06-15");
        }

        [Fact]
        public void ParameterToString_WithBoolTrue_ReturnsLowercaseTrue()
        {
            ClientUtils.ParameterToString(true).Should().Be("true");
        }

        [Fact]
        public void ParameterToString_WithBoolFalse_ReturnsLowercaseFalse()
        {
            ClientUtils.ParameterToString(false).Should().Be("false");
        }

        [Fact]
        public void ParameterToString_WithStringCollection_ReturnsCommaSeparated()
        {
            var list = new List<string> { "a", "b", "c" };

            var result = ClientUtils.ParameterToString(list);

            result.Should().Be("a,b,c");
        }

        [Fact]
        public void ParameterToString_WithInteger_ReturnsStringRepresentation()
        {
            ClientUtils.ParameterToString(42).Should().Be("42");
        }

        [Fact]
        public void ParameterToString_WithPlainString_ReturnsSameString()
        {
            ClientUtils.ParameterToString("hello").Should().Be("hello");
        }

        #endregion

        #region Base64Encode

        [Fact]
        public void Base64Encode_WithKnownString_ReturnsCorrectBase64()
        {
            // "Okta" → "T2t0YQ==" in base64
            var result = ClientUtils.Base64Encode("Okta");

            result.Should().Be(Convert.ToBase64String(Encoding.UTF8.GetBytes("Okta")));
        }

        [Fact]
        public void Base64Encode_WithEmptyString_ReturnsEmptyBase64()
        {
            var result = ClientUtils.Base64Encode(string.Empty);

            result.Should().Be(string.Empty);
        }

        [Fact]
        public void Base64Encode_WithUnicodeString_ReturnsUtf8Base64()
        {
            const string input = "こんにちは"; // "Hello" in Japanese
            var expected = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

            ClientUtils.Base64Encode(input).Should().Be(expected);
        }

        #endregion

        #region ReadAsBytes

        [Fact]
        public void ReadAsBytes_WithKnownStream_ReturnsCorrectByteArray()
        {
            var expected = new byte[] { 1, 2, 3, 4, 5 };
            using var stream = new MemoryStream(expected);

            var result = ClientUtils.ReadAsBytes(stream);

            result.Should().Equal(expected);
        }

        [Fact]
        public void ReadAsBytes_WithEmptyStream_ReturnsEmptyArray()
        {
            using var stream = new MemoryStream();

            var result = ClientUtils.ReadAsBytes(stream);

            result.Should().BeEmpty();
        }

        #endregion

        #region SelectHeaderContentType

        [Fact]
        public void SelectHeaderContentType_WithEmptyArray_ReturnsNull()
        {
            ClientUtils.SelectHeaderContentType(Array.Empty<string>()).Should().BeNull();
        }

        [Fact]
        public void SelectHeaderContentType_WithApplicationJson_ReturnsApplicationJson()
        {
            var types = new[] { "text/plain", "application/json", "application/xml" };

            ClientUtils.SelectHeaderContentType(types).Should().Be("application/json");
        }

        [Fact]
        public void SelectHeaderContentType_WithVendorJsonType_ReturnsVendorJsonType()
        {
            var types = new[] { "application/vnd.company+json", "text/plain" };

            ClientUtils.SelectHeaderContentType(types).Should().Be("application/vnd.company+json");
        }

        [Fact]
        public void SelectHeaderContentType_WithNoJsonType_ReturnsFirstElement()
        {
            var types = new[] { "text/plain", "application/xml" };

            ClientUtils.SelectHeaderContentType(types).Should().Be("text/plain");
        }

        #endregion

        #region SelectHeaderAccept

        [Fact]
        public void SelectHeaderAccept_WithEmptyArray_ReturnsNull()
        {
            ClientUtils.SelectHeaderAccept(Array.Empty<string>()).Should().BeNull();
        }

        [Fact]
        public void SelectHeaderAccept_WhenApplicationJsonPresent_ReturnsApplicationJson()
        {
            var accepts = new[] { "text/plain", "application/json" };

            ClientUtils.SelectHeaderAccept(accepts).Should().Be("application/json");
        }

        [Fact]
        public void SelectHeaderAccept_WhenApplicationJsonPresentInUpperCase_ReturnsApplicationJson()
        {
            var accepts = new[] { "APPLICATION/JSON", "text/plain" };

            ClientUtils.SelectHeaderAccept(accepts).Should().Be("application/json");
        }

        [Fact]
        public void SelectHeaderAccept_WithNoApplicationJson_ReturnsAllJoined()
        {
            var accepts = new[] { "text/plain", "application/xml" };

            ClientUtils.SelectHeaderAccept(accepts).Should().Be("text/plain,application/xml");
        }

        #endregion

        #region IsJsonMime

        [Theory]
        [InlineData(null,                                false)]
        [InlineData("",                                  false)]
        [InlineData("   ",                               false)]
        [InlineData("application/json",                  true)]
        [InlineData("application/json; charset=UTF8",    true)]
        [InlineData("APPLICATION/JSON",                  true)]
        [InlineData("application/vnd.company+json",      true)]
        [InlineData("application/json-patch+json",       true)]
        [InlineData("text/plain",                        false)]
        [InlineData("application/xml",                   false)]
        public void IsJsonMime_ReturnsExpectedResult(string mime, bool expected)
        {
            ClientUtils.IsJsonMime(mime).Should().Be(expected);
        }

        #endregion

        #region Parse (Web Links)

        [Fact]
        public void Parse_WithNullParams_ReturnsEmpty()
        {
            ClientUtils.Parse((string[])null).Should().BeEmpty();
        }

        [Fact]
        public void Parse_WithEmptyParams_ReturnsEmpty()
        {
            ClientUtils.Parse(Array.Empty<string>()).Should().BeEmpty();
        }

        [Fact]
        public void Parse_WithEmptyStringEntries_ReturnsEmpty()
        {
            ClientUtils.Parse("", "   ", null).Should().BeEmpty();
        }

        [Fact]
        public void Parse_WithValidLinkHeader_ReturnsParsedWebLink()
        {
            var header = @"<https://example.okta.com/api/v1/users?after=abc>; rel=""next""";

            var links = ClientUtils.Parse(header).ToList();

            links.Should().ContainSingle();
            links[0].Target.Should().Be("https://example.okta.com/api/v1/users?after=abc");
            links[0].Relation.Should().Be("next");
        }

        [Fact]
        public void Parse_WithLinkWithoutRelation_ReturnsWebLinkWithNullRelation()
        {
            var header = "<https://example.okta.com/api/v1/users?after=abc>; title=\"something\"";

            var links = ClientUtils.Parse(header).ToList();

            links.Should().ContainSingle();
            links[0].Target.Should().Be("https://example.okta.com/api/v1/users?after=abc");
            links[0].Relation.Should().BeNull();
        }

        [Fact]
        public void Parse_WithInvalidTarget_SkipsEntry()
        {
            // Target not wrapped in < >
            var header = @"https://example.okta.com/api/v1/users; rel=""next""";

            ClientUtils.Parse(header).Should().BeEmpty();
        }

        [Fact]
        public void Parse_WithOnlyOneSegment_SkipsEntry()
        {
            // No semicolon-separated relation segment
            var header = "<https://example.okta.com/api/v1/users>";

            ClientUtils.Parse(header).Should().BeEmpty();
        }

        [Fact]
        public void Parse_WithCommaSeparatedLinksInSingleHeader_ReturnsAllLinks()
        {
            var header = @"<https://example.okta.com/api/v1/users?before=abc>; rel=""prev"", <https://example.okta.com/api/v1/users?after=xyz>; rel=""next""";

            var links = ClientUtils.Parse(header).ToList();

            links.Should().HaveCount(2);
            links.Should().Contain(l => l.Relation == "prev" && l.Target.Contains("before=abc"));
            links.Should().Contain(l => l.Relation == "next" && l.Target.Contains("after=xyz"));
        }

        [Fact]
        public void Parse_WithMultipleHeaderValues_ReturnsAllLinks()
        {
            var header1 = @"<https://example.okta.com/api/v1/users?before=abc>; rel=""prev""";
            var header2 = @"<https://example.okta.com/api/v1/users?after=xyz>; rel=""next""";

            var links = ClientUtils.Parse(header1, header2).ToList();

            links.Should().HaveCount(2);
            links.Should().Contain(l => l.Relation == "prev");
            links.Should().Contain(l => l.Relation == "next");
        }

        [Fact]
        public void Parse_IEnumerableOverload_BehavesIdenticallyToParamsOverload()
        {
            var header = @"<https://example.okta.com/api/v1/users?after=abc>; rel=""next""";
            IEnumerable<string> enumerable = new[] { header };

            var result = ClientUtils.Parse(enumerable).ToList();

            result.Should().ContainSingle();
            result[0].Relation.Should().Be("next");
        }

        [Fact]
        public void Parse_WithNullIEnumerable_ReturnsEmpty()
        {
            ClientUtils.Parse((IEnumerable<string>)null).Should().BeEmpty();
        }

        #endregion

        #region EnsureTrailingSlash

        [Fact]
        public void EnsureTrailingSlash_WhenSlashAlreadyPresent_ReturnsSameString()
        {
            ClientUtils.EnsureTrailingSlash("https://example.okta.com/").Should().Be("https://example.okta.com/");
        }

        [Fact]
        public void EnsureTrailingSlash_WhenNoTrailingSlash_AppendsSlash()
        {
            ClientUtils.EnsureTrailingSlash("https://example.okta.com").Should().Be("https://example.okta.com/");
        }

        [Fact]
        public void EnsureTrailingSlash_WithNullUri_ThrowsArgumentNullException()
        {
            Action act = () => ClientUtils.EnsureTrailingSlash(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void EnsureTrailingSlash_WithEmptyString_ThrowsArgumentNullException()
        {
            Action act = () => ClientUtils.EnsureTrailingSlash(string.Empty);

            act.Should().Throw<ArgumentNullException>();
        }

        #endregion
    }
}
