namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_RollerPropertyUC
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
            this.cmb_Roller = new System.Windows.Forms.ComboBox();
            this.lbl_Roller = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_Roller
            // 
            this.cmb_Roller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Roller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Roller.DropDownWidth = 69;
            this.cmb_Roller.FormattingEnabled = true;
            this.cmb_Roller.Location = new System.Drawing.Point(66, 3);
            this.cmb_Roller.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_Roller.Name = "cmb_Roller";
            this.cmb_Roller.Size = new System.Drawing.Size(75, 21);
            this.cmb_Roller.TabIndex = 37;
            this.cmb_Roller.SelectedValueChanged += new System.EventHandler(this.cmb_Roller_SelectedValueChanged);
            // 
            // lbl_Roller
            // 
            this.lbl_Roller.AutoSize = true;
            this.lbl_Roller.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Roller.Location = new System.Drawing.Point(9, 7);
            this.lbl_Roller.Name = "lbl_Roller";
            this.lbl_Roller.Size = new System.Drawing.Size(37, 13);
            this.lbl_Roller.TabIndex = 36;
            this.lbl_Roller.Text = "Roller";
            // 
            // PP_RollerPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_Roller);
            this.Controls.Add(this.lbl_Roller);
            this.Name = "PP_RollerPropertyUC";
            this.Size = new System.Drawing.Size(150, 28);
            this.Load += new System.EventHandler(this.PP_RollerPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Roller;
        private System.Windows.Forms.Label lbl_Roller;
    }
}
