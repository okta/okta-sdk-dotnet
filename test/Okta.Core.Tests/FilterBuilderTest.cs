using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core;

namespace Okta.Core.Tests
{
    [TestClass]
    public class FilterBuilderTest
    {
        [TestMethod]
        public void TestEqualToString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").EqualTo("something");
            Assert.AreEqual("field eq \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestEqualToInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").EqualTo(1);
            Assert.AreEqual("field eq 1", filter.ToString());
        }

        [TestMethod]
        public void TestEqualToDate()
        {
            var filter = new FilterBuilder();
            filter.Where("field").EqualTo(new DateTime(2014,1,1));
            Assert.AreEqual("field eq \"2014-01-01T00:00:00.000Z\"", filter.ToString());
        }

        [TestMethod]
        public void TestEqualToBoolean()
        {
            var filter = new FilterBuilder();
            filter.Where("field").EqualTo(true);
            Assert.AreEqual("field eq true", filter.ToString());
        }

        [TestMethod]
        public void TestContainsString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").Contains("something");
            Assert.AreEqual("field co \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestContainsInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").Contains(1);
            Assert.AreEqual("field co 1", filter.ToString());
        }

        [TestMethod]
        public void TestStartsWithString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").StartsWith("something");
            Assert.AreEqual("field sw \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestStartsWithInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").StartsWith(1);
            Assert.AreEqual("field sw 1", filter.ToString());
        }

        /*
        [TestMethod]
        public void TestPresentString()
        {
            var filter = new FilterBuilder();
            filter.Present("something");

            // TODO: See if this is correct
            Assert.AreEqual("something pr", filter.ToString());
        }
         * */

        [TestMethod]
        public void TestGreaterThanString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").GreaterThan("something");
            Assert.AreEqual("field gt \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestGreaterThanInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").GreaterThan(1);
            Assert.AreEqual("field gt 1", filter.ToString());
        }

        [TestMethod]
        public void TestGreaterThanDate()
        {
            var filter = new FilterBuilder();
            filter.Where("field").GreaterThan(new DateTime(2014, 1, 1));
            Assert.AreEqual("field gt \"2014-01-01T00:00:00.000Z\"", filter.ToString());
        }

        [TestMethod]
        public void TestGreaterThanOrEqualString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").GreaterThanOrEqual("something");
            Assert.AreEqual("field ge \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestGreaterThanOrEqualInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").GreaterThanOrEqual(1);
            Assert.AreEqual("field ge 1", filter.ToString());
        }

        [TestMethod]
        public void TestGreaterThanOrEqualDate()
        {
            var filter = new FilterBuilder();
            filter.Where("field").GreaterThanOrEqual(new DateTime(2014, 1, 1));
            Assert.AreEqual("field ge \"2014-01-01T00:00:00.000Z\"", filter.ToString());
        }

        [TestMethod]
        public void TestLessThanString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").LessThan("something");
            Assert.AreEqual("field lt \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestLessThanInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").LessThan(1);
            Assert.AreEqual("field lt 1", filter.ToString());
        }

        [TestMethod]
        public void TestLessThanDate()
        {
            var filter = new FilterBuilder();
            filter.Where("field").LessThan(new DateTime(2014, 1, 1));
            Assert.AreEqual("field lt \"2014-01-01T00:00:00.000Z\"", filter.ToString());
        }

        [TestMethod]
        public void TestLessThanOrEqualString()
        {
            var filter = new FilterBuilder();
            filter.Where("field").LessThanOrEqual("something");
            Assert.AreEqual("field le \"something\"", filter.ToString());
        }

        [TestMethod]
        public void TestLessThanOrEqualInt()
        {
            var filter = new FilterBuilder();
            filter.Where("field").LessThanOrEqual(1);
            Assert.AreEqual("field le 1", filter.ToString());
        }

        [TestMethod]
        public void TestLessThanOrEqualDate()
        {
            var filter = new FilterBuilder();
            filter.Where("field").LessThanOrEqual(new DateTime(2014, 1, 1));
            Assert.AreEqual("field le \"2014-01-01T00:00:00.000Z\"", filter.ToString());
        }
    }
}
