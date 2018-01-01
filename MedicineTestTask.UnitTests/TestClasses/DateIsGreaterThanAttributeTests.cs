using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MedicineTestTask.Attributes;

namespace MedicineTestTask.UnitTests.TestClasses
{
    [TestFixture]
    public class DateIsGreaterThanAttributeTests
    {
        private DateIsGreaterThanAttribute GetAttributeUnderTest(string etalonValue = null)
        {
            etalonValue = etalonValue ?? DateTime.Now.ToString();
            return new DateIsGreaterThanAttribute(etalonValue);
        }
        [Test]
        public void IsValid_WasPassedNotDateTimeParameter_ThrowException()
        {
            var attribute = GetAttributeUnderTest();
            var passedArgument = new object();
            Assert.Throws<ArgumentException>(() => attribute.IsValid(passedArgument));
        }
        [Test]
        public void IsValid_WasPassedValueLessThenEtalonOne_ReturnFalse()
        {
            var attribute = GetAttributeUnderTest("1999.01.01 11:11");
            var passedArgument = DateTime.Parse("1990.01.01 11:11");
            var result = attribute.IsValid(passedArgument);
            Assert.IsFalse(result);
        }
        [Test]
        public void IsValid_WasPassedValueGreaterThenEtalonOne_ReturnTrue()
        {
            var attribute = GetAttributeUnderTest("1999.01.01 11:11");
            var passedArgument = DateTime.Parse("2000.01.01 11:11");
            var result = attribute.IsValid(passedArgument);
            Assert.IsTrue(result);
        }
    }
}
