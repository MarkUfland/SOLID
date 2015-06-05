using System;
namespace Domain
{
    interface IRulesProcessor
    {
        void RulesProcessorSetup(IRulesBuilder rulesBuilder);

        void RunRules(ServiceCommand serviceCommand);
    }
}
