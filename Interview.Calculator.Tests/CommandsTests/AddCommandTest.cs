using System;
using Interview.Calculator.Model.Commands;
using Moq;
using NUnit.Framework;

namespace Interview.Calculator.Tests.CommandsTests
{
    [TestFixture]
    public class AddCommandTest : CommandTest
    {
        private AddCommand _command;
        private int _numberToAdd;

        [SetUp]
        public void SetUp()
        {
            _numberToAdd = 2;
            _command = new AddCommand(_mockCalculator.Object, _numberToAdd);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCalculator_ThrowsException()
        {
            Model.Calculator calculator = null;
            _command = new AddCommand(calculator, _numberToAdd);

        }

        [Test]
        public void Execute_MultiplyIsCalledWithNumberThree()
        {
            _command.Execute();
            _mockCalculator.Verify(calculator => calculator.Add(It.Is<int>(i => i == _numberToAdd)));
        }

        
    }
}
