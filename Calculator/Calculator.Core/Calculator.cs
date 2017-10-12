using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class Calculator : INotifyPropertyChanged
    {   
        private OperationResult _result;

        public event PropertyChangedEventHandler PropertyChanged;

        public OperationResult Result { get => _result; set { _result = value; OnPropertyChanged(); } }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public void Execute(IOperation operation)
        {
            this.Result = operation?.Execute();
        }
        
        public async Task ExecuteAsync(IOperation operation)
        {
            this.Result = await operation?.ExecuteAsync();
        }
    }
}
