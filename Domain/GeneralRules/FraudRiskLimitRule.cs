using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public class FraudRiskLimitRule : IRule, IIdealServiceRule
    {
        public RuleResult ExecuteRule(ServiceCommand serviceCommand)
        {
            var fraudRiskLimit = 10000m;
            var ruleResult = new RuleResult() { HasPassed = serviceCommand.Amount <= fraudRiskLimit };

            return ruleResult;
        }
    }
}
