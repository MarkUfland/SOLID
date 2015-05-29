using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Rules;
using Domain;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Fraud_Risk_Limit_Rule
    {
        [TestMethod]
        public void Then_Fraud_Risk_Limit_Rule_Passed()
        {
            var fraudRiskLimitRule = new FraudRiskLimitRule();
            var serviceCommand = new ServiceCommand() { Amount = 1000m };
            var ruleResult = fraudRiskLimitRule.ExecuteRule( serviceCommand );

            Assert.IsTrue(ruleResult.HasPassed);
        }

        [TestMethod]
        public void Then_Fraud_Risk_Limit_Rule_Failed()
        {
            var fraudRiskLimitRule = new FraudRiskLimitRule();
            var serviceCommand = new ServiceCommand() { Amount = 1000000m };
            var ruleResult = fraudRiskLimitRule.ExecuteRule(serviceCommand);

            Assert.IsFalse(ruleResult.HasPassed);
        }
    }


}
