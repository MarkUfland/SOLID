using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Rules;
using Domain;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Uplift_Required_Rule
    {
        [TestMethod]
        public void Then_Uplift_Required_Rule_Passed()
        {
            var upliftRequiredRule = new UpliftRequiredRule();
            var serviceCommand = new ServiceCommand() { Amount = 5001m };
            var hasPassed = upliftRequiredRule.ExecuteRule(serviceCommand);

            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Then_Uplift_Required_Rule_Failed()
        {
            var upliftRequiredRule = new UpliftRequiredRule();
            var serviceCommand = new ServiceCommand() { Amount = 5000m };
            var hasPassed = upliftRequiredRule.ExecuteRule(serviceCommand);

            Assert.IsFalse(hasPassed);
        }
    }

}

