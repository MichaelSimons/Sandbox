using SharedLibrary;
using System.Linq;
using Xunit;

namespace XUnitTestProject
{
    public class XUnitTests
    {
        [Fact]
        public void GetBotTest()
        {
            string message = "Test Message";
            Assert.Contains(message, Robot.GetBot(message));
        }
    }
}
