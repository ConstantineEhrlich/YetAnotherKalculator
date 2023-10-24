namespace CalculatorModel;

/// <inheritdoc />
public class CalculatorInput : ICalculatorInput
{
    private readonly Stack<uint> _displayStack = new();
    private bool _decimalMode;

    /// <summary>
    ///     Creates a new calculator input stack. Default input size = 8.
    /// </summary>
    /// <param name="inputSize">Input size (default = 8)</param>
    public CalculatorInput(uint inputSize = 8)
    {
        InputSize = inputSize;
    }

    public uint DecimalPosition { get; private set; }

    public uint InputSize { get; }

    public double Value
    {
        get
        {
            double value = 0;
            uint[] stack = _displayStack.ToArray();

            // Calculate 
            for (int i = stack.Length - 1; i >= 0; i--)
                value = value * 10 + stack[i];

            // Apply decimal position
            value /= Math.Pow(10, DecimalPosition);

            return value;
        }
    }

    public void AddDigit(uint digit)
    {
        // Ignore anything larger than 9
        if (digit > 9)
            return;

        // Ignore entering zero while no other digits in the stack
        if (digit == 0 && _displayStack.Count == 0 && !_decimalMode)
            return;

        // If the stack reached the maximum, ignore the digit
        if (_displayStack.Count == InputSize)
            return;

        // If decimal mode is enabled, increase decimal position
        if (_decimalMode)
            DecimalPosition++;

        // Add the digit to the stack
        _displayStack.Push(digit);
    }


    public void RemoveDigit()
    {
        if (_displayStack.Count == 0)
            return;

        // If decimal mode is enabled, remove digits up to the decimal point
        if (_decimalMode)
        {
            if (DecimalPosition > 0)
            {
                DecimalPosition--;
            }
            else // there are no decimal digits -> disable decimal mode
            {
                _decimalMode = false;
                return;
            }
        }

        // Remove last digit from the input stack
        _displayStack.Pop();
    }


    public void SetDecimalPoint()
    {
        _decimalMode = true;
    }


    public void Reset()
    {
        _decimalMode = false;
        DecimalPosition = 0;
        _displayStack.Clear();
    }
}