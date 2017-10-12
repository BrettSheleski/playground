using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public abstract class BinaryAsyncOperation : AsyncOperationBase, IBinaryOperation
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
    }
}
