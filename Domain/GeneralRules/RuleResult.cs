using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rules
{
    public enum RuleType
    {
        IdealLegalLAgeRule,
        IdealFraudRiskLimitRule
    }

    public class RuleResult
    {
        public RuleType RuleType { get; set; }
        public bool HasPassed { get; set; }
        public string Description { get; set; }
    }
}
