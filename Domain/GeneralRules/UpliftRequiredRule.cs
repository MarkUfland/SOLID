using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public class UpliftRequiredRule : IRule, ISIDServiceRule, IIdealServiceRule
    {
        public RuleResult ExecuteRule(ServiceCommand serviceCommand)
        {
            var upliftRequiredLevel = 5000m;
            var ruleResult = new RuleResult() { HasPassed = serviceCommand.Amount > upliftRequiredLevel };

            return ruleResult;
        }
    }
}
