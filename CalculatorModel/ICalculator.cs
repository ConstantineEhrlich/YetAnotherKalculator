namespace CalculatorModel;

public interface ICalculator
{
    /// <summary>
    ///     Represents calculator display value
    /// </summary>
    double DisplayValue { get; }


    /// <summary>
    ///     Represents error state. Set to True if last evaluation returned null (resulted in error).
    /// </summary>
    bool Error { get; }


    /// <summary>
    ///     Performs the calculation and puts the result in the display register
    /// </summary>
    void Calculate();


    /// <summary>
    ///     Sets decimal point
    /// </summary>
    void EnterDecimalPoint();


    /// <summary>
    ///     Adds a digit to the input stack and updates the display value
    /// </summary>
    void EnterDigit(uint digit);


    /// <summary>
    ///     Learns a new operation
    /// </summary>
    /// <param name="opCode">Operation code character</param>
    /// <param name="operation">The delegate, that accepts two doubles and returns evaluated double</param>
    void LearnOperation(char opCode, Func<double, double, double> operation);


    /// <summary>
    ///     Accept the input and set the operation to execute
    /// </summary>
    /// <param name="opCode">Operation code</param>
    void EnterOperation(char opCode);


    /// <summary>
    ///     Removes last entered digit or the decimal point
    /// </summary>
    void RemoveDigit();


    /// <summary>
    ///     Resets the calculator state
    /// </summary>
    void Reset();
}