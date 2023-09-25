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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LouverBlades)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nud_LouverBlades
            // 
            this.nud_LouverBlades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_LouverBlades.Enabled = false;
            this.nud_LouverBlades.Location = new System.Drawing.Point(75, 4);
            this.nud_LouverBlades.Name = "nud_LouverBlades";
            this.nud_LouverBlades.Size = new System.Drawing.Size(72, 20);
            this.nud_LouverBlades.TabIndex = 41;
            this.nud_LouverBlades.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.nud_LouverBlades_MouseWheel);
            // 
            // lbl_LouverBlades
            // 
            this.lbl_LouverBlades.AutoSize = true;
            this.lbl_LouverBlades.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LouverBlades.Location = new System.Drawing.Point(4, 7);
            this.lbl_LouverBlades.Name = "lbl_LouverBlades";
            this.lbl_LouverBlades.Size = new System.Drawing.Size(68, 13);
            this.lbl_LouverBlades.TabIndex = 40;
            this.lbl_LouverBlades.Text = "Total Blades";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_LouverBlades);
            this.panel1.Controls.Add(this.nud_LouverBlades);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 27);
            this.panel1.TabIndex = 42;
            // 
            // PP_LouverBladesPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PP_LouverBladesPropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_LouverBladesPropertyUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_LouverBlades)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_LouverBlades;
        private System.Windows.Forms.Label lbl_LouverBlades;
        private System.Windows.Forms.Panel panel1;
    }
}
