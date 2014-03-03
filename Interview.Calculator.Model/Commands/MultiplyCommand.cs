namespace Interview.Calculator.Model.Commands
{
    public class MultiplyCommand : CalculatorCommandBase
    {
        public MultiplyCommand(ICalculator calculator, int number) : base(calculator, number)
        {
        }

        public override void Execute()
        {
            Calculator.Multiply(Number);
        }
    }
}
