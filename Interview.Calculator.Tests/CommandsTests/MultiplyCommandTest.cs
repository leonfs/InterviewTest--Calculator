using System;
using Interview.Calculator.Model.Commands;
using Moq;
using NUnit.Framework;

namespace Interview.Calculator.Tests.CommandsTests
{
    [TestFixture]
    public class MultiplyCommandTest : CommandTest
    {
        private MultiplyCommand _command;
        private int _numberToMultiply;

        [SetUp]
        public void SetUp()
        {
            _numberToMultiply = 3;
            _command = new MultiplyCommand(_mockCalculator.Object, _numberToMultiply);
        }

        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCalculator_ThrowsException()
        {
            Model.Calculator calculator = null;
            _command = new MultiplyCommand(calculator, _numberToMultiply);

        }

        [Test]
        public void Execute_MultiplyIsCalledWithNumberThree()
        {
            _command.Execute();
            _mockCalculator.Verify(calculator => calculator.Multiply(It.Is<int>(i => i == _numberToMultiply)));
        }


    }
}
