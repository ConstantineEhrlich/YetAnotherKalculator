using CalculatorModel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorMV
{
    public class CalculatorModelView : INotifyPropertyChanged
    {
        private readonly ICalculator _calculator;

        public bool Error => _calculator.Error;
        public double DisplayValue => _calculator.DisplayValue;

        public ICommand EnterDigit { get; init; }
        public ICommand RemoveDigit { get; init; }
        public ICommand EnterDecimalPoint { get; init; }
        public ICommand EnterOperation { get; init; }
        public ICommand Calculate { get; init; }

        public CalculatorModelView(ICalculator calculator)
        {
            _calculator = calculator;
            EnterDigit = Command(digit => _calculator.EnterDigit((uint)digit!));
            RemoveDigit = Command(_ => _calculator.RemoveDigit());
            EnterDecimalPoint = Command(_ => _calculator.EnterDecimalPoint());
            EnterOperation = Command(op => _calculator.EnterOperation((char)op!));
            Calculate = Command(_ => _calculator.Calculate());

        }


        private ICommand Command(Action<object?> action)
        {
            // Declare local function that invokes the action and sends notifications
            void act(object? obj)
            {
                action.Invoke(obj);
                OnPropertyChanged(nameof(DisplayValue));
                OnPropertyChanged(nameof(Error));
            }

            return new RelayCommand(act, _ => !_calculator.Error);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        

    }
}
