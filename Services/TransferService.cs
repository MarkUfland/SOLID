using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccessInterfaces;
using Logging;

namespace Services
{
    public class TransferService : ITransferService
    {
        private IServiceFactory serviceFactory;
        private IDataContext dataContext;
        private ILogger logger;

        public TransferService(IServiceFactory serviceFactory, IDataContext dataContext, ILogger logger)
        {
            this.serviceFactory = serviceFactory;
            this.dataContext = dataContext;
            this.logger = logger;
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

            // Log transfer amount
            logger.Log( new LogCommand() 
            {
                LoggingCategory = LoggingCategory.Information,
                Message = string.Format( "Transfered {0}", actualAmount.ToString() )
            } );      

            //Write to database

            return actualAmount;
        }
    }
}
