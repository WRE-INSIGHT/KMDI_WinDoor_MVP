namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_LouverBladesPropertyUC
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
            this.nud_LouverBlades = new System.Windows.Forms.NumericUpDown();
            this.lbl_LouverBlades = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LouverBlades)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_LouverBlades
            // 
            this.nud_LouverBlades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_LouverBlades.Enabled = false;
            this.nud_LouverBlades.Location = new System.Drawing.Point(75, 4);
            this.nud_LouverBlades.Name = "nud_LouverBlades";
            this.nud_LouverBlades.Size = new System.Drawing.Size(73, 20);
            this.nud_LouverBlades.TabIndex = 41;
            // 
            // lbl_LouverBlades
            // 
            this.lbl_LouverBlades.AutoSize = true;
            this.lbl_LouverBlades.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LouverBlades.Location = new System.Drawing.Point(1, 8);
            this.lbl_LouverBlades.Name = "lbl_LouverBlades";
            this.lbl_LouverBlades.Size = new System.Drawing.Size(61, 13);
            this.lbl_LouverBlades.TabIndex = 40;
            this.lbl_LouverBlades.Text = "No. Blades";
            // 
            // PP_LouverBladesPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nud_LouverBlades);
            this.Controls.Add(this.lbl_LouverBlades);
            this.Name = "PP_LouverBladesPropertyUC";
            this.Size = new System.Drawing.Size(148, 26);
            this.Load += new System.EventHandler(this.PP_LouverBladesPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_LouverBlades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_LouverBlades;
        private System.Windows.Forms.Label lbl_LouverBlades;
    }
}
