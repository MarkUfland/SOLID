using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOLID
{
    public partial class SOLIDForm : Form
    {
        private ITransferService transferService;

        public SOLIDForm(ITransferService transferService)
        {
            InitializeComponent();

            this.transferService = transferService;
        }

        public SOLIDForm() : this(new TransferService())
        {

        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            //Get data from form
            string service = ServiceTextBox.Text.ToUpper();
            decimal amount = decimal.Parse(AmountTextBox.Text);
            decimal actualAmount = 0.00m;

            actualAmount = transferService.GetAmount(service, amount);

            //Display results to form
            ActualAmountTextBox.Text = actualAmount.ToString();
        }
    }
}
