using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public interface IOperation
    {
        OperationResult Execute();

        Task<OperationResult> ExecuteAsync();
    }
}
