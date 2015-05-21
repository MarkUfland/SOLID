using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger : ILogger
    {
        public bool Log(LogCommand logCommand)
        {
            try
            {
                Debug.WriteLine(logCommand.Message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
