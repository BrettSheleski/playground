using calc = Calculator.Core;
using ops =  Calculator.Operations;
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

        private void On()
        {
            throw new NotImplementedException();
        }

        private void Execute()
        {
            this.Calculator.Execute();

            if (Calculator.Result.Succeeded)
            {
                this.DisplayText = Calculator.Result.Value.ToString();
            }
        }

        private void Plus()
        {
            throw new NotImplementedException();
        }

        private void Subtract()
        {
            throw new NotImplementedException();
        }

        private void Multiply()
        {
            throw new NotImplementedException();
        }

        private void Divide()
        {
            throw new NotImplementedException();
        }

        private void Percent()
        {
            PercentOperation.Operand = GetOperandValue();

            Calculator.Operation = PercentOperation;

            Execute();
        }

        private double GetOperandValue()
        {
            return double.Parse(this.DisplayText);
        }

        private void PlusMinus()
        {
            throw new NotImplementedException();
        }

        private void Off()
        {
            throw new NotImplementedException();
        }

        private void ClearEntry()
        {
            throw new NotImplementedException();
        }

        private void UserEntry(string value)
        {
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
    }
}
