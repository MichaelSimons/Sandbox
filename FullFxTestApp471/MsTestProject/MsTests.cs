using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedLibrary;

namespace MsTestProject
{
    [TestClass]
    public class MsTests
    {
        [TestMethod]
        public void GetBotTest()
        {
            string message = "Test Message";
            Assert.IsTrue(Robot.GetBot(message).Contains(message));
        }
    }
}
