using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public class ClearOperation : OperationBase
    {
        public override OperationResult Execute()
        {
            return new OperationResult((double?)null);
        }
    }
}
