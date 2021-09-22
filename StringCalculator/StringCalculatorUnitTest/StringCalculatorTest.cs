using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;

namespace StringCalculatorUnitTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void InputNumbersIsEmpty()
        {
            Assert.AreEqual(0, Program.Add(""));
        }

        [TestMethod]
        public void InputNumbersAddition()
        {
            Assert.AreEqual(6, Program.Add("1,2,3"));
        }

        [TestMethod]
        public void InputNumbersWithNewLineBetweenNumbers()
        {
            Assert.AreEqual(6, Program.Add("1,2\n3"));
        }

        [TestMethod]
        public void InputWithDifferentDelimiters()
        {
            Assert.AreEqual(11, Program.Add("//;\n1;2\n3;5"));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnNegativeNumbers()
        {
            Assert.ThrowsException<Exception>(() => Program.Add("1,-2\n3,-5"));
        }
    }
}
