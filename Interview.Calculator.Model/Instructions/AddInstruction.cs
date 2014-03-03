namespace Interview.Calculator.Model.Instructions
{
    public class AddInstruction : IInstruction
    {
        private readonly int _number;

        public AddInstruction(int number)
        {
            this._number = number;
        }

        public int Execute(int seed)
        {
            return seed + _number;
        }
    }
}
