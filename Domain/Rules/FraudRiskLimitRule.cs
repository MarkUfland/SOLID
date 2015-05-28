using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public class FraudRiskLimitRule : IRule
    {
        public bool ExecuteRule(ServiceCommand serviceCommand)
        {
            var fraudRiskLimit = 10000m;
            var hasPassed = serviceCommand.Amount <= fraudRiskLimit;

            return hasPassed;
        }
    }
}
