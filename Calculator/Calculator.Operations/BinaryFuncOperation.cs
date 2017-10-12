using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    public class BinaryFuncOperation : BinaryOperation
    {
        public delegate OperationResult OperationDelegate(double a, double b);
        public delegate double OperationDelegateDouble(double a, double b);
        public delegate double? OperationDelegateNullableDouble(double a, double b);

        public BinaryFuncOperation(OperationDelegate func)
        {
            this.Func = func;
        }

        public BinaryFuncOperation(OperationDelegateDouble func) : this((a, b) => new OperationResult(func(a, b))) { }

        public BinaryFuncOperation(OperationDelegateNullableDouble func) : this((a, b) => new OperationResult(func(a, b))) { }

        public OperationDelegate Func { get; }

        public override OperationResult Execute()
        {
            return this.Func(Operand1, Operand2);
        }
    }
}
