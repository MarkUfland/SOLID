using System;
namespace Domain
{
    public interface IRulesProcessor
    {
        void RulesProcessorSetup(IRulesBuilder rulesBuilder);

        void RunRules(ServiceCommand serviceCommand);
    }
}
