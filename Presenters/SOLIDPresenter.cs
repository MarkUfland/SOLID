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


        //public SOLIDPresenter(ISOLIDView view): this (view, new TransferService())
        //{
            
        //}

        public SOLIDPresenter(ITransferService transferService)
        {
            this.transferService = transferService;
        }

        public SOLIDVM Initialise(ISOLIDView view)
        {
            this.view = view;

            return new SOLIDVM();
        }

        public void CalculateTransfer(SOLIDVM vm)
        {
            vm.TransferedAmount = transferService.GetAmount(vm.Service, vm.Amount);

            this.view.UpdateTransferAmount(vm);
        }
    }
}
