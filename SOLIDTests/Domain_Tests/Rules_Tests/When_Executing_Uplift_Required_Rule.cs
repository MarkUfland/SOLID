using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Uplift_Required_Rule
    {
        [TestMethod]
        public void Then_Uplift_Required_Rule_Passed()
        {
            var upliftRequiredRule = new UpliftRequiredRule();
            var hasPassed          = upliftRequiredRule.ExecuteRule( 5001m );

            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Then_Uplift_Required_Rule_Failed()
        {
            var upliftRequiredRule = new UpliftRequiredRule();
            var hasPassed          = upliftRequiredRule.ExecuteRule( 5000m );

            Assert.IsFalse(hasPassed);
        }
    }

    public class UpliftRequiredRule
    {
        public bool ExecuteRule(decimal amount)
        {
            var upliftRequiredLevel = 5000m;
            var hasPassed           = amount > upliftRequiredLevel; 
            
            return hasPassed;
        }
    }
}

