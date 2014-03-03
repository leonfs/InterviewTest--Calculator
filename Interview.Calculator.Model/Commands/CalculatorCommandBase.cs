using System;

namespace Interview.Calculator.Model.Commands
{
    public abstract class CalculatorCommandBase : ICommand
    {
        private ICalculator _calculator;

        protected CalculatorCommandBase(ICalculator calculator, int number)
        {
            this.Calculator = calculator;
            this.Number = number;
        }

        protected ICalculator Calculator
        {
            get { return _calculator; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _calculator = value;
            }
        }

        public int Number { get; private set; }


        public abstract void Execute();
    }
}
