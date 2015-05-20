using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FXData
    {
        public virtual int Id { get; set; }
        public virtual DateTime FXDate { get; set; }
        public virtual decimal FXRate { get; set; }
    }
}
