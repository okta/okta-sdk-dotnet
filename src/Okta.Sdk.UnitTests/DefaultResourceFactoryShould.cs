using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultResourceFactoryShould
    {
        private readonly IReadOnlyDictionary<string, object> _data
            = new Dictionary<string, object>();

        [Fact]
        public void ThrowForTypeWithNoMatchingCtor()
        {
            var factory = new DefaultResourceFactory();

            Assert.Throws<MissingMethodException>(() => factory.Create<WithoutMatchingCtor>(_data));
        }

        [Fact]
        public void CreateConcreteTypeDirectly()
        {
            var factory = new DefaultResourceFactory();
            var result = factory.Create<TestConcrete>(_data);

            result.Should().NotBeNull();
            result.Should().BeOfType<TestConcrete>();
        }

        [Fact]
        public void CreateConcreteTypeFromInterface()
        {
            var factory = new DefaultResourceFactory();
            var result = factory.Create<ITestInterface>(_data);

            result.Should().NotBeNull();
            result.Should().BeOfType<TestConcrete>();
        }
    }

    public class WithoutMatchingCtor
    {
        // This type does not have a constructor that accepts IReadOnlyDictionary<string, object>

        public string Foo { get; set; }
    }

    public class TestConcrete : ITestInterface
    {
        public TestConcrete(IReadOnlyDictionary<string, object> data) { }

        public string Foo { get; set; }
    }

    public interface ITestInterface
    {
        string Foo { get; set; }
    }
}
