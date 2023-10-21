namespace CalculatorModel
{
    public class CalculatorCore : ICalculatorCore
    {
        // Stores the operation
        private Func<double, double, double>? _operation = null;

        // Initialize both registers with zero
        private double _memory = 0.0;
        private double _display = 0.0;
        private double _last = 0.0;

        public double MemoryRegister => _memory;
        public double DisplayRegister => _display;

        public double LastOperand => _last;

        public double? Evaluate()
        {
            _last = _display;
            return EvaluateOp(_operation, _memory, _display);
        }

        public double? Repeat() => EvaluateOp(_operation, _display, _last);

        private static double? EvaluateOp(Func<double,double,double>? op, double arg1, double arg2)
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


        public void SetOperation(Func<double, double, double> operation)
        {
            _operation = operation;
        }


        public void SetDisplayValue(double value)
        {
            _display = value;
        }


        public void PushToMemory()
        {
            _memory = _display;
        }

        public void Reset()
        {
            _operation = null;
            _memory = 0.0;
            _display = 0.0;
        }

        
    }
}