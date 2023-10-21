using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorModel
{
    /// <summary>
    /// Represents calculator's input stack, that allows entering and removing digits and decimal point.
    /// </summary>
    public interface ICalculatorInput
    {
        /// <summary>
        /// Represents the position of the decimal point, counting from the right
        /// </summary>
        public uint DecimalPosition { get; }


        /// <summary>
        /// Represents the character count of the display
        /// </summary>
        public uint InputSize { get; }


        /// <summary>
        /// Represents the value of the calculator's display
        /// </summary>
        public double Value { get; }


        /// <summary>
        /// Adds a digit to the display stack
        /// </summary>
        /// <param name="digit">A digit between 0 and 9</param>
        void AddDigit(uint digit);


        /// <summary>
        /// Removes last entered digit from the display stack.
        /// The decimal point is considered a "digit", too.
        /// </summary>
        void RemoveDigit();


        /// <summary>
        /// Sets decimal mode.
        /// </summary>
        void SetDecimalPoint();


        /// <summary>
        /// Resets the input stack
        /// </summary>
        void Reset();
  
    }



}
