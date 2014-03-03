using System;
using Interview.Calculator.Model.Commands;
using Moq;
using NUnit.Framework;

namespace Interview.Calculator.Tests.CommandsTests
{
    public class ApplyCommandTest : CommandTest
    {

        private ApplyCommand _command;
        private int _numberToApply;

        [SetUp]
        public void SetUp()
        {
            _numberToApply = 1;
            _command = new ApplyCommand(_mockCalculator.Object, _numberToApply);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCalculator_ThrowsException()
        {
            Model.Calculator calculator = null;
            _command = new ApplyCommand(calculator, _numberToApply);

        }

        [Test]
        public void Execute_MultiplyIsCalledWithNumberThree()
        {
            _command.Execute();
            _mockCalculator.Verify(calculator => calculator.Apply(It.Is<int>(i => i == _numberToApply)));
        }

    }
}
