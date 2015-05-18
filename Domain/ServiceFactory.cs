using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ServiceFactory : Domain.IServiceFactory
    {
        private IList<IService> services;

        public ServiceFactory()
        {
            services = new List<IService>();

            services.Add(new SIDService());
            services.Add(new IdealService());
        }

        public IService GetService(string serviceName)
        {
            return services.Where(s => s.GetType().Name.ToString().Contains(serviceName)).First();
        }
    }
}
