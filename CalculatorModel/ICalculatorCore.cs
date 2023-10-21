﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorModel
{
    /// <summary>
    /// Represents simple calculator that stores two values, operation, and evaluates the operation
    /// </summary>
    public interface ICalculatorCore
    {
        /// <summary>
        /// Represents the memory register of the calculator.
        /// </summary>
        public double MemoryRegister { get; }


        /// <summary>
        /// Represents the display register of the calculator - shows the input value or the result of the calculation.
        /// </summary>
        public double DisplayRegister { get; }


        /// <summary>
        /// Represents the last used operand (the Display Register before Evaluation).
        /// </summary>
        public double LastOperand { get; }


        /// <summary>
        /// Sets the value of the Display Register.
        /// </summary>
        /// <param name="value">The value to input</param>
        void SetDisplayValue(double value);


        /// <summary>
        /// Pushes the value of the display register into the memory register
        /// </summary>
        public void PushToMemory();


        /// <summary>
        /// Sets the operation to evaluate
        /// </summary>
        /// <param name="operation">The delegate, that accepts two doubles and returns evaluated double</param>
        public void SetOperation(Func<double, double, double> operation);


        /// <summary>
        /// Evaluates the operation using Memory Register as first argument and Display Register as second argument.
        /// If the operation is not set, returns the value of Display Register.
        /// </summary>
        /// <returns>The result of the operation, or null, if the operation failed</returns>
        public double? Evaluate();


        /// <summary>
        /// Repeats the last Evaluate operation, using DisplayRegister as first argument and LastOperand as second argument.
        /// If the operation is not set, returns the value of the Display Register.
        /// </summary>
        /// <returns></returns>
        public double? Repeat();


        /// <summary>
        /// Resets the calculator state.
        /// </summary>
        public void Reset();

    }
}
