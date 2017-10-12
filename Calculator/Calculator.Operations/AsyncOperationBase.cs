using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public abstract class AsyncOperationBase : IOperation
    {
        public OperationResult Execute()
        {
            return Task.Run(ExecuteAsync).Result;
        }

        public abstract Task<OperationResult> ExecuteAsync();
    }
}
