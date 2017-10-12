namespace Calculator.Core
{
    public interface IUnaryOperation : IOperation
    {
        double Operand { get; set; }
    }
}
