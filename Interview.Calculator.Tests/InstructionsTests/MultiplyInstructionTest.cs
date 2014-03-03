using Interview.Calculator.Model.Instructions;
using NUnit.Framework;

namespace Interview.Calculator.Tests.InstructionsTests
{
    [TestFixture]
    public class MultiplyInstructionTest
    {

        [Test]
        public void Execute_AnythingByZero_ReturnsZero() // {Any Number} * 0 = 0
        {
            MultiplyInstruction multiplyInstruction = new MultiplyInstruction(3);

            int expectedOutput = 0;
            Assert.AreEqual(expectedOutput, multiplyInstruction.Execute(0));
        }
    }
}
