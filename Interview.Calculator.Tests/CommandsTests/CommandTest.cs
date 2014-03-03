using Interview.Calculator.Model;
using Moq;
using NUnit.Framework;

namespace Interview.Calculator.Tests.CommandsTests
{
    [TestFixture]
    public abstract class CommandTest
    {
        protected Mock<ICalculator> _mockCalculator;


        [TestFixtureSetUp]
        public void SetUp()
        {
            _mockCalculator = new Mock<ICalculator>();
        }

    }
}
