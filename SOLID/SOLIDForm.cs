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
        private SOLIDPresenter presenter;
        private SOLIDVM vm;

        public SOLIDForm(SOLIDPresenter presenter)
        {
            

            InitializeComponent();

            this.presenter = presenter;

            this.vm = this.presenter.Initialise(this);  

        }

        //public SOLIDForm() : this(new TransferService())
        //{

        //}

        private void TransferButton_Click(object sender, EventArgs e)
        {
            //this.vm.Service = ServiceTextBox.Text.ToUpper();
            //this.vm.Amount = decimal.Parse(AmountTextBox.Text);
            this.presenter.CalculateTransfer(vm);
        }

        public void UpdateTransferAmount(SOLIDVM vm)
        {
            this.vm = vm;

            this.sOLIDVMBindingSource.ResetBindings(false);

            //ActualAmountTextBox.Text = vm.TransferedAmount.ToString();
        }

        private void SOLIDForm_Load(object sender, EventArgs e)
        {
            this.sOLIDVMBindingSource.DataSource = this.vm;
        }

        private void ActualAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
