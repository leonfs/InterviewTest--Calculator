using System;
using Interview.Calculator.Model.Instructions;
using NUnit.Framework;

namespace Interview.Calculator.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Model.Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Model.Calculator();
        }

        [Test]
        public void Apply_OneNoPreviousInstructions_ReturnOne() // 1 = 1
        {
            calculator.Apply(1);
            const int expectedResult = 1;
            Assert.AreEqual(expectedResult, calculator.Result());
        }

        [Test]
        public void Apply_ThreeNoPreviousInstructions_ReturnThree()  // 3 = 3
        {
            calculator.Apply(3);
            const int expectedResult = 3;
            Assert.AreEqual(expectedResult, calculator.Result());
        }

        [Test]
        public void Apply_OneAddedThree_ReturnFour() // 1 + 3 = 4
        {
            calculator.Add(3);
            calculator.Apply(1);

            const int expectedResult = 4;
            Assert.AreEqual(expectedResult, calculator.Result());
        }

        [Test]
        public void Apply_OneMultipledByTwo_ReturnsTwo() // 1 * 2 = 2
        {
            calculator.Multiply(2);
            calculator.Apply(1);

            const int expectedResult = 2;
            Assert.AreEqual(expectedResult, calculator.Result());
        }

        [Test]
        public void Apply_ThreePlusTwoMultipledByThree() // (3 + 2) * 3 = 15
        {
            calculator.Add(2);
            calculator.Multiply(3);
            calculator.Apply(3);

            const int expectedResult = 15;
            Assert.AreEqual(expectedResult, calculator.Result());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddInstruction_NullInstruction_ThrowsArgumentNullException()
        {
            IInstruction nullInstruction = null;
            calculator.AddInstruction(nullInstruction);
        }





    }
}
