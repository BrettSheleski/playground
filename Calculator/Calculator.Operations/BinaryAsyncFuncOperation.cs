using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core;

namespace Calculator.Operations
{
    public class BinaryAsyncFuncOperation : BinaryAsyncOperation
    {
        public BinaryAsyncFuncOperation(Func<double, double, Task<OperationResult>> func)
        {
            this.Func = func;
        }

        public Func<double, double, Task<OperationResult>> Func { get; }

        public override Task<OperationResult> ExecuteAsync()
        {
            return Func(Operand1, Operand2);
        }
    }
}
