using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Rules;
using Domain;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Legal_Age_Rule
    {
        [TestMethod]
        public void Then_Legal_Age_Rule_Passed()
        {
            var legalAgeRule = new LegalAgeRule();
            var serviceCommand = new ServiceCommand() { Age = 20 };
            var hasPassed = legalAgeRule.ExecuteRule(serviceCommand );

            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Then_Legal_Age_Rule_Failed()
        {
            var legalAgeRule = new LegalAgeRule();
            var serviceCommand = new ServiceCommand() { Age = 19 };
            var hasPassed = legalAgeRule.ExecuteRule(serviceCommand);

            Assert.IsFalse(hasPassed);
        }
    }

}
