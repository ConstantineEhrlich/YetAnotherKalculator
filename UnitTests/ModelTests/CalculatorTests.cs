﻿using CalculatorModel;

namespace UnitTests.ModelTests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void TestOneDigitCalc()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterDigit(2);
        calc.EnterOperation('+');
        calc.EnterDigit(3);
        calc.Calculate();
        Assert.AreEqual(5, calc.DisplayValue);
    }

    [TestMethod]
    public void TestMoreThanOneDigit()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterDigit(2);
        calc.EnterDigit(5);
        calc.EnterOperation('*');
        calc.EnterDigit(1);
        calc.EnterDigit(0);
        calc.Calculate();
        Assert.AreEqual(250, calc.DisplayValue);
    }

    [TestMethod]
    public void TestDecimals()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterDigit(2);
        calc.EnterDecimalPoint();
        calc.EnterDigit(3);
        calc.EnterDigit(5);
        calc.EnterOperation('-');
        calc.EnterDecimalPoint();
        calc.EnterDigit(3);
        calc.EnterDigit(5);
        calc.Calculate();
        Assert.AreEqual(2.0, calc.DisplayValue);
    }

    [TestMethod]
    public void TestRepeatingCalc()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterDigit(5);
        calc.EnterOperation('+');
        calc.EnterDigit(1);
        calc.EnterDigit(0);
        calc.Calculate();
        calc.Calculate();
        calc.Calculate();
        Assert.AreEqual(35, calc.DisplayValue);
    }

    [TestMethod]
    public void TestChainOp()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterDigit(1);
        calc.EnterDigit(0);
        calc.EnterOperation('+');
        calc.EnterDigit(4);
        calc.EnterOperation('-');
        calc.EnterDigit(2);
        calc.EnterOperation('*');
        Assert.AreEqual(12, calc.DisplayValue);
    }


    [TestMethod]
    public void TestChainRepeating()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterDigit(1);
        calc.EnterDigit(0);
        calc.EnterOperation('+');
        calc.EnterDigit(4);
        calc.EnterOperation('-');
        calc.EnterDigit(2);
        calc.Calculate();
        calc.Calculate();
        Assert.AreEqual(10, calc.DisplayValue);
    }

    [TestMethod]
    public void TestError()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.EnterOperation('-');
        calc.EnterDigit(9);
        calc.EnterOperation('q');
        calc.Calculate();
        Assert.IsTrue(calc.Error);
    }


    [TestMethod]
    public void TestLearnOp()
    {
        Calculator calc = new(new CalculatorInput(), new CalculatorCore());
        calc.LearnOperation('2', (a, b) => Math.Pow(b, 2));
        calc.EnterDigit(1);
        calc.EnterDigit(8);
        calc.EnterOperation('2');
        calc.Calculate();
        Assert.AreEqual(324, calc.DisplayValue);
    }
}