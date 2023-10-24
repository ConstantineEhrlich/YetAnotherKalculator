namespace CalculatorModel;

public class CalculatorCore : ICalculatorCore
{
    private Func<double, double, double>? _operation;

    public double MemoryRegister { get; private set; }

    public double DisplayRegister { get; private set; }

    public double LastOperand { get; private set; }

    public double? Evaluate()
    {
        LastOperand = DisplayRegister;
        return EvaluateOp(_operation, MemoryRegister, DisplayRegister);
    }

    public double? Repeat()
    {
        return EvaluateOp(_operation, DisplayRegister, LastOperand);
    }


    public void SetOperation(Func<double, double, double> operation)
    {
        _operation = operation;
    }


    public void SetDisplayValue(double value)
    {
        DisplayRegister = value;
    }


    public void PushToMemory()
    {
        MemoryRegister = DisplayRegister;
    }

    public void Reset()
    {
        _operation = null;
        MemoryRegister = 0.0;
        DisplayRegister = 0.0;
    }

    private static double? EvaluateOp(Func<double, double, double>? op, double arg1, double arg2)
    {
        if (op is null)
            return arg2;

        double result;
        try
        {
            result = op(arg1, arg2);
            // If the result is NaN, return null, else return the result
            return double.IsNaN(result) ? null : result;
        }
        catch (Exception)
        {
            return null;
        }
    }
}