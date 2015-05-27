using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Fraud_Risk_Limit_Rule
    {
        [TestMethod]
        public void Then_Rule_Passed()
        {
            // Arrange
            var fraudRiskLimitRule = new FraudRiskLimitRule();
            
            // Act
            var hasPassed = fraudRiskLimitRule.ExecuteRule( 1000m );
            
            // Assert
            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Then_Rule_Failed()
        {
            // Arrange
            var fraudRiskLimitRule = new FraudRiskLimitRule();

            // Act
            var hasPassed = fraudRiskLimitRule.ExecuteRule(1000000m);

            // Assert
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
