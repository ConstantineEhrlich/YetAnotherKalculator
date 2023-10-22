namespace CalculatorGui;
// Source:
// https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern#relaying-command-logic

public class RelayCommand : ICommand
{
    private readonly Predicate<object?>? _canExecute;
    private readonly Action<object?> _execute;


    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }


    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }


    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute.Invoke(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }
}