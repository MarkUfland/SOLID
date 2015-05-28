using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public class LegalAgeRule : IRule
    {
        public bool ExecuteRule(ServiceCommand serviceCommand)
        {
            var ageLimit = 20;
            var hasPassed = serviceCommand.Age >= ageLimit;

            return hasPassed;
        }
    }
}
