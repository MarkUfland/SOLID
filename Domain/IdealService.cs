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
        private IList<IRule> rules;

        public IdealService(IRule[] rules)
        {
            this.rules = rules;
        }

        public decimal CalculateAmount(ServiceCommand serviceCommand)
        {
            foreach (IRule rule in this.rules)
            {
                var hasPassed = rule.ExecuteRule( serviceCommand );
            }

            return serviceCommand.Amount * 0.7m;
        }
    }
}
