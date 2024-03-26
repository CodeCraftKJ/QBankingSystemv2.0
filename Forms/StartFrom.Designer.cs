
namespace QBankingSystemv2._0
{
    partial class StartFrom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartFrom));
            this.pBoxLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxLoading
            // 
            this.pBoxLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxLoading.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.pBoxLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("pBoxLoading.Image")));
            this.pBoxLoading.Location = new System.Drawing.Point(0, 0);
            this.pBoxLoading.Name = "pBoxLoading";
            this.pBoxLoading.Size = new System.Drawing.Size(800, 450);
            this.pBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxLoading.TabIndex = 0;
            this.pBoxLoading.TabStop = false;
            // 
            // StartFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pBoxLoading);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "QPayApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxLoading;
    }
}

