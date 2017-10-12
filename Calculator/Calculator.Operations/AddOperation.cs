using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    public class AddOperation : BinaryOperation
    {
        public override OperationResult Execute()
        {
            return new OperationResult(Operand1 + Operand2);
        }
    }
}