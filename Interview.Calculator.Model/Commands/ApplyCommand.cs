namespace Interview.Calculator.Model.Commands
{
    public class ApplyCommand : CalculatorCommandBase
    {

        public ApplyCommand(ICalculator calculator, int number) : base(calculator, number)
        {
        }

        public override void Execute()
        {
            Calculator.Apply(Number);
        }

    }
}
