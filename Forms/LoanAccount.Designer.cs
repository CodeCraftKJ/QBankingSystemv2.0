namespace QBankingSystemv2._0.Forms
{
    partial class LoanAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanAccount));
            this.takeLoanButton = new System.Windows.Forms.Button();
            this.loanAmountLabel = new System.Windows.Forms.Label();
            this.loanInterestRateLabel = new System.Windows.Forms.Label();
            this.loanAmountTrackBar = new System.Windows.Forms.TrackBar();
            this.loanInterestRateTrackBar = new System.Windows.Forms.TrackBar();
            this.loanAmountValueLabel = new System.Windows.Forms.Label();
            this.loanInterestRateValueLabel = new System.Windows.Forms.Label();
            this.loanCostLabel = new System.Windows.Forms.Label();
            this.transferList = new System.Windows.Forms.ListBox();
            this.remainingBalanceTextBox = new System.Windows.Forms.TextBox();
            this.remainingBalanceLabel = new System.Windows.Forms.Label();
            this.repayLoanButton = new System.Windows.Forms.Button();
            this.textLoanAccount = new System.Windows.Forms.TextBox();
            this.labelSendLoanTo = new System.Windows.Forms.Label();
            this.toAccount1 = new System.Windows.Forms.TextBox();
            this.ToAccount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loanAmountTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanInterestRateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // takeLoanButton
            // 
            this.takeLoanButton.Location = new System.Drawing.Point(34, 291);
            this.takeLoanButton.Name = "takeLoanButton";
            this.takeLoanButton.Size = new System.Drawing.Size(120, 34);
            this.takeLoanButton.TabIndex = 0;
            this.takeLoanButton.Text = "Take Loan";
            this.takeLoanButton.UseVisualStyleBackColor = true;
            this.takeLoanButton.Click += new System.EventHandler(this.takeLoanButton_Click);
            // 
            // loanAmountLabel
            // 
            this.loanAmountLabel.AutoSize = true;
            this.loanAmountLabel.Location = new System.Drawing.Point(34, 9);
            this.loanAmountLabel.Name = "loanAmountLabel";
            this.loanAmountLabel.Size = new System.Drawing.Size(101, 20);
            this.loanAmountLabel.TabIndex = 2;
            this.loanAmountLabel.Text = "Loan Amount:";
            // 
            // loanInterestRateLabel
            // 
            this.loanInterestRateLabel.AutoSize = true;
            this.loanInterestRateLabel.Location = new System.Drawing.Point(34, 96);
            this.loanInterestRateLabel.Name = "loanInterestRateLabel";
            this.loanInterestRateLabel.Size = new System.Drawing.Size(121, 20);
            this.loanInterestRateLabel.TabIndex = 3;
            this.loanInterestRateLabel.Text = "Interest Rate (%):";
            // 
            // loanAmountTrackBar
            // 
            this.loanAmountTrackBar.Location = new System.Drawing.Point(34, 40);
            this.loanAmountTrackBar.Name = "loanAmountTrackBar";
            this.loanAmountTrackBar.Size = new System.Drawing.Size(264, 56);
            this.loanAmountTrackBar.TabIndex = 4;
            // 
            // loanInterestRateTrackBar
            // 
            this.loanInterestRateTrackBar.Location = new System.Drawing.Point(34, 130);
            this.loanInterestRateTrackBar.Name = "loanInterestRateTrackBar";
            this.loanInterestRateTrackBar.Size = new System.Drawing.Size(264, 56);
            this.loanInterestRateTrackBar.TabIndex = 5;
            // 
            // loanAmountValueLabel
            // 
            this.loanAmountValueLabel.AutoSize = true;
            this.loanAmountValueLabel.Location = new System.Drawing.Point(308, 41);
            this.loanAmountValueLabel.Name = "loanAmountValueLabel";
            this.loanAmountValueLabel.Size = new System.Drawing.Size(36, 20);
            this.loanAmountValueLabel.TabIndex = 6;
            this.loanAmountValueLabel.Text = "0.00";
            // 
            // loanInterestRateValueLabel
            // 
            this.loanInterestRateValueLabel.AutoSize = true;
            this.loanInterestRateValueLabel.Location = new System.Drawing.Point(308, 130);
            this.loanInterestRateValueLabel.Name = "loanInterestRateValueLabel";
            this.loanInterestRateValueLabel.Size = new System.Drawing.Size(36, 20);
            this.loanInterestRateValueLabel.TabIndex = 7;
            this.loanInterestRateValueLabel.Text = "0.00";
            // 
            // loanCostLabel
            // 
            this.loanCostLabel.AutoSize = true;
            this.loanCostLabel.Location = new System.Drawing.Point(34, 182);
            this.loanCostLabel.Name = "loanCostLabel";
            this.loanCostLabel.Size = new System.Drawing.Size(77, 20);
            this.loanCostLabel.TabIndex = 8;
            this.loanCostLabel.Text = "Loan Cost:";
            // 
            // transferList
            // 
            this.transferList.FormattingEnabled = true;
            this.transferList.ItemHeight = 20;
            this.transferList.Location = new System.Drawing.Point(369, 75);
            this.transferList.Name = "transferList";
            this.transferList.Size = new System.Drawing.Size(375, 224);
            this.transferList.TabIndex = 9;
            // 
            // remainingBalanceTextBox
            // 
            this.remainingBalanceTextBox.Location = new System.Drawing.Point(128, 179);
            this.remainingBalanceTextBox.Name = "remainingBalanceTextBox";
            this.remainingBalanceTextBox.ReadOnly = true;
            this.remainingBalanceTextBox.Size = new System.Drawing.Size(170, 27);
            this.remainingBalanceTextBox.TabIndex = 10;
            // 
            // remainingBalanceLabel
            // 
            this.remainingBalanceLabel.AutoSize = true;
            this.remainingBalanceLabel.Location = new System.Drawing.Point(369, 41);
            this.remainingBalanceLabel.Name = "remainingBalanceLabel";
            this.remainingBalanceLabel.Size = new System.Drawing.Size(139, 20);
            this.remainingBalanceLabel.TabIndex = 11;
            this.remainingBalanceLabel.Text = "Remaining Balance:";
            // 
            // repayLoanButton
            // 
            this.repayLoanButton.Location = new System.Drawing.Point(201, 288);
            this.repayLoanButton.Name = "repayLoanButton";
            this.repayLoanButton.Size = new System.Drawing.Size(120, 34);
            this.repayLoanButton.TabIndex = 12;
            this.repayLoanButton.Text = "Repay Loan";
            this.repayLoanButton.UseVisualStyleBackColor = true;
            this.repayLoanButton.Click += new System.EventHandler(this.repayLoanButton_Click);
            // 
            // textLoanAccount
            // 
            this.textLoanAccount.Location = new System.Drawing.Point(128, 215);
            this.textLoanAccount.Name = "textLoanAccount";
            this.textLoanAccount.ReadOnly = true;
            this.textLoanAccount.Size = new System.Drawing.Size(170, 27);
            this.textLoanAccount.TabIndex = 14;
            // 
            // labelSendLoanTo
            // 
            this.labelSendLoanTo.AutoSize = true;
            this.labelSendLoanTo.Location = new System.Drawing.Point(34, 218);
            this.labelSendLoanTo.Name = "labelSendLoanTo";
            this.labelSendLoanTo.Size = new System.Drawing.Size(95, 20);
            this.labelSendLoanTo.TabIndex = 13;
            this.labelSendLoanTo.Text = "LoanAccount";
            // 
            // toAccount1
            // 
            this.toAccount1.Location = new System.Drawing.Point(128, 254);
            this.toAccount1.Name = "toAccount1";
            this.toAccount1.Size = new System.Drawing.Size(170, 27);
            this.toAccount1.TabIndex = 16;
            // 
            // ToAccount
            // 
            this.ToAccount.AutoSize = true;
            this.ToAccount.Location = new System.Drawing.Point(34, 257);
            this.ToAccount.Name = "ToAccount";
            this.ToAccount.Size = new System.Drawing.Size(79, 20);
            this.ToAccount.TabIndex = 15;
            this.ToAccount.Text = "ToAccount";
            // 
            // LoanAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 333);
            this.Controls.Add(this.toAccount1);
            this.Controls.Add(this.ToAccount);
            this.Controls.Add(this.textLoanAccount);
            this.Controls.Add(this.labelSendLoanTo);
            this.Controls.Add(this.repayLoanButton);
            this.Controls.Add(this.remainingBalanceLabel);
            this.Controls.Add(this.remainingBalanceTextBox);
            this.Controls.Add(this.transferList);
            this.Controls.Add(this.loanCostLabel);
            this.Controls.Add(this.loanInterestRateValueLabel);
            this.Controls.Add(this.loanAmountValueLabel);
            this.Controls.Add(this.loanInterestRateTrackBar);
            this.Controls.Add(this.loanAmountTrackBar);
            this.Controls.Add(this.loanInterestRateLabel);
            this.Controls.Add(this.loanAmountLabel);
            this.Controls.Add(this.takeLoanButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoanAccount";
            this.Text = "Loan Account";
            ((System.ComponentModel.ISupportInitialize)(this.loanAmountTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanInterestRateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button takeLoanButton;
        private System.Windows.Forms.Label loanAmountLabel;
        private System.Windows.Forms.Label loanInterestRateLabel;
        private System.Windows.Forms.TrackBar loanAmountTrackBar;
        private System.Windows.Forms.TrackBar loanInterestRateTrackBar;
        private System.Windows.Forms.Label loanAmountValueLabel;
        private System.Windows.Forms.Label loanInterestRateValueLabel;
        private System.Windows.Forms.Label loanCostLabel;
        private System.Windows.Forms.ListBox transferList;
        private System.Windows.Forms.TextBox remainingBalanceTextBox;
        private System.Windows.Forms.Label remainingBalanceLabel;
        private System.Windows.Forms.Button repayLoanButton;
        private System.Windows.Forms.TextBox textLoanAccount;
        private System.Windows.Forms.Label labelSendLoanTo;
        private System.Windows.Forms.TextBox toAccount1;
        private System.Windows.Forms.Label ToAccount;
    }
}
