using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServiceCommand
    {
        public string Service { get; set; }
        public decimal Amount { get; set; }
        public decimal TransferedAmount { get; set; }
        public decimal Age { get; set; }
        public decimal Currency { get; set; }
        public decimal Country { get; set; }
    }
}
