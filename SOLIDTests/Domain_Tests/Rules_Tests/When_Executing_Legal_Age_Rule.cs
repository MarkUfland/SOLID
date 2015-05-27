using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class When_Executing_Legal_Age_Rule
    {
        [TestMethod]
        public void Then_Legal_Age_Rule_Passed()
        {
            var legalAgeRule = new LegalAgeRule();
            var hasPassed    = legalAgeRule.ExecuteRule( 20 );

            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Then_Legal_Age_Rule_Failed()
        {
            var legalAgeRule = new LegalAgeRule();
            var hasPassed    = legalAgeRule.ExecuteRule( 19 );

            Assert.IsFalse(hasPassed);
        }
    }

    public class LegalAgeRule
    {
        public bool ExecuteRule(decimal age)
        {
            var ageLimit  = 20;
            var hasPassed = age >= ageLimit; 
            
            return hasPassed;
        }
    }
}
