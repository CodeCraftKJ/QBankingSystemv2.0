
namespace QBankingSystemv2._0.Forms
{
    partial class Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
            this.TransfersList = new System.Windows.Forms.ListBox();
            this.AccountBox = new System.Windows.Forms.TextBox();
            this.TransfersBtn = new System.Windows.Forms.Button();
            this.LoansBtn = new System.Windows.Forms.Button();
            this.HistoryToFile = new System.Windows.Forms.Button();
            this.TransfersFromFileBtn = new System.Windows.Forms.Button();
            this.Balance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TransfersList
            // 
            this.TransfersList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TransfersList.BackColor = System.Drawing.Color.MintCream;
            this.TransfersList.Font = new System.Drawing.Font("Stencil", 13.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TransfersList.ForeColor = System.Drawing.Color.ForestGreen;
            this.TransfersList.FormattingEnabled = true;
            this.TransfersList.ItemHeight = 26;
            this.TransfersList.Location = new System.Drawing.Point(12, 227);
            this.TransfersList.Name = "TransfersList";
            this.TransfersList.Size = new System.Drawing.Size(601, 264);
            this.TransfersList.TabIndex = 67;
            // 
            // AccountBox
            // 
            this.AccountBox.Enabled = false;
            this.AccountBox.Font = new System.Drawing.Font("Stencil", 13.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AccountBox.ForeColor = System.Drawing.Color.Green;
            this.AccountBox.Location = new System.Drawing.Point(77, 83);
            this.AccountBox.Name = "AccountBox";
            this.AccountBox.Size = new System.Drawing.Size(470, 33);
            this.AccountBox.TabIndex = 68;
            // 
            // TransfersBtn
            // 
            this.TransfersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransfersBtn.BackColor = System.Drawing.Color.Azure;
            this.TransfersBtn.Font = new System.Drawing.Font("Stencil", 11.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TransfersBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.TransfersBtn.Location = new System.Drawing.Point(159, 495);
            this.TransfersBtn.Name = "TransfersBtn";
            this.TransfersBtn.Size = new System.Drawing.Size(158, 58);
            this.TransfersBtn.TabIndex = 70;
            this.TransfersBtn.Text = "Transfers";
            this.TransfersBtn.UseVisualStyleBackColor = false;
            this.TransfersBtn.Click += new System.EventHandler(this.TransfersBtn_Click);
            // 
            // LoansBtn
            // 
            this.LoansBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoansBtn.BackColor = System.Drawing.Color.Azure;
            this.LoansBtn.Font = new System.Drawing.Font("Stencil", 11.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LoansBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.LoansBtn.Location = new System.Drawing.Point(154, 559);
            this.LoansBtn.Name = "LoansBtn";
            this.LoansBtn.Size = new System.Drawing.Size(163, 53);
            this.LoansBtn.TabIndex = 71;
            this.LoansBtn.Text = "Loans";
            this.LoansBtn.UseVisualStyleBackColor = false;
            this.LoansBtn.Click += new System.EventHandler(this.LoansBtn_Click);
            // 
            // HistoryToFile
            // 
            this.HistoryToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryToFile.BackColor = System.Drawing.Color.Azure;
            this.HistoryToFile.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HistoryToFile.ForeColor = System.Drawing.Color.ForestGreen;
            this.HistoryToFile.Location = new System.Drawing.Point(323, 559);
            this.HistoryToFile.Name = "HistoryToFile";
            this.HistoryToFile.Size = new System.Drawing.Size(163, 53);
            this.HistoryToFile.TabIndex = 72;
            this.HistoryToFile.Text = "History To File";
            this.HistoryToFile.UseVisualStyleBackColor = false;
            this.HistoryToFile.Click += new System.EventHandler(this.HistoryToFile_Click);
            // 
            // TransfersFromFileBtn
            // 
            this.TransfersFromFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransfersFromFileBtn.BackColor = System.Drawing.Color.Azure;
            this.TransfersFromFileBtn.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TransfersFromFileBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.TransfersFromFileBtn.Location = new System.Drawing.Point(323, 496);
            this.TransfersFromFileBtn.Name = "TransfersFromFileBtn";
            this.TransfersFromFileBtn.Size = new System.Drawing.Size(163, 58);
            this.TransfersFromFileBtn.TabIndex = 73;
            this.TransfersFromFileBtn.Text = "Transfers from File";
            this.TransfersFromFileBtn.UseVisualStyleBackColor = false;
            this.TransfersFromFileBtn.Click += new System.EventHandler(this.TransfersFromFileBtn_Click);
            // 
            // Balance
            // 
            this.Balance.Enabled = false;
            this.Balance.Font = new System.Drawing.Font("Stencil", 13.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Balance.ForeColor = System.Drawing.Color.Green;
            this.Balance.Location = new System.Drawing.Point(12, 187);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(601, 33);
            this.Balance.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 8.4F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Balance:";
            // 
            // AccountName
            // 
            this.AccountName.Enabled = false;
            this.AccountName.Font = new System.Drawing.Font("Stencil", 13.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AccountName.ForeColor = System.Drawing.Color.Green;
            this.AccountName.Location = new System.Drawing.Point(77, 22);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(470, 33);
            this.AccountName.TabIndex = 76;
            this.AccountName.TextChanged += new System.EventHandler(this.G_TextChanged);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(625, 624);
            this.Controls.Add(this.AccountName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.TransfersFromFileBtn);
            this.Controls.Add(this.HistoryToFile);
            this.Controls.Add(this.LoansBtn);
            this.Controls.Add(this.TransfersBtn);
            this.Controls.Add(this.AccountBox);
            this.Controls.Add(this.TransfersList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Account";
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox TransfersList;
        private System.Windows.Forms.TextBox AccountBox;
        private System.Windows.Forms.Button TransfersBtn;
        private System.Windows.Forms.Button LoansBtn;
        private System.Windows.Forms.Button HistoryToFile;
        private System.Windows.Forms.Button TransfersFromFileBtn;
        private System.Windows.Forms.TextBox Balance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AccountName;
    }
}