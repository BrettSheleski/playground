using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calculator.Core;

namespace Calculator.Operations
{
    public class AddAsyncOperation : BinaryAsyncOperation
    {
        public override Task<OperationResult> ExecuteAsync()
        {
            return Task.Run<OperationResult>(() => new OperationResult(Operand1 + Operand2));
        }
    }
}
