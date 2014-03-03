namespace Interview.Calculator.Model.Instructions
{
    public class MultiplyInstruction : IInstruction
    {
        private readonly int _number;

        public MultiplyInstruction(int number)
        {
            this._number = number;
        }

        public int Execute(int seed)
        {
            return this._number * seed;
        }
    }
}
