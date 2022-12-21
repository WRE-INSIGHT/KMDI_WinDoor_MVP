namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_LouverTypePropertyUC
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
            this.cmb_LouverType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_LouverType
            // 
            this.cmb_LouverType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_LouverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LouverType.FormattingEnabled = true;
            this.cmb_LouverType.Location = new System.Drawing.Point(75, 3);
            this.cmb_LouverType.Name = "cmb_LouverType";
            this.cmb_LouverType.Size = new System.Drawing.Size(72, 21);
            this.cmb_LouverType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Louver Type";
            // 
            // PP_LouverTypePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_LouverType);
            this.Controls.Add(this.label3);
            this.Name = "PP_LouverTypePropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_LouverTypePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_LouverType;
        private System.Windows.Forms.Label label3;
    }
}
