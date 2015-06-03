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

    public class IdealRulesBuilder : IRulesBuilder
    {
        private IList<IIdealServiceRule> idealRules;

        public IdealRulesBuilder()
        {
            this.idealRules = new List<IIdealServiceRule>();

            

            
        }

        public IList<IRule> PrioritiseRules()
        {
            this.idealRules.Add(new IdealLegalAgeRule());

            return idealRules as IList<IRule>;
        }
    }

    public class RulesProcessor
    {
        private IRulesBuilder rulesBuilder;

        private IList<IRule> rules;

        public RulesProcessor(IRulesBuilder rulesBuilder)
        {
            this.rulesBuilder = rulesBuilder;
            this.rules = rulesBuilder.PrioritiseRules();
        }

        public void RunRules(ServiceCommand serviceCommand)
        {
            foreach (IRule rule in rules)
            {
              RuleResult ruleResult = rule.ExecuteRule(serviceCommand);
            }
        }
    }

    public interface IRulesBuilder
    {
        IList<IRule> PrioritiseRules();
    }
}
