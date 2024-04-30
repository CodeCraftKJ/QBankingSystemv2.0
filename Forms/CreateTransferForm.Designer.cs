﻿namespace QBankingSystemv2._0.Forms
{
    partial class CreateTransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTransferForm));
            this.sourceAccountLabel = new System.Windows.Forms.Label();
            this.sourceAccountComboBox = new System.Windows.Forms.ComboBox();
            this.destinationAccountLabel = new System.Windows.Forms.Label();
            this.destinationAccountComboBox = new System.Windows.Forms.ComboBox();
            this.transferTypeLabel = new System.Windows.Forms.Label();
            this.transferTypeComboBox = new System.Windows.Forms.ComboBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.createTransferButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceAccountLabel
            // 
            this.sourceAccountLabel.AutoSize = true;
            this.sourceAccountLabel.Location = new System.Drawing.Point(20, 20);
            this.sourceAccountLabel.Name = "sourceAccountLabel";
            this.sourceAccountLabel.Size = new System.Drawing.Size(115, 20);
            this.sourceAccountLabel.TabIndex = 0;
            this.sourceAccountLabel.Text = "Source Account:";
            // 
            // sourceAccountComboBox
            // 
            this.sourceAccountComboBox.FormattingEnabled = true;
            this.sourceAccountComboBox.Location = new System.Drawing.Point(150, 20);
            this.sourceAccountComboBox.Name = "sourceAccountComboBox";
            this.sourceAccountComboBox.Size = new System.Drawing.Size(150, 28);
            this.sourceAccountComboBox.TabIndex = 1;
            // 
            // destinationAccountLabel
            // 
            this.destinationAccountLabel.AutoSize = true;
            this.destinationAccountLabel.Location = new System.Drawing.Point(20, 60);
            this.destinationAccountLabel.Name = "destinationAccountLabel";
            this.destinationAccountLabel.Size = new System.Drawing.Size(146, 20);
            this.destinationAccountLabel.TabIndex = 2;
            this.destinationAccountLabel.Text = "Destination Account:";
            // 
            // destinationAccountComboBox
            // 
            this.destinationAccountComboBox.FormattingEnabled = true;
            this.destinationAccountComboBox.Location = new System.Drawing.Point(180, 60);
            this.destinationAccountComboBox.Name = "destinationAccountComboBox";
            this.destinationAccountComboBox.Size = new System.Drawing.Size(150, 28);
            this.destinationAccountComboBox.TabIndex = 3;
            // 
            // transferTypeLabel
            // 
            this.transferTypeLabel.AutoSize = true;
            this.transferTypeLabel.Location = new System.Drawing.Point(20, 100);
            this.transferTypeLabel.Name = "transferTypeLabel";
            this.transferTypeLabel.Size = new System.Drawing.Size(99, 20);
            this.transferTypeLabel.TabIndex = 4;
            this.transferTypeLabel.Text = "Transfer Type:";
            // 
            // transferTypeComboBox
            // 
            this.transferTypeComboBox.FormattingEnabled = true;
            this.transferTypeComboBox.Items.AddRange(new object[] {
            "Internal Transfer",
            "External Transfer"});
            this.transferTypeComboBox.Location = new System.Drawing.Point(150, 100);
            this.transferTypeComboBox.Name = "transferTypeComboBox";
            this.transferTypeComboBox.Size = new System.Drawing.Size(150, 28);
            this.transferTypeComboBox.TabIndex = 5;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(20, 140);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(65, 20);
            this.amountLabel.TabIndex = 6;
            this.amountLabel.Text = "Amount:";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(150, 140);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(150, 27);
            this.amountTextBox.TabIndex = 7;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(20, 180);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(88, 20);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(150, 180);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 100);
            this.descriptionTextBox.TabIndex = 9;
            // 
            // createTransferButton
            // 
            this.createTransferButton.Location = new System.Drawing.Point(150, 300);
            this.createTransferButton.Name = "createTransferButton";
            this.createTransferButton.Size = new System.Drawing.Size(150, 30);
            this.createTransferButton.TabIndex = 10;
            this.createTransferButton.Text = "Create Transfer";
            this.createTransferButton.UseVisualStyleBackColor = true;
            this.createTransferButton.Click += new System.EventHandler(this.createTransferButton_Click);
            // 
            // CreateTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 350);
            this.Controls.Add(this.createTransferButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.transferTypeComboBox);
            this.Controls.Add(this.transferTypeLabel);
            this.Controls.Add(this.destinationAccountComboBox);
            this.Controls.Add(this.destinationAccountLabel);
            this.Controls.Add(this.sourceAccountComboBox);
            this.Controls.Add(this.sourceAccountLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTransferForm";
            this.Text = "Create Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label sourceAccountLabel;
        public System.Windows.Forms.ComboBox sourceAccountComboBox;
        public System.Windows.Forms.Label destinationAccountLabel;
        public System.Windows.Forms.ComboBox destinationAccountComboBox;
        public System.Windows.Forms.Label transferTypeLabel;
        public System.Windows.Forms.ComboBox transferTypeComboBox;
        public System.Windows.Forms.Label amountLabel;
        public System.Windows.Forms.TextBox amountTextBox;
        public System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.TextBox descriptionTextBox;
        public System.Windows.Forms.Button createTransferButton;
    }
}
