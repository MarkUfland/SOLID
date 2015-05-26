using AutoMapper;
using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters
{
    public class SOLIDPresenter
    {
        private ISOLIDView view;
        private ITransferService transferService;

        public SOLIDPresenter(ITransferService transferService)
        {
            this.transferService = transferService;
           
            Mapper.CreateMap<SOLIDVM, ServiceCommand>();
        }

        public SOLIDVM Initialise(ISOLIDView view)
        {
            this.view = view;
 
            return new SOLIDVM();
        }

        public void CalculateTransfer(SOLIDVM vm)
        {
            var serviceCommand = Mapper.Map<SOLIDVM, ServiceCommand>(vm);

            vm.TransferedAmount = transferService.GetAmount(serviceCommand);

            this.view.UpdateTransferAmount(vm);
        }
    }
}
