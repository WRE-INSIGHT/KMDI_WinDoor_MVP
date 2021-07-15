namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_SashPropertyUC
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
            this.cmb_SashReinf = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_SashProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_SashReinf
            // 
            this.cmb_SashReinf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SashReinf.FormattingEnabled = true;
            this.cmb_SashReinf.Location = new System.Drawing.Point(76, 28);
            this.cmb_SashReinf.Name = "cmb_SashReinf";
            this.cmb_SashReinf.Size = new System.Drawing.Size(72, 21);
            this.cmb_SashReinf.TabIndex = 16;
            this.cmb_SashReinf.SelectedValueChanged += new System.EventHandler(this.cmb_SashReinf_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Sash Reinf";
            // 
            // cmb_SashProfile
            // 
            this.cmb_SashProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SashProfile.FormattingEnabled = true;
            this.cmb_SashProfile.Location = new System.Drawing.Point(76, 3);
            this.cmb_SashProfile.Name = "cmb_SashProfile";
            this.cmb_SashProfile.Size = new System.Drawing.Size(72, 21);
            this.cmb_SashProfile.TabIndex = 14;
            this.cmb_SashProfile.SelectedValueChanged += new System.EventHandler(this.cmb_SashProfile_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sash Profile";
            // 
            // PP_SashPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_SashReinf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_SashProfile);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_SashPropertyUC";
            this.Size = new System.Drawing.Size(154, 53);
            this.Load += new System.EventHandler(this.PP_SashPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_SashReinf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_SashProfile;
        private System.Windows.Forms.Label label3;
    }
}
