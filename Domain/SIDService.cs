using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SIDService : IService
    {

        public decimal CalculateAmount(ServiceCommand serviceCommand)
        {
            return serviceCommand.Amount * 0.6m;
        }
    }
}
