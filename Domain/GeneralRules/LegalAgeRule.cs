using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GeneralRules
{
    public abstract class LegalAgeRule : IRule
    {
        private int Age;

        public LegalAgeRule(int age)
        {
            Age = age;
        }

        public RuleResult ExecuteRule(ServiceCommand serviceCommand)
        {
            var ruleResult = new RuleResult() { HasPassed = serviceCommand.Age >= Age };

            return ruleResult;
        }
    }
}
