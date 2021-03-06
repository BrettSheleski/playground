﻿using Calculator.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public abstract class OperationBase : IOperation
    {
        public abstract OperationResult Execute();

        public Task<OperationResult> ExecuteAsync()
        {
            return Task.FromResult(Execute());
        }
    }
}
