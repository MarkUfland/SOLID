using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IdealService : IService
    {
        public decimal CalculateAmount(decimal amount)
        {
            //if (AGE < 20)
            //    return TO YOUNG

            //if amount is > 10000
            //    Send it To risk

            //if amount > 5000
            //    uplit 1%

            return amount * 0.7m;
        }
    }
}
