using System;
namespace Domain.Rules
{
    public interface IRule
    {
        RuleResult ExecuteRule(ServiceCommand serviceCommand);
    }
}
