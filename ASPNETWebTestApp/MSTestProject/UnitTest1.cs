using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedLibrary;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string msg = "I'm a Cool Robot";
            Assert.IsTrue(Robot.GetBot(msg).Contains(msg));
        }
    }
}
