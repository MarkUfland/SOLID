using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Domain.Rules;
using Domain.IdealRules;
using Domain;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rulesBuilder = new IdealRulesBuilder();
            var rulesProcessor = new RulesProcessor(rulesBuilder);

        }
    }
}
