namespace SOLID
{
    partial class SOLIDForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ActualAmountTextBox = new System.Windows.Forms.TextBox();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.ServiceTextBox = new System.Windows.Forms.TextBox();
            this.TransferButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.CurrencyTextBox = new System.Windows.Forms.TextBox();
            this.AgeTextBox = new System.Windows.Forms.TextBox();
            this.sOLIDVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sOLIDVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 32);
            this.label3.TabIndex = 26;
            this.label3.Text = "Actual Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 32);
            this.label2.TabIndex = 25;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 32);
            this.label1.TabIndex = 24;
            this.label1.Text = "Service";
            // 
            // ActualAmountTextBox
            // 
            this.ActualAmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sOLIDVMBindingSource, "TransferedAmount", true));
            this.ActualAmountTextBox.Location = new System.Drawing.Point(316, 223);
            this.ActualAmountTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.ActualAmountTextBox.Name = "ActualAmountTextBox";
            this.ActualAmountTextBox.Size = new System.Drawing.Size(196, 38);
            this.ActualAmountTextBox.TabIndex = 23;
            this.ActualAmountTextBox.TextChanged += new System.EventHandler(this.ActualAmountTextBox_TextChanged);
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sOLIDVMBindingSource, "Amount", true));
            this.AmountTextBox.Location = new System.Drawing.Point(316, 139);
            this.AmountTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(196, 38);
            this.AmountTextBox.TabIndex = 22;
            // 
            // ServiceTextBox
            // 
            this.ServiceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sOLIDVMBindingSource, "Service", true));
            this.ServiceTextBox.Location = new System.Drawing.Point(316, 60);
            this.ServiceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.ServiceTextBox.Name = "ServiceTextBox";
            this.ServiceTextBox.Size = new System.Drawing.Size(196, 38);
            this.ServiceTextBox.TabIndex = 21;
            // 
            // TransferButton
            // 
            this.TransferButton.Location = new System.Drawing.Point(369, 642);
            this.TransferButton.Margin = new System.Windows.Forms.Padding(6);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(212, 87);
            this.TransferButton.TabIndex = 20;
            this.TransferButton.Text = "Transfer";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 475);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 32);
            this.label4.TabIndex = 32;
            this.label4.Text = "Country";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 389);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 32);
            this.label5.TabIndex = 31;
            this.label5.Text = "Currency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 304);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 32);
            this.label6.TabIndex = 30;
            this.label6.Text = "Age";
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sOLIDVMBindingSource, "Country", true));
            this.CountryTextBox.Location = new System.Drawing.Point(316, 467);
            this.CountryTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(196, 38);
            this.CountryTextBox.TabIndex = 29;
            // 
            // CurrencyTextBox
            // 
            this.CurrencyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sOLIDVMBindingSource, "Currency", true));
            this.CurrencyTextBox.Location = new System.Drawing.Point(316, 382);
            this.CurrencyTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.CurrencyTextBox.Name = "CurrencyTextBox";
            this.CurrencyTextBox.Size = new System.Drawing.Size(196, 38);
            this.CurrencyTextBox.TabIndex = 28;
            // 
            // AgeTextBox
            // 
            this.AgeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sOLIDVMBindingSource, "Age", true));
            this.AgeTextBox.Location = new System.Drawing.Point(316, 304);
            this.AgeTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.AgeTextBox.Name = "AgeTextBox";
            this.AgeTextBox.Size = new System.Drawing.Size(196, 38);
            this.AgeTextBox.TabIndex = 27;
            // 
            // sOLIDVMBindingSource
            // 
            this.sOLIDVMBindingSource.DataSource = typeof(Presenters.SOLIDVM);
            // 
            // SOLIDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 789);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.CurrencyTextBox);
            this.Controls.Add(this.AgeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActualAmountTextBox);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.ServiceTextBox);
            this.Controls.Add(this.TransferButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SOLIDForm";
            this.Text = "SOLIDForm";
            this.Load += new System.EventHandler(this.SOLIDForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sOLIDVMBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ActualAmountTextBox;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.TextBox ServiceTextBox;
        private System.Windows.Forms.Button TransferButton;
        private System.Windows.Forms.BindingSource sOLIDVMBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CountryTextBox;
        private System.Windows.Forms.TextBox CurrencyTextBox;
        private System.Windows.Forms.TextBox AgeTextBox;
    }
}