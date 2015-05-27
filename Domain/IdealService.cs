using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IdealService : IService
    {
        public decimal CalculateAmount(ServiceCommand serviceCommand)
        {
            //if (AGE < 20)
            //    return TO YOUNG

            //if amount is > 10000
            //    Send it To risk

            //if amount > 5000
            //    uplift 1%

            return serviceCommand.Amount * 0.7m;
        }
    }
}
