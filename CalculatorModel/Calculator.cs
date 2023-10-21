using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorModel
{
    public class Calculator : ICalculator
    {
        private readonly Dictionary<char, Func<double, double, double>> _operationCodes = new()
        {
            { '+', (a, b) => a + b },
            { '-', (a, b) => a - b },
            { '/', (a, b) => a / b },
            { '*', (a, b) => a * b },
            { 'q', (a, b) => Math.Sqrt(b) },
        };

        private bool _repeatMode;
        private bool _error;
        private readonly ICalculatorInput _inputStack;
        private readonly ICalculatorCore _calc;


        /// <summary>
        /// Initializes a new calculator with a specified input size.
        /// </summary>
        /// <param name="inputSize">Input size (default = 8)</param>
        public Calculator(ICalculatorInput inputStack, ICalculatorCore calculatorCore)
        {
            _repeatMode = false;
            _error = false;
            _inputStack = inputStack;
            _calc = calculatorCore;
        }

        public double DisplayValue => _calc.DisplayRegister;

        public bool Error { get => _error; }

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

            _repeatMode = false;
            _inputStack.Reset();

            double? interimValue = _calc.Evaluate();

            if (interimValue is null)
                _error = true;

            _calc.SetDisplayValue(interimValue ?? 0);
            _calc.PushToMemory();

            _calc.SetOperation(_operationCodes[opCode]);
        }

        
        public void Calculate()
        {
            double? val = _repeatMode ? _calc.Repeat() : _calc.Evaluate();
            if (val is null)
                _error = true;
            _calc.SetDisplayValue(val ?? 0);
            _repeatMode = true;
        }
        
        
        public void Reset()
        {
            _calc.Reset();
            _inputStack.Reset();
            _repeatMode = false;
            _error = false;
        }


        public void LearnOperation(char opCode, Func<double, double, double> operation)
        {
            _operationCodes[opCode] = operation;
        }
    }
}
