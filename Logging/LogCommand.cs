using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class LogCommand
    {
        public string Message { get; set; }
        public LoggingCategory LoggingCategory { get; set; }
    }
}
