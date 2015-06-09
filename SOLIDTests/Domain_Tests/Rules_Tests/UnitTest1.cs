using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Domain.Rules;
using Domain.IdealRules;
using Domain;
using Ninject;
using IOC;

namespace SOLIDTests.Domain_Tests.Rules_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var kernel = new StandardKernel();

            kernel.Load<IOCDomainModule>();

            var rulesBuilder = kernel.Get<IdealRulesBuilder>();
            var rulesProcessor = new RulesProcessor();
            var serviceCommand = new ServiceCommand() { Age = 10, Amount = 10000, Country = 0, Currency = 44, Service = "Ideal" };

            rulesProcessor.RulesProcessorSetup(rulesBuilder);
            
            IList<RuleResult> ruleResults = rulesProcessor.RunRules( serviceCommand );

            var errors = ruleResults.Where(r => r.HasPassed == false).Select(r => new
            {
                Error = r.Description
            });

        }
    }
}
