﻿using Domain.GeneralRules;
using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdealRules
{
    public class IdealLegalAgeRule : LegalAgeRule, IIdealServiceRule
    {
        private const int AgeLimit = 20;

        public IdealLegalAgeRule() : base( age: AgeLimit )
        {

        }

        public override RuleResult ExecuteRule(ServiceCommand serviceCommand)
        {
            var ruleResult = base.ExecuteRule(serviceCommand);

            ruleResult.RuleType = RuleType.IdealLegalLAgeRule;

            return ruleResult;
        }
    }
}
