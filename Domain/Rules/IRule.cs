using System;
namespace Domain.Rules
{
    public interface IRule
    {
        bool ExecuteRule(Domain.ServiceCommand serviceCommand);
    }
}
