using calc = Calculator.Core;
using ops = Calculator.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.WinForms
{
    public partial class CalculatorWindow : Form
    {
        public CalculatorWindow()
        {
            InitializeComponent();

            ClearEntryButton.Click+=
        }

        calc.IUnaryOperation PercentOperation { get; } = new ops.UnaryFuncOperation(d => d / 100.0);
        calc.IOperation OnOperation { get; } = new ops.ClearOperation();
        calc.IUnaryOperation PlusMinusOperation { get; } = new ops.UnaryFuncOperation(d => d * -1);
        calc.IOperation OffOperation { get { return OnOperation; } }
        calc.IBinaryOperation DivideOperation { get; } = new ops.BinaryFuncOperation((a, b) => a / b);
        calc.IBinaryOperation MultiplyOperation { get; } = new ops.BinaryFuncOperation((a, b) => a * b);
        calc.IBinaryOperation SubtractOperation { get; } = new ops.BinaryFuncOperation((a, b) => a - b);
        calc.IBinaryOperation PlusOperation { get; } = new ops.BinaryFuncOperation((a, b) => a + b);
    }
}
