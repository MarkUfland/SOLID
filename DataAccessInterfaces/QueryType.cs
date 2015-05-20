using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creates an enum that can be used by other classes to specify the type of Stored Proc to
    /// run
    /// </summary>
    public enum QueryType
    {
        ORM,
        GetCurrencyByName,
        GetCurrencyByAbbreviation

    }
}
