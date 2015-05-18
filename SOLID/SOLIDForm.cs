using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presenters;

namespace SOLID
{
    public partial class SOLIDForm : Form, ISOLIDView
    {
        private ITransferService transferService;
        private SOLIDPresenter presenter;
        private SOLIDVM vm;

        public SOLIDForm(ITransferService transferService)
        {
            InitializeComponent();

            this.presenter = new SOLIDPresenter(this);

            this.vm= this.presenter.Initialise();

            this.transferService = transferService;
        }

        public SOLIDForm() : this(new TransferService())
        {

        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            this.vm.Service = ServiceTextBox.Text.ToUpper();
            this.vm.Amount = decimal.Parse(AmountTextBox.Text);
            this.presenter.CalculateTransfer(vm);
        }

        public void UpdateTransferAmount(SOLIDVM vm)
        {
            this.vm = vm;

            ActualAmountTextBox.Text = vm.TransferedAmount.ToString();
        }

        private void SOLIDForm_Load(object sender, EventArgs e)
        {

        }
    }
}
