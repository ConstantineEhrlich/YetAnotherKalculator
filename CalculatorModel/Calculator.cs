namespace CalculatorModel;

public class Calculator : ICalculator
{
    private readonly ICalculatorCore _calc;
    private readonly ICalculatorInput _inputStack;

    private readonly Dictionary<char, Func<double, double, double>> _operationCodes = new()
    {
        { '+', (a, b) => a + b },
        { '-', (a, b) => a - b },
        { '/', (a, b) => a / b },
        { '*', (a, b) => a * b },
        { 'q', (a, b) => Math.Sqrt(b) }
    };

    private bool _repeatMode;


    /// <summary>
    ///     Initializes a new calculator.
    /// </summary>
    public Calculator(ICalculatorInput inputStack, ICalculatorCore calculatorCore)
    {
        _repeatMode = false;
        Error = false;
        _inputStack = inputStack;
        _calc = calculatorCore;
    }

    public double DisplayValue => _calc.DisplayRegister;

    public bool Error { get; private set; }

    public void EnterDigit(uint digit)
    {
        _repeatMode = false;
        _inputStack.AddDigit(digit);
        _calc.SetDisplayValue(_inputStack.Value);
    }


    public void RemoveDigit()
    {
        _inputStack.RemoveDigit();
        _calc.SetDisplayValue(_inputStack.Value);
    }


    public void EnterDecimalPoint()
    {
        _inputStack.SetDecimalPoint();
        _calc.SetDisplayValue(_inputStack.Value);
    }


    public void EnterOperation(char opCode)
    {
        if (!_operationCodes.ContainsKey(opCode))
            return;

        _inputStack.Reset();


        //double? interimValue = _repeatMode ? 0 : _calc.Evaluate();
        double? interimValue;

        if (_repeatMode)
        {
            _calc.PushToMemory();
            interimValue = _calc.DisplayRegister;
        }
        else
        {
            interimValue = _calc.Evaluate();
        }

        _repeatMode = false;

        if (interimValue is null)
            Error = true;

        _calc.SetDisplayValue(interimValue ?? 0);
        _calc.PushToMemory();

        _calc.SetOperation(_operationCodes[opCode]);
    }


    public void Calculate()
    {
        _inputStack.Reset();
        double? val = _repeatMode ? _calc.Repeat() : _calc.Evaluate();
        if (val is null)
            Error = true;
        _calc.SetDisplayValue(val ?? 0);
        _repeatMode = true;
    }


    public void Reset()
    {
        _calc.Reset();
        _inputStack.Reset();
        _repeatMode = false;
        Error = false;
    }


    public void LearnOperation(char opCode, Func<double, double, double> operation)
    {
        _operationCodes[opCode] = operation;
    }


    public void ChangeSign()
    {
        _calc.SetDisplayValue(DisplayValue * -1);
    }
}