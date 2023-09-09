namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_CenterProfilePropertyUC
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
            this.cmb_CenterProfileArtNo = new System.Windows.Forms.ComboBox();
            this.lbl_centerProfile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_CenterProfileArtNo
            // 
            this.cmb_CenterProfileArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_CenterProfileArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CenterProfileArtNo.FormattingEnabled = true;
            this.cmb_CenterProfileArtNo.Location = new System.Drawing.Point(61, 3);
            this.cmb_CenterProfileArtNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.cmb_CenterProfileArtNo.Name = "cmb_CenterProfileArtNo";
            this.cmb_CenterProfileArtNo.Size = new System.Drawing.Size(85, 21);
            this.cmb_CenterProfileArtNo.TabIndex = 40;
            this.cmb_CenterProfileArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_CenterProfileArtNo_SelectedValueChanged);
            // 
            // lbl_centerProfile
            // 
            this.lbl_centerProfile.Location = new System.Drawing.Point(-2, 0);
            this.lbl_centerProfile.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lbl_centerProfile.Name = "lbl_centerProfile";
            this.lbl_centerProfile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_centerProfile.Size = new System.Drawing.Size(60, 31);
            this.lbl_centerProfile.TabIndex = 39;
            this.lbl_centerProfile.Text = "Center\r\nProfile\r\n";
            this.lbl_centerProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PP_CenterProfilePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_CenterProfileArtNo);
            this.Controls.Add(this.lbl_centerProfile);
            this.Name = "PP_CenterProfilePropertyUC";
            this.Size = new System.Drawing.Size(148, 28);
            this.Load += new System.EventHandler(this.PP_CenterProfilePropertyUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_CenterProfileArtNo;
        private System.Windows.Forms.Label lbl_centerProfile;
    }
}
