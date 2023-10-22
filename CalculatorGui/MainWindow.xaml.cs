using CalculatorModel;

namespace CalculatorGui;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        CalculatorViewModel calc = new(new Calculator(new CalculatorInput(), new CalculatorCore()));
        DataContext = calc;
        InitializeComponent();
    }
}