using CalculatorModel;

namespace CalculatorGui;

public class CalculatorViewModel : INotifyPropertyChanged
{
    private readonly ICalculator _calculator;

    public CalculatorViewModel(ICalculator calculator)
    {
        _calculator = calculator;
        EnterDigit = Command(digit => _calculator.EnterDigit(uint.Parse(digit?.ToString()!)));
        RemoveDigit = Command(_ => _calculator.RemoveDigit());
        EnterDecimalPoint = Command(_ => _calculator.EnterDecimalPoint());
        EnterOperation = Command(op => _calculator.EnterOperation(char.Parse(op?.ToString()!)));
        Calculate = Command(_ => _calculator.Calculate());
        ChangeSign = Command(_ => _calculator.ChangeSign());
        Reset = Command(_ => _calculator.Reset(), false);
    }

    public string Display
    {
        get => _calculator.Error ? "ERROR" : _calculator.DisplayValue.ToString();
        set { }
    }

    public bool Error => _calculator.Error;
    public double DisplayValue => _calculator.DisplayValue;

    public ICommand EnterDigit { get; init; }
    public ICommand RemoveDigit { get; init; }
    public ICommand EnterDecimalPoint { get; init; }
    public ICommand EnterOperation { get; init; }
    public ICommand Calculate { get; init; }
    public ICommand Reset { get; init; }
    public ICommand ChangeSign { get; init; }


    private ICommand Command(Action<object?> action, bool blockByError = true)
    {
        // Declare local function that invokes the action and sends notifications
        void act(object? obj)
        {
            action.Invoke(obj);
            OnPropertyChanged(nameof(Display));
        }

        return blockByError
            ? new RelayCommand(act, _ => !_calculator.Error)
            : new RelayCommand(act, null);
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}