using CalculatorModel;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CalculatorModelTests
    {
        [TestMethod]
        public void EvaluateBinaryOperation()
        {
            Calculator calc = new();
            calc.SetDisplayValue(1.5);
            calc.SetOperation((display, memory) => display + memory);
            calc.SetDisplayValue(2.5);
            Assert.AreEqual(4.0, calc.Evaluate());
        }

        [TestMethod]
        public void EvaluateUnaryOperation()
        {
            Calculator calc = new();
            calc.SetDisplayValue(4);
            calc.SetOperation(display => Math.Sqrt(display));
            Assert.AreEqual(2, calc.Evaluate());
        }


        [TestMethod]
        public void ReturnNullForIllegalOp()
        {
            Calculator calc = new();
            calc.SetDisplayValue(-5);
            calc.SetOperation(val => Math.Sqrt(val));
            Assert.IsNull(calc.Evaluate());
        }

    }
}