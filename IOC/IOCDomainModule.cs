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
using Domain.Rules;
using Domain.IdealRules;

namespace IOC
{
    public class IOCDomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<SIDService>().Named("SID");
            Bind<IService>().To<IdealService>().Named("Ideal");

            Bind<IIdealServiceRule>().To<IdealLegalAgeRule>();
            //Bind<IRule,IIdealServiceRule>().To<FraudRiskLimitRule>();
            //Bind<IRule,ISIDServiceRule,IIdealServiceRule>().To<LegalAgeRule>();
            //Bind<IRule,ISIDServiceRule,IIdealServiceRule>().To<UpliftRequiredRule>();

            Bind<IServiceFactory>().ToFactory(() => new NameInstanceProvider(Kernel));


        }
    }
}
