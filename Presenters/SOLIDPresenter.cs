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


        public SOLIDPresenter(ISOLIDView view): this (view, new TransferService())
        {
            
        }

        public SOLIDPresenter(ISOLIDView view, ITransferService transferService)
        {
            this.view = view;
            this.transferService = transferService;
        }

        public SOLIDVM Initialise()
        {
            return new SOLIDVM();
        }

        public void CalculateTransfer(SOLIDVM vm)
        {
            vm.TransferedAmount = transferService.GetAmount(vm.Service, vm.Amount);

            this.view.UpdateTransferAmount(vm);
        }
    }
}
