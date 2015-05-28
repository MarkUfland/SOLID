using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public class UpliftRequiredRule : IRule
    {
        public bool ExecuteRule(ServiceCommand serviceCommand)
        {
            var upliftRequiredLevel = 5000m;
            var hasPassed = serviceCommand.Amount > upliftRequiredLevel;

            return hasPassed;
        }
    }
}
