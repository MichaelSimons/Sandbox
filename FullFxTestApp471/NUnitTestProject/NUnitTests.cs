using NUnit.Framework;
using SharedLibrary;

namespace NUnitTestProject
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void GetBotTest()
        {
            string message = "Test Message";
            Assert.IsTrue(Robot.GetBot(message).Contains(message));
        }
    }
}
