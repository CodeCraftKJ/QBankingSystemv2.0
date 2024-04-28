namespace QBankingSystemv2._0.Forms
{
    partial class CreateAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccountForm));
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.accountNameTextBox = new System.Windows.Forms.TextBox();
            this.accountTypeLabel = new System.Windows.Forms.Label();
            this.accountTypeComboBox = new System.Windows.Forms.ComboBox();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.initialBalanceLabel = new System.Windows.Forms.Label();
            this.initialBalanceTextBox = new System.Windows.Forms.TextBox();
            this.depositLimitLabel = new System.Windows.Forms.Label();
            this.depositLimitTextBox = new System.Windows.Forms.TextBox();
            this.withdrawalLimitLabel = new System.Windows.Forms.Label();
            this.withdrawalLimitTextBox = new System.Windows.Forms.TextBox();
            this.transferLimitLabel = new System.Windows.Forms.Label();
            this.transferLimitTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Location = new System.Drawing.Point(20, 20);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(110, 20);
            this.accountNameLabel.TabIndex = 0;
            this.accountNameLabel.Text = "Account Name:";
            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.Location = new System.Drawing.Point(130, 20);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.Size = new System.Drawing.Size(150, 27);
            this.accountNameTextBox.TabIndex = 1;
            this.accountNameTextBox.TextChanged += new System.EventHandler(this.accountNameTextBox_TextChanged);
            // 
            // accountTypeLabel
            // 
            this.accountTypeLabel.AutoSize = true;
            this.accountTypeLabel.Location = new System.Drawing.Point(20, 60);
            this.accountTypeLabel.Name = "accountTypeLabel";
            this.accountTypeLabel.Size = new System.Drawing.Size(101, 20);
            this.accountTypeLabel.TabIndex = 2;
            this.accountTypeLabel.Text = "Account Type:";
            // 
            // accountTypeComboBox
            // 
            this.accountTypeComboBox.FormattingEnabled = true;
            this.accountTypeComboBox.Items.AddRange(new object[] {
            "Savings Account",
            "Checking Account"});
            this.accountTypeComboBox.Location = new System.Drawing.Point(130, 60);
            this.accountTypeComboBox.Name = "accountTypeComboBox";
            this.accountTypeComboBox.Size = new System.Drawing.Size(150, 28);
            this.accountTypeComboBox.TabIndex = 3;
            this.accountTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.accountTypeComboBox_SelectedIndexChanged);
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Location = new System.Drawing.Point(20, 100);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(69, 20);
            this.currencyLabel.TabIndex = 4;
            this.currencyLabel.Text = "Currency:";
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "PLN"});
            this.currencyComboBox.Location = new System.Drawing.Point(130, 100);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(150, 28);
            this.currencyComboBox.TabIndex = 5;
            this.currencyComboBox.SelectedIndexChanged += new System.EventHandler(this.currencyComboBox_SelectedIndexChanged);
            // 
            // initialBalanceLabel
            // 
            this.initialBalanceLabel.AutoSize = true;
            this.initialBalanceLabel.Location = new System.Drawing.Point(20, 140);
            this.initialBalanceLabel.Name = "initialBalanceLabel";
            this.initialBalanceLabel.Size = new System.Drawing.Size(105, 20);
            this.initialBalanceLabel.TabIndex = 6;
            this.initialBalanceLabel.Text = "Initial Balance:";
            // 
            // initialBalanceTextBox
            // 
            this.initialBalanceTextBox.Location = new System.Drawing.Point(130, 140);
            this.initialBalanceTextBox.Name = "initialBalanceTextBox";
            this.initialBalanceTextBox.Size = new System.Drawing.Size(150, 27);
            this.initialBalanceTextBox.TabIndex = 7;
            this.initialBalanceTextBox.TextChanged += new System.EventHandler(this.initialBalanceTextBox_TextChanged);
            // 
            // depositLimitLabel
            // 
            this.depositLimitLabel.AutoSize = true;
            this.depositLimitLabel.Location = new System.Drawing.Point(20, 180);
            this.depositLimitLabel.Name = "depositLimitLabel";
            this.depositLimitLabel.Size = new System.Drawing.Size(101, 20);
            this.depositLimitLabel.TabIndex = 8;
            this.depositLimitLabel.Text = "Deposit Limit:";
            // 
            // depositLimitTextBox
            // 
            this.depositLimitTextBox.Location = new System.Drawing.Point(130, 180);
            this.depositLimitTextBox.Name = "depositLimitTextBox";
            this.depositLimitTextBox.Size = new System.Drawing.Size(150, 27);
            this.depositLimitTextBox.TabIndex = 9;
            this.depositLimitTextBox.TextChanged += new System.EventHandler(this.depositLimitTextBox_TextChanged);
            // 
            // withdrawalLimitLabel
            // 
            this.withdrawalLimitLabel.AutoSize = true;
            this.withdrawalLimitLabel.Location = new System.Drawing.Point(20, 220);
            this.withdrawalLimitLabel.Name = "withdrawalLimitLabel";
            this.withdrawalLimitLabel.Size = new System.Drawing.Size(125, 20);
            this.withdrawalLimitLabel.TabIndex = 10;
            this.withdrawalLimitLabel.Text = "Withdrawal Limit:";
            // 
            // withdrawalLimitTextBox
            // 
            this.withdrawalLimitTextBox.Location = new System.Drawing.Point(145, 220);
            this.withdrawalLimitTextBox.Name = "withdrawalLimitTextBox";
            this.withdrawalLimitTextBox.Size = new System.Drawing.Size(135, 27);
            this.withdrawalLimitTextBox.TabIndex = 11;
            this.withdrawalLimitTextBox.TextChanged += new System.EventHandler(this.withdrawalLimitTextBox_TextChanged);
            // 
            // transferLimitLabel
            // 
            this.transferLimitLabel.AutoSize = true;
            this.transferLimitLabel.Location = new System.Drawing.Point(20, 260);
            this.transferLimitLabel.Name = "transferLimitLabel";
            this.transferLimitLabel.Size = new System.Drawing.Size(101, 20);
            this.transferLimitLabel.TabIndex = 12;
            this.transferLimitLabel.Text = "Transfer Limit:";
            // 
            // transferLimitTextBox
            // 
            this.transferLimitTextBox.Location = new System.Drawing.Point(130, 260);
            this.transferLimitTextBox.Name = "transferLimitTextBox";
            this.transferLimitTextBox.Size = new System.Drawing.Size(150, 27);
            this.transferLimitTextBox.TabIndex = 13;
            this.transferLimitTextBox.TextChanged += new System.EventHandler(this.transferLimitTextBox_TextChanged);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(130, 300);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(150, 30);
            this.createButton.TabIndex = 14;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // CreateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(283, 350);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.transferLimitTextBox);
            this.Controls.Add(this.transferLimitLabel);
            this.Controls.Add(this.withdrawalLimitTextBox);
            this.Controls.Add(this.withdrawalLimitLabel);
            this.Controls.Add(this.depositLimitTextBox);
            this.Controls.Add(this.depositLimitLabel);
            this.Controls.Add(this.initialBalanceTextBox);
            this.Controls.Add(this.initialBalanceLabel);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.currencyLabel);
            this.Controls.Add(this.accountTypeComboBox);
            this.Controls.Add(this.accountTypeLabel);
            this.Controls.Add(this.accountNameTextBox);
            this.Controls.Add(this.accountNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateAccountForm";
            this.Text = "Create Account";
            this.Load += new System.EventHandler(this.createAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accountNameLabel;
        private System.Windows.Forms.TextBox accountNameTextBox;
        private System.Windows.Forms.Label accountTypeLabel;
        private System.Windows.Forms.ComboBox accountTypeComboBox;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.Label initialBalanceLabel;
        private System.Windows.Forms.TextBox initialBalanceTextBox;
        private System.Windows.Forms.Label depositLimitLabel;
        private System.Windows.Forms.TextBox depositLimitTextBox;
        private System.Windows.Forms.Label withdrawalLimitLabel;
        private System.Windows.Forms.TextBox withdrawalLimitTextBox;
        private System.Windows.Forms.Label transferLimitLabel;
        private System.Windows.Forms.TextBox transferLimitTextBox;
        private System.Windows.Forms.Button createButton;
    }
}
