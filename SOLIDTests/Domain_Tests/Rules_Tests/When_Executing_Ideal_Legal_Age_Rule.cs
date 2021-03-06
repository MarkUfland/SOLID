﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Rules;
using Domain;
using Domain.IdealRules;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Ideal_Legal_Age_Rule
    {
        [TestMethod]
        public void Then_Ideal_Legal_Age_Rule_Passed()
        {
            var legalAgeRule = new IdealLegalAgeRule();
            var serviceCommand = new ServiceCommand() { Age = 20 };
            var ruleResult = legalAgeRule.ExecuteRule(serviceCommand);

            Assert.IsTrue(ruleResult.HasPassed);
        }

        [TestMethod]
        public void Then_Ideal_Legal_Age_Rule_Failed()
        {
            var legalAgeRule = new IdealLegalAgeRule();
            var serviceCommand = new ServiceCommand() { Age = 19 };
            var ruleResult = legalAgeRule.ExecuteRule(serviceCommand);

            Assert.IsFalse(ruleResult.HasPassed);
        }
    }

}
