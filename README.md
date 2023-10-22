# YAK - Yet Another Kalculator
YAK is a simple graphical calculator for Windows, built on .Net 6 using WPF.

### Summary
The purpose of the project is to demonstrate a basic implementation of the MVVM pattern:
- The **Model** is implemented in the CalculatorModel project. It's responsible for the core functionality of the calculator.
- The **View Model** and **View** are implemented in the CalculatorGui project, which is responsible for the connection between the user interface and core functionality.

### Structure
#### CalculatorModel
- `ICalculatorCore.cs` - interface responsible for storing values and operation in the calculator's memory and evaluating the result. This interface is implemented in `CalculatorCore.cs` class.
- `ICalculatorInput.cs` - interface responsible for handling user's input (adding and removing digits and decimal point), and parsing the input into a value. Implemented in `CalculatorInput.cs` class.
- `ICalculator.cs` - this interface represents the functionality that may be consumed by the user:
    - Properties `DisplayValue` and `Error` to represent calculator's state
    - Methods `EnterDigit()`, `RemoveDigit()`, `EnterDecimalPoint()` to handle the input
    - Methods `EnterOperation()`, `Calculate()` and `Reset()` for processing the input
- `Calculator.cs` - implements the ICalculator interface, combining the implementations of the Core and Input interfaces.

#### CalculatorGui
- `MainWindow.xaml` - represents the View, contains the GUI layout and controls (buttons for input and TextBox for output).
- `CalculatorViewModel.cs` - represents the View Model, connects between the View and the Model (ICalculator interface).  


### Demo
https://github.com/ConstantineEhrlich/YetAnotherKalculator/assets/45981312/2ce5488c-98c9-4acd-a238-7ede8e20c88f

