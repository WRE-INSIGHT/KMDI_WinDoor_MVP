namespace PresentationLayer.Views.UserControls
{
    partial class ScreenAddOnPropertiesUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_addMats = new System.Windows.Forms.Button();
            this.lbl_addOns = new System.Windows.Forms.Label();
            this.pnl_addOns = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btn_addMats);
            this.panel5.Controls.Add(this.lbl_addOns);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(227, 33);
            this.panel5.TabIndex = 28;
            // 
            // btn_addMats
            // 
            this.btn_addMats.Location = new System.Drawing.Point(153, 3);
            this.btn_addMats.Name = "btn_addMats";
            this.btn_addMats.Size = new System.Drawing.Size(70, 26);
            this.btn_addMats.TabIndex = 27;
            this.btn_addMats.Text = "Add";
            this.btn_addMats.UseVisualStyleBackColor = true;
            this.btn_addMats.Click += new System.EventHandler(this.btn_addMats_Click);
            // 
            // lbl_addOns
            // 
            this.lbl_addOns.AutoSize = true;
            this.lbl_addOns.Location = new System.Drawing.Point(8, 10);
            this.lbl_addOns.Name = "lbl_addOns";
            this.lbl_addOns.Size = new System.Drawing.Size(46, 13);
            this.lbl_addOns.TabIndex = 26;
            this.lbl_addOns.Text = "Add ons";
            // 
            // pnl_addOns
            // 
            this.pnl_addOns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_addOns.Location = new System.Drawing.Point(0, 33);
            this.pnl_addOns.Name = "pnl_addOns";
            this.pnl_addOns.Size = new System.Drawing.Size(227, 203);
            this.pnl_addOns.TabIndex = 29;
            // 
            // ScreenAddOnPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_addOns);
            this.Controls.Add(this.panel5);
            this.Name = "ScreenAddOnPropertiesUC";
            this.Size = new System.Drawing.Size(227, 236);
            this.Load += new System.EventHandler(this.ScreenAddOnPropertiesUC_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_addOns;
        private System.Windows.Forms.Button btn_addMats;
        private System.Windows.Forms.Panel pnl_addOns;
    }
}
