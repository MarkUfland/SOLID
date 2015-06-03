using Domain.GeneralRules;
using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdealRules
{
    public class IdealFraudRiskLimitRule : FraudRiskLimitRule, IIdealServiceRule
    {
        private const int FraudRiskLimit = 10000;

        public IdealFraudRiskLimitRule() : base( limit: FraudRiskLimit)
        {

        }

        public override RuleResult ExecuteRule(ServiceCommand serviceCommand)
        {
            var ruleResult = base.ExecuteRule(serviceCommand);

            ruleResult.RuleType = RuleType.IdealFraudRiskLimitRule;

            return ruleResult;
        }

    }
}
