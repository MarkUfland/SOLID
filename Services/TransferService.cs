using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccessInterfaces;

namespace Services
{
    public class TransferService : ITransferService
    {
        private IServiceFactory serviceFactory;
        private IDataContext dataContext;

        public TransferService(IServiceFactory serviceFactory, IDataContext dataContext)
        {
            this.serviceFactory = serviceFactory;
            this.dataContext = dataContext;
        }

        //public TransferService() : this(new ServiceFactory(), new DataContext())
        //{

        //}

        private decimal actualAmount;

        public decimal GetAmount(string service, decimal amount)
        {
            //Get some data from database

            //Calculate values
            //if (service == "AGMO")
            //{
            //    actualAmount = amount * 0.8m;
            //}
            //else if (service == "IDEAL")
            //{
            //    actualAmount = amount * 0.7m;
            //}
            //else if (service == "SID")
            //{
            //    actualAmount = amount * 0.6m;
            //}

            var fxData = this.dataContext.GetById<FXData>(1);

            actualAmount = serviceFactory.GetService(service).CalculateAmount(amount);

            actualAmount = actualAmount * fxData.FXRate;

            // Log errrors

            //Write to database

            return actualAmount;
        }
    }
}
