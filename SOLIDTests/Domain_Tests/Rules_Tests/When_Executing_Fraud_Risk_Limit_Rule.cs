using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Fraud_Risk_Limit_Rule
    {
        [TestMethod]
        public void Then_Fraud_Risk_Limit_Rule_Passed()
        {
            var fraudRiskLimitRule = new FraudRiskLimitRule();
            var hasPassed          = fraudRiskLimitRule.ExecuteRule( 1000m );
          
            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Then_Fraud_Risk_Limit_Rule_Failed()
        {
            var fraudRiskLimitRule = new FraudRiskLimitRule();
            var hasPassed          = fraudRiskLimitRule.ExecuteRule( 1000000m );

            Assert.IsFalse(hasPassed);
        }
    }

    public class FraudRiskLimitRule
    {
        public bool ExecuteRule(decimal amount)
        {
            var fraudRiskLimit = 10000m;
            var hasPassed      = amount <= fraudRiskLimit; 
            
            return hasPassed;
        }
    }
}
