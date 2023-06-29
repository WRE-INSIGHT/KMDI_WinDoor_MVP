namespace PresentationLayer.Views
{
    partial class PriceHistoryView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_PriceHistory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_priceHistory = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_PriceHistory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 33);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Date";
            // 
            // cmb_PriceHistory
            // 
            this.cmb_PriceHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_PriceHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PriceHistory.FormattingEnabled = true;
            this.cmb_PriceHistory.Location = new System.Drawing.Point(46, 6);
            this.cmb_PriceHistory.Name = "cmb_PriceHistory";
            this.cmb_PriceHistory.Size = new System.Drawing.Size(215, 21);
            this.cmb_PriceHistory.TabIndex = 61;
            this.cmb_PriceHistory.SelectedValueChanged += new System.EventHandler(this.cmb_PriceHistory_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.lbl_priceHistory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 295);
            this.panel2.TabIndex = 1;
            // 
            // lbl_priceHistory
            // 
            this.lbl_priceHistory.AutoSize = true;
            this.lbl_priceHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_priceHistory.Location = new System.Drawing.Point(0, 0);
            this.lbl_priceHistory.Name = "lbl_priceHistory";
            this.lbl_priceHistory.Size = new System.Drawing.Size(0, 13);
            this.lbl_priceHistory.TabIndex = 63;
            // 
            // PriceHistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(791, 328);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PriceHistoryView";
            this.Text = "Price History";
            this.Load += new System.EventHandler(this.PriceHistoryView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_PriceHistory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_priceHistory;
    }
}