using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain;
using Ninject.Modules;
using DataAccessInterfaces;

namespace IOC
{
    public class IOCDataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataContext>().To<DataContext>();
            



        }
    }
}
