using Domain.Rules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IdealService : IService
    {
        private IList<IIdealServiceRule> rules;

        public IdealService(IIdealServiceRule[] rules)
        {
            this.rules = rules;
        }

        public decimal CalculateAmount(ServiceCommand serviceCommand)
        {
            var ruleResults = new List<RuleResult>();

            foreach (IRule rule in this.rules)
            {
                var ruleResult = rule.ExecuteRule( serviceCommand );
                
                ruleResults.Add(ruleResult);
            }

            return serviceCommand.Amount * 0.7m;
        }
    }
}
