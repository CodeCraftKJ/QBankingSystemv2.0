
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
            this.TransfersList.Location = new System.Drawing.Point(77, 78);
            this.TransfersList.Name = "TransfersList";
            this.TransfersList.Size = new System.Drawing.Size(470, 264);
            this.TransfersList.TabIndex = 67;
            // 
            // AccountBox
            // 
            this.AccountBox.Enabled = false;
            this.AccountBox.Font = new System.Drawing.Font("Stencil", 13.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AccountBox.ForeColor = System.Drawing.Color.Green;
            this.AccountBox.Location = new System.Drawing.Point(77, 31);
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
            this.TransfersBtn.Location = new System.Drawing.Point(237, 351);
            this.TransfersBtn.Name = "TransfersBtn";
            this.TransfersBtn.Size = new System.Drawing.Size(158, 53);
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
            this.LoansBtn.Location = new System.Drawing.Point(237, 410);
            this.LoansBtn.Name = "LoansBtn";
            this.LoansBtn.Size = new System.Drawing.Size(163, 52);
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
            this.HistoryToFile.Location = new System.Drawing.Point(406, 410);
            this.HistoryToFile.Name = "HistoryToFile";
            this.HistoryToFile.Size = new System.Drawing.Size(163, 52);
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
            this.TransfersFromFileBtn.Location = new System.Drawing.Point(406, 352);
            this.TransfersFromFileBtn.Name = "TransfersFromFileBtn";
            this.TransfersFromFileBtn.Size = new System.Drawing.Size(163, 52);
            this.TransfersFromFileBtn.TabIndex = 73;
            this.TransfersFromFileBtn.Text = "Transfers from File";
            this.TransfersFromFileBtn.UseVisualStyleBackColor = false;
            this.TransfersFromFileBtn.Click += new System.EventHandler(this.TransfersFromFileBtn_Click);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(625, 475);
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
    }
}