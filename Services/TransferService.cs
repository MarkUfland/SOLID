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

        public decimal GetAmount(ServiceCommand serviceCommand)
        {
            
            var fxData = this.dataContext.GetById<FXData>(1);

            actualAmount = serviceFactory.GetService(serviceCommand.Service).CalculateAmount(serviceCommand.Amount);

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
