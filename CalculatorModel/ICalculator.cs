namespace CalculatorModel
{
    public interface ICalculator
    {
        double DisplayValue { get; }
        bool Error { get; }

        void Calculate();
        void EnterDecimalPoint();
        void EnterDigit(uint digit);
        void EnterOperation(char opCode);
        void RemoveDigit();
        void Reset();
    }
}