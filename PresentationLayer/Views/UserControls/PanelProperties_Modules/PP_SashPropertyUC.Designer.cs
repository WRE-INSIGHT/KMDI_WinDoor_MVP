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
            this.lbl_InOutOrient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_SashReinf
            // 
            this.cmb_SashReinf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_SashReinf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SashReinf.FormattingEnabled = true;
            this.cmb_SashReinf.Location = new System.Drawing.Point(101, 65);
            this.cmb_SashReinf.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_SashReinf.Name = "cmb_SashReinf";
            this.cmb_SashReinf.Size = new System.Drawing.Size(95, 24);
            this.cmb_SashReinf.TabIndex = 16;
            this.cmb_SashReinf.SelectedValueChanged += new System.EventHandler(this.cmb_SashReinf_SelectedValueChanged);
            this.cmb_SashReinf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_SashReinf_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Sash Reinf";
            // 
            // cmb_SashProfile
            // 
            this.cmb_SashProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_SashProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SashProfile.FormattingEnabled = true;
            this.cmb_SashProfile.Location = new System.Drawing.Point(101, 32);
            this.cmb_SashProfile.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_SashProfile.Name = "cmb_SashProfile";
            this.cmb_SashProfile.Size = new System.Drawing.Size(95, 24);
            this.cmb_SashProfile.TabIndex = 14;
            this.cmb_SashProfile.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_SashProfile_DrawItem);
            this.cmb_SashProfile.SelectedValueChanged += new System.EventHandler(this.cmb_SashProfile_SelectedValueChanged);
            this.cmb_SashProfile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_SashProfile_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sash Profile";
            // 
            // lbl_InOutOrient
            // 
            this.lbl_InOutOrient.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_InOutOrient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InOutOrient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_InOutOrient.Location = new System.Drawing.Point(0, 0);
            this.lbl_InOutOrient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_InOutOrient.Name = "lbl_InOutOrient";
            this.lbl_InOutOrient.Size = new System.Drawing.Size(205, 25);
            this.lbl_InOutOrient.TabIndex = 17;
            this.lbl_InOutOrient.Text = "Inward/Outward Orient";
            this.lbl_InOutOrient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PP_SashPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_InOutOrient);
            this.Controls.Add(this.cmb_SashReinf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_SashProfile);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_SashPropertyUC";
            this.Size = new System.Drawing.Size(205, 100);
            this.Load += new System.EventHandler(this.PP_SashPropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_SashReinf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_SashProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_InOutOrient;
    }
}
