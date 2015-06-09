using Domain.Rules;
using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IRulesProcessor
    {
        void RulesProcessorSetup(IRulesBuilder rulesBuilder);

        IList<RuleResult> RunRules(ServiceCommand serviceCommand);
    }
}
