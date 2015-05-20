using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenters;

namespace IOC
{
    public class IOCPresentationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<SOLIDPresenter>().ToSelf();
        }
    }
}
