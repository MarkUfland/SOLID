using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Ninject.Modules;

namespace IOC
{
    public class IOCServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITransferService>().To<TransferService>();



        }
    }
}
