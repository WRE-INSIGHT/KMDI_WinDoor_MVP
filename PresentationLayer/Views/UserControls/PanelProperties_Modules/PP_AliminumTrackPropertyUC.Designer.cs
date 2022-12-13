namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_AliminumTrackPropertyUC
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
            this.nud_AluminumTrackQty = new System.Windows.Forms.NumericUpDown();
            this.lbl_AliminumTrack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AluminumTrackQty)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_AluminumTrackQty
            // 
            this.nud_AluminumTrackQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_AluminumTrackQty.Location = new System.Drawing.Point(83, 2);
            this.nud_AluminumTrackQty.Name = "nud_AluminumTrackQty";
            this.nud_AluminumTrackQty.Size = new System.Drawing.Size(66, 20);
            this.nud_AluminumTrackQty.TabIndex = 41;
            this.nud_AluminumTrackQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_AluminumTrackQty.ValueChanged += new System.EventHandler(this.nud_AluminumTrackQty_ValueChanged);
            // 
            // lbl_AliminumTrack
            // 
            this.lbl_AliminumTrack.AutoSize = true;
            this.lbl_AliminumTrack.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AliminumTrack.Location = new System.Drawing.Point(0, 5);
            this.lbl_AliminumTrack.Name = "lbl_AliminumTrack";
            this.lbl_AliminumTrack.Size = new System.Drawing.Size(82, 13);
            this.lbl_AliminumTrack.TabIndex = 40;
            this.lbl_AliminumTrack.Text = "Alum Track Qty";
            // 
            // PP_AliminumTrackPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nud_AluminumTrackQty);
            this.Controls.Add(this.lbl_AliminumTrack);
            this.Name = "PP_AliminumTrackPropertyUC";
            this.Size = new System.Drawing.Size(148, 26);
            this.Load += new System.EventHandler(this.PP_AliminumTrackPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_AluminumTrackQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_AluminumTrackQty;
        private System.Windows.Forms.Label lbl_AliminumTrack;
    }
}
