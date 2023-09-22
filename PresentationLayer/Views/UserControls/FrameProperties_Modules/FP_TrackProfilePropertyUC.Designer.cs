namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_TrackProfilePropertyUC
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
            this.lbl_TrackProfile = new System.Windows.Forms.Label();
            this.cmb_TrackProfile = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_TrackProfile
            // 
            this.lbl_TrackProfile.AutoSize = true;
            this.lbl_TrackProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_TrackProfile.Location = new System.Drawing.Point(1, 5);
            this.lbl_TrackProfile.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_TrackProfile.Name = "lbl_TrackProfile";
            this.lbl_TrackProfile.Size = new System.Drawing.Size(71, 30);
            this.lbl_TrackProfile.TabIndex = 22;
            this.lbl_TrackProfile.Text = "Track Profile\r\nArt. No\r\n";
            this.lbl_TrackProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_TrackProfile
            // 
            this.cmb_TrackProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TrackProfile.FormattingEnabled = true;
            this.cmb_TrackProfile.Location = new System.Drawing.Point(73, 10);
            this.cmb_TrackProfile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_TrackProfile.Name = "cmb_TrackProfile";
            this.cmb_TrackProfile.Size = new System.Drawing.Size(86, 21);
            this.cmb_TrackProfile.TabIndex = 21;
            this.cmb_TrackProfile.SelectedValueChanged += new System.EventHandler(this.cmb_TrackProfile_SelectedValueChanged);
            this.cmb_TrackProfile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_TrackProfile_KeyPress);
            this.cmb_TrackProfile.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_TrackProfile_MouseWheel);
            // 
            // FP_TrackProfilePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_TrackProfile);
            this.Controls.Add(this.cmb_TrackProfile);
            this.Name = "FP_TrackProfilePropertyUC";
            this.Size = new System.Drawing.Size(159, 36);
            this.Load += new System.EventHandler(this.FP_TrackProfilePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TrackProfile;
        private System.Windows.Forms.ComboBox cmb_TrackProfile;
    }
}
