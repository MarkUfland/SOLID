using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Factory.Factory;

namespace IOC
{
    public class IOCDomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<SIDService>().Named("SID");
            Bind<IService>().To<IdealService>().Named("Ideal");

            Bind<IServiceFactory>().ToFactory(() => new NameInstanceProvider(Kernel));


        }
    }
}
