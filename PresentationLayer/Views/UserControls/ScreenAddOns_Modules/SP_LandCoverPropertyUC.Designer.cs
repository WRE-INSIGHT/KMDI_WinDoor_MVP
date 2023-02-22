namespace PresentationLayer.Views.UserControls.ScreenAddOns_Modules
{
    partial class SP_LandCoverPropertyUC
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
            this.lbl_LandCover = new System.Windows.Forms.Label();
            this.nud_LandCover = new System.Windows.Forms.NumericUpDown();
            this.nud_LandCoverQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LandCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LandCoverQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_LandCover
            // 
            this.lbl_LandCover.AutoSize = true;
            this.lbl_LandCover.Location = new System.Drawing.Point(5, 10);
            this.lbl_LandCover.Name = "lbl_LandCover";
            this.lbl_LandCover.Size = new System.Drawing.Size(65, 13);
            this.lbl_LandCover.TabIndex = 0;
            this.lbl_LandCover.Text = "L and Cover";
            // 
            // nud_LandCover
            // 
            this.nud_LandCover.Location = new System.Drawing.Point(8, 26);
            this.nud_LandCover.Name = "nud_LandCover";
            this.nud_LandCover.Size = new System.Drawing.Size(68, 20);
            this.nud_LandCover.TabIndex = 1;
            // 
            // nud_LandCoverQty
            // 
            this.nud_LandCoverQty.Location = new System.Drawing.Point(116, 26);
            this.nud_LandCoverQty.Name = "nud_LandCoverQty";
            this.nud_LandCoverQty.Size = new System.Drawing.Size(62, 20);
            this.nud_LandCoverQty.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Qty";
            // 
            // SP_LandCoverPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nud_LandCoverQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_LandCover);
            this.Controls.Add(this.lbl_LandCover);
            this.Name = "SP_LandCoverPropertyUC";
            this.Size = new System.Drawing.Size(205, 50);
            this.Load += new System.EventHandler(this.SP_LandCoverPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_LandCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LandCoverQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LandCover;
        private System.Windows.Forms.NumericUpDown nud_LandCover;
        private System.Windows.Forms.NumericUpDown nud_LandCoverQty;
        private System.Windows.Forms.Label label2;
    }
}
