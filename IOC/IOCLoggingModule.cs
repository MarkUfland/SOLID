using Logging;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class IOCLoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();

        }       

    }
}
