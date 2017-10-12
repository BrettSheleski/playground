using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    public class BinaryFuncOperation : BinaryOperation
    {
        public BinaryFuncOperation(Func<double, double, OperationResult> func)
        {
            this.Func = func;
        }

        public BinaryFuncOperation(Func<double, double, double?> func) : this((a, b) => new OperationResult(func(a, b))) { }

        public BinaryFuncOperation(Func<double, double, double> func) : this((a, b) => new OperationResult(func(a, b))) { }

        public Func<double, double, OperationResult> Func { get; }

        public override OperationResult Execute()
        {
            return this.Func(Operand1, Operand2);
        }
    }
}
