using Domain.IdealRules;
using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdealRules
{
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
            this.idealRules.Add(new IdealFraudRiskLimitRule());

            return idealRules.Cast<IRule>().ToList();
        }
    }

}
