using CalculatorModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ModelTests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void GetZeroWhenNoAction()
        {
            CalculatorInput input = new(5);
            Assert.AreEqual(0, input.Value);
        }


        [TestMethod]
        public void EnterZeros()
        {
            CalculatorInput input = new(5);
            input.AddDigit(0);
            input.AddDigit(0);
            input.AddDigit(1);
            input.AddDigit(2);
            Assert.AreEqual(12, input.Value);
        }

        [TestMethod]
        public void EnterInteger()
        {
            CalculatorInput input = new(5);
            input.AddDigit(1);
            input.AddDigit(2);
            input.AddDigit(3);
            Assert.AreEqual(123.0, input.Value);

        }

        [TestMethod]
        public void EnterDecimal()
        {
            CalculatorInput input = new(5);
            input.AddDigit(1);
            input.AddDigit(2);
            input.AddDigit(3);
            input.SetDecimalPoint();
            input.AddDigit(4);
            input.AddDigit(5);
            Assert.AreEqual(123.45, input.Value);
        }

        [TestMethod]
        public void EnterZeroDecimal()
        {
            CalculatorInput input = new(5);
            input.AddDigit(0);
            input.SetDecimalPoint();
            input.AddDigit(0);
            input.AddDigit(0);
            input.AddDigit(5);
            Assert.AreEqual(0.005, input.Value);
        }

        [TestMethod]
        public void EnterNoZeroDecimal()
        {
            CalculatorInput input = new(5);
            input.SetDecimalPoint();
            input.AddDigit(0);
            input.AddDigit(5);
            Assert.AreEqual(0.05, input.Value);
        }

        [TestMethod]
        public void IgnoreDigitAfterinputSize()
        {
            CalculatorInput input = new(5);
            input.AddDigit(1);
            input.AddDigit(2);
            input.AddDigit(3);
            input.AddDigit(4);
            input.AddDigit(5);
            input.AddDigit(6);
            Assert.AreEqual(12345.0, input.Value);
        }

        [TestMethod]
        public void IgnoreDigitAfterinputSizeDecimal()
        {
            CalculatorInput input = new(5);
            input.AddDigit(1);
            input.AddDigit(2);
            input.SetDecimalPoint();
            input.AddDigit(3);
            input.AddDigit(4);
            input.AddDigit(5);
            input.AddDigit(6);
            Assert.AreEqual(12.345, input.Value);
        }

        [TestMethod]
        public void EnterInegerWithRemoval()
        {
            CalculatorInput input = new(5);
            input.AddDigit(1);
            input.AddDigit(2);
            input.AddDigit(3);
            input.AddDigit(4);
            input.AddDigit(5);
            input.RemoveDigit();
            input.AddDigit(6);
            Assert.AreEqual(12346, input.Value);
        }

        [TestMethod]
        public void DecimalPointRemoval()
        {
            CalculatorInput input = new(5);
            input.AddDigit(1);
            input.AddDigit(2);
            input.AddDigit(3);
            input.AddDigit(4);
            input.AddDigit(5);
            input.SetDecimalPoint();
            input.RemoveDigit();
            input.RemoveDigit();
            input.AddDigit(6);
            Assert.AreEqual(12346, input.Value);
        }
    }
}
