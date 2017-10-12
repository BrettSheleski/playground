namespace Calculator.Core
{
    public class OperationResult
    {
        public OperationResult(double? value)
        {
            this.Value = value;
            Succeeded = true;
        }

        public OperationResult(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            Succeeded = false;
        }

        public double? Value { get; }

        public bool Succeeded { get; }

        public string ErrorMessage { get; }
    }
}
