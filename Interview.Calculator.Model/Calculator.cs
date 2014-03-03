using System;
using System.Collections.Generic;
using System.Linq;
using Interview.Calculator.Model.Instructions;

namespace Interview.Calculator.Model
{
    

    public class Calculator : ICalculator
    {
        private readonly List<IInstruction> _instructions;
        private int _result;

        public Calculator()
        {
            this._instructions = new List<IInstruction>();
        }

        public void Apply(int i)
        {
            _result = _instructions.Aggregate(i, (current, instruction) => instruction.Execute(current));
        }

        public void Add(int i)
        {
            this.AddInstruction(new AddInstruction(i));
        }

        public void Multiply(int i)
        {
            this.AddInstruction(new MultiplyInstruction(i));
        }

        public int Result()
        {
            return _result;
        }

        public void AddInstruction(IInstruction instruction)
        {
            if (instruction == null)
            {
                throw new ArgumentNullException("instruction");
            }

            this._instructions.Add(instruction);
        }
    }

    
}
