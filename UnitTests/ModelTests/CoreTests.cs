using CalculatorModel;

namespace UnitTests.ModelTests;

[TestClass]
public class CoreTests
{
    [TestMethod]
    public void EvaluateBinaryOperation()
    {
        CalculatorCore calc = new();
        calc.SetDisplayValue(1.5);
        calc.PushToMemory();
        calc.SetOperation((memory, display) => memory + display);
        calc.SetDisplayValue(2.5);
        Assert.AreEqual(4.0, calc.Evaluate());
    }

    [TestMethod]
    public void EvaluateUnaryOperation()
    {
        CalculatorCore calc = new();
        calc.SetDisplayValue(4);
        calc.SetOperation((memory, display) => Math.Sqrt(display));
        Assert.AreEqual(2, calc.Evaluate());
    }


    [TestMethod]
    public void ReturnNullForIllegalOp()
    {
        CalculatorCore calc = new();
        calc.SetDisplayValue(-5);
        calc.SetOperation((memory, display) => Math.Sqrt(display));
        Assert.IsNull(calc.Evaluate());
    }
}