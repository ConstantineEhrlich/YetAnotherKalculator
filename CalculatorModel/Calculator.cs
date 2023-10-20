namespace CalculatorModel
{
    /// <inheritdoc/>
    public class Calculator : ICalculator
    {
        // Stores the operation. Default operation => return display value.
        private Func<double, double, double> _operation = (display, memory) => display;

        // Initialize both registers with zero
        private double _memory = 0;
        private double _display = 0;
        public double MemoryRegister => _memory;
        public double DisplayRegister => _display;


        public double? Evaluate()
        {
            double result;
            try
            {
                result = _operation(_display, _memory);
                // If the result is NaN, return null, else return the result
                return double.IsNaN(result) ? null : result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SetOperation(Func<double, double, double> operation)
        {
            _operation = operation;
        }


        public void SetOperation(Func<double, double> operation)
        {
            _operation = (display, memory) => operation(display);
        }

        public void SetDisplayValue(double value)
        {
            _memory = _display;
            _display = value;
        }
    }
}