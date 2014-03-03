namespace Interview.Calculator.Model.Commands
{
    public class AddCommand : CalculatorCommandBase
    {

        public AddCommand(ICalculator calculator, int number) : base(calculator, number)
        {

        }
        
        public override void Execute()
        {
            Calculator.Add(Number);
        }
    }
}
