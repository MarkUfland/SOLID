using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logging;

namespace SOLIDTests.Logging_Tests
{
    [TestClass]
    public class When_a_Message_Is_Logged
    {
        [TestMethod]
        public void Then_Message_Is_Logged_Correctly()
        {
            var logger = new Logger();
            var logCommand = new LogCommand() { LoggingCategory = LoggingCategory.Information, Message = "Warp Factor 10 Sulu" };

            bool hasLogged = logger.Log(logCommand);

            Assert.IsTrue(hasLogged);          
        }
    }
}
