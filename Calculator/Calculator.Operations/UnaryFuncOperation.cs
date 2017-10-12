using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    public class UnaryFuncOperation : OperationBase, IUnaryOperation
    {
        public delegate OperationResult OperationDelegate(double d);
        public delegate double OperationDelegateDouble(double d);
        public delegate double? OperationDelegateNullableDouble(double d);

        public UnaryFuncOperation(OperationDelegateDouble func) : this(d => new OperationResult(func(d))) { }
        public UnaryFuncOperation(OperationDelegateNullableDouble func) : this(d => new OperationResult(func(d))) { }

        public UnaryFuncOperation(OperationDelegate func)
        {
            this.Func = func;
        }

        public double Operand { get; set; }
        public OperationDelegate Func { get; }

        public override OperationResult Execute()
        {
            return this.Func(Operand);
        }
    }
}
