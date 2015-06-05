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
        private IRulesProcessor rulesProcessor;
        private IRulesBuilderFactory rulesBuilderFactory;

        public IdealService(IRulesProcessor rulesProcessor, IRulesBuilderFactory rulesBuilderFactory)
        {
            this.rulesProcessor = rulesProcessor;
            this.rulesBuilderFactory = rulesBuilderFactory;
        }

        public decimal CalculateAmount(ServiceCommand serviceCommand)
        {
            var rulesBuilder = this.rulesBuilderFactory.GetRulesBuilder("Ideal");

            this.rulesProcessor.RulesProcessorSetup(rulesBuilder);
            this.rulesProcessor.RunRules(serviceCommand);

            return serviceCommand.Amount * 0.7m;
        }
    }
}
