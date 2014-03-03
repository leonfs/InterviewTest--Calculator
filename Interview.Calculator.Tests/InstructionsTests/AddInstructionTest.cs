using Interview.Calculator.Model.Instructions;
using NUnit.Framework;

namespace Interview.Calculator.Tests.InstructionsTests
{
    [TestFixture]
    public class AddInstructionTest
    {

        [Test]
        public void Execute_PlusThreeToZero_ReturnsThree()
        {
            AddInstruction instruction = new AddInstruction(3);

            var expectedOutput = 3;
            Assert.AreEqual(expectedOutput, instruction.Execute(0));
        }


    }
}
