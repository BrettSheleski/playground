namespace Calculator.Core
{
    public interface IBinaryOperation : IOperation
    {
        double Operand1 { get; set; }
        double Operand2 { get; set; }
    }
}
