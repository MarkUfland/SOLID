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
    public partial class OldStyleForm : Form
    {
        public OldStyleForm()
        {
            InitializeComponent();
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            
            //Get data from form
            string service = ServiceTextBox.Text.ToUpper() ;
            double amount = double.Parse(AmountTextBox.Text);
            double actualAmount = 0.00;

            //Get some data from database

            //Calculate values
            if (service == "AGMO")
            {
                actualAmount = amount * 0.8;
            }
            else if (service == "IDEAL")
            {
                actualAmount = amount * 0.7;
            }
            else if (service == "SID")
            {
                actualAmount = amount * 0.6;
            }
            

            // Log errrors

            //Write to database

            //Display results to form
            ActualAmountTextBox.Text = actualAmount.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ActualAmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServiceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
