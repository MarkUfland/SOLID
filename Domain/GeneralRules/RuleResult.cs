using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public class RuleResult
    {
        public bool HasPassed { get; set; }
        public string Description { get; set; }
    }
}
