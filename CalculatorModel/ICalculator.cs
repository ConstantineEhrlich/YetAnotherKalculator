using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorModel
{
    /// <summary>
    /// Represents simple calculator that stores two values, operation, and evaluates it
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Holds the second argument (initially zero)
        /// </summary>
        public double MemoryRegister { get; }


        /// <summary>
        /// Holds the first argument (the one being evaluated)
        /// </summary>
        public double DisplayRegister { get; }


        /// <summary>
        /// Sets the value in the Display Register
        /// </summary>
        /// <param name="value">The value to set</param>
        public void SetDisplayValue(double value);


        /// <summary>
        /// Sets binary operation to evaluate
        /// </summary>
        /// <param name="operation">The delegate, that accepts two doubles and returns evaluated double</param>
        public void SetOperation(Func<double, double, double> operation);


        /// <summary>
        /// Sets unary operation to evaluate
        /// </summary>
        /// <param name="operation">The delegate, that accepts double and returns evaluated double</param>
        public void SetOperation(Func<double, double> operation);



        /// <summary>
        /// Evaluates the operation and returns the result
        /// </summary>
        /// <returns>The result of the operation, or null, if the operation failed</returns>
        public double? Evaluate();
    }
}
