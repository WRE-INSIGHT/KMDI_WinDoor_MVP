﻿namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    partial class SP_6052MilledProfilePropertyUC
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
            this.nud_6052MilledProfileQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_6052MilledProfile = new System.Windows.Forms.NumericUpDown();
            this.lbl_6052MilledProfile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_6052MilledProfileQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_6052MilledProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_6052MilledProfileQty
            // 
            this.nud_6052MilledProfileQty.Location = new System.Drawing.Point(128, 26);
            this.nud_6052MilledProfileQty.Name = "nud_6052MilledProfileQty";
            this.nud_6052MilledProfileQty.Size = new System.Drawing.Size(62, 20);
            this.nud_6052MilledProfileQty.TabIndex = 41;
            this.nud_6052MilledProfileQty.ValueChanged += new System.EventHandler(this.nud_6052MilledProfileQty_ValueChanged);
            this.nud_6052MilledProfileQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nud_6052MilledProfileQty_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Qty";
            // 
            // nud_6052MilledProfile
            // 
            this.nud_6052MilledProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_6052MilledProfile.Location = new System.Drawing.Point(8, 26);
            this.nud_6052MilledProfile.Name = "nud_6052MilledProfile";
            this.nud_6052MilledProfile.Size = new System.Drawing.Size(87, 20);
            this.nud_6052MilledProfile.TabIndex = 40;
            this.nud_6052MilledProfile.ValueChanged += new System.EventHandler(this.nud_6052MilledProfile_ValueChanged);
            this.nud_6052MilledProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nud_6052MilledProfile_KeyDown);
            // 
            // lbl_6052MilledProfile
            // 
            this.lbl_6052MilledProfile.AutoSize = true;
            this.lbl_6052MilledProfile.Location = new System.Drawing.Point(5, 10);
            this.lbl_6052MilledProfile.Name = "lbl_6052MilledProfile";
            this.lbl_6052MilledProfile.Size = new System.Drawing.Size(96, 13);
            this.lbl_6052MilledProfile.TabIndex = 39;
            this.lbl_6052MilledProfile.Text = "6052  Milled Profile";
            this.lbl_6052MilledProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SP_6052MilledProfilePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.nud_6052MilledProfileQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_6052MilledProfile);
            this.Controls.Add(this.lbl_6052MilledProfile);
            this.Name = "SP_6052MilledProfilePropertyUC";
            this.Size = new System.Drawing.Size(229, 51);
            this.Load += new System.EventHandler(this.SP_6052MilledProfilePropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_6052MilledProfileQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_6052MilledProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_6052MilledProfileQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_6052MilledProfile;
        private System.Windows.Forms.Label lbl_6052MilledProfile;
    }
}
