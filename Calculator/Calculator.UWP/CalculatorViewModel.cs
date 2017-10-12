using calc = Calculator.Core;
using ops = Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.UWP
{
    public class CalculatorViewModel : ViewModelBase
    {
        public CalculatorViewModel()
        {
            this.Calculator = new calc.Calculator();

            this.UserEntryCommand = new Command<string>(UserEntry);

            ClearEntryCommand = new Command(ClearEntry);
            OffCommand = new Command(Off);
            PlusMinusCommand = new Command(PlusMinus);
            PercentCommand = new Command(Percent);
            DivideCommand = new Command(Divide);
            MultiplyCommand = new Command(Multiply);
            SubtractCommand = new Command(Subtract);
            PlusCommand = new Command(Plus);
            ExecuteCommand = new Command(Execute);
            OnCommand = new Command(On);
        }

        void SetOperation(calc.IBinaryOperation operation)
        {
            ExecutePendingOperation();
            
            if (!string.IsNullOrWhiteSpace(DisplayText))
            {
                if (operation == CurrentOperation)
                {
                    operation.Operand2 = GetOperandValue();
                }
                else
                {
                    operation.Operand1 = GetOperandValue();
                }
                
            }

            CurrentOperation = operation;

            this.ResetTextOnEntry = true;
        }

        void SetOperation(calc.IUnaryOperation operation)
        {
            ExecutePendingOperation();

            if (!string.IsNullOrWhiteSpace(DisplayText))
            {
                operation.Operand = GetOperandValue();
            }

            CurrentOperation = operation;

            this.ResetTextOnEntry = true;

            Execute();
        }

        void SetOperation(calc.IOperation operation)
        {
            ExecutePendingOperation();
            
            CurrentOperation = operation;

            this.ResetTextOnEntry = true;

            Execute();
        }

        private void On()
        {
            SetOperation(OnOperation);
        }

        calc.IOperation _previousOperation = null;

        private void Execute()
        {
            if (CurrentOperation != null)
            {
                if (CurrentOperation is calc.IBinaryOperation)
                {
                    ((calc.IBinaryOperation)CurrentOperation).Operand2 = GetOperandValue();
                }

                this.Calculator.Operation = CurrentOperation;

                this.Calculator.Execute();

                if (Calculator.Result.Succeeded)
                {
                    this.DisplayText = Calculator.Result.Value.ToString();
                }

                _previousOperation = CurrentOperation;
                CurrentOperation = null;
            }
        }

        void ExecutePendingOperation()
        {
            if (CurrentOperation != null)
            {
                Execute();
            }
        }

        private void Plus()
        {
            SetOperation(PlusOperation);
        }

        private void Subtract()
        {
            SetOperation(SubtractOperation);
        }

        private void Multiply()
        {
            SetOperation(MultiplyOperation);
        }

        private void Divide()
        {
            SetOperation(DivideOperation);
        }

        calc.IOperation _currentOperation;

        private void Percent()
        {
            SetOperation(PercentOperation);
            
        }

        private double GetOperandValue()
        {
            return double.Parse(this.DisplayText);
        }

        private void PlusMinus()
        {
            SetOperation(PlusMinusOperation);
        }

        private void Off()
        {
            SetOperation(OffOperation);
        }

        private void ClearEntry()
        {
            SetOperation(OnOperation);
        }

        private void UserEntry(string value)
        {
            if (ResetTextOnEntry)
            {
                ResetTextOnEntry = false;
                DisplayText = "";
            }

            DisplayText += value;
        }

        private string _displayText;

        public string DisplayText { get => _displayText; set { _displayText = value; OnPropertyChanged(); } }

        public calc.Calculator Calculator { get; }
        public Command<string> UserEntryCommand { get; }
        public Command ClearEntryCommand { get; }
        public Command OffCommand { get; }
        public Command PlusMinusCommand { get; }
        public Command PercentCommand { get; }
        public Command DivideCommand { get; }
        public Command MultiplyCommand { get; }
        public Command SubtractCommand { get; }
        public Command PlusCommand { get; }
        public Command ExecuteCommand { get; }
        public Command OnCommand { get; }

        calc.IUnaryOperation PercentOperation { get; } = new ops.UnaryFuncOperation(d => d / 100.0);
        calc.IOperation OnOperation { get; } = new ops.ClearOperation();
        calc.IUnaryOperation PlusMinusOperation { get; } = new ops.UnaryFuncOperation(d => d * -1);
        calc.IOperation OffOperation { get { return OnOperation; } }
        calc.IBinaryOperation DivideOperation { get; } = new ops.BinaryFuncOperation((a, b) => a / b);
        calc.IBinaryOperation MultiplyOperation { get; } = new ops.BinaryFuncOperation((a, b) => a * b);
        calc.IBinaryOperation SubtractOperation { get; } = new ops.BinaryFuncOperation((a, b) => a - b);
        calc.IBinaryOperation PlusOperation { get; } = new ops.BinaryFuncOperation((a, b) => a + b);


        public calc.IOperation CurrentOperation { get => _currentOperation; set => _currentOperation = value; }
        public bool ResetTextOnEntry { get; private set; }
    }
}
