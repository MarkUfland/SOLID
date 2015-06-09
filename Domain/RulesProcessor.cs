using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RulesProcessor : IRulesProcessor
    {
        private IRulesBuilder rulesBuilder;
        private IList<IRule> rules;

        public RulesProcessor()
        {
        }

        public void RulesProcessorSetup(IRulesBuilder rulesBuilder)
        {
            this.rulesBuilder = rulesBuilder;
            this.rulesBuilder.PrioritiseRules();
        }

        public void RunRules(ServiceCommand serviceCommand)
        {
            foreach (IRule rule in rules)
            {
                RuleResult ruleResult = rule.ExecuteRule(serviceCommand);
            }
        }
    }

}
