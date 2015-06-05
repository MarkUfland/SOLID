using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRulesBuilder
    {
        IList<IRule> PrioritiseRules();
    }
}
