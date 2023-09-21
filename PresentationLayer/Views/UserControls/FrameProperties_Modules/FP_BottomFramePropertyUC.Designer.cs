namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_BottomFramePropertyUC
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
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_botFrameProfile = new System.Windows.Forms.Label();
            this.cmb_botFrameProfile = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_header.Location = new System.Drawing.Point(3, 5);
            this.lbl_header.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(96, 17);
            this.lbl_header.TabIndex = 13;
            this.lbl_header.Text = "Bottom Frame";
            // 
            // lbl_botFrameProfile
            // 
            this.lbl_botFrameProfile.AutoSize = true;
            this.lbl_botFrameProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_botFrameProfile.Location = new System.Drawing.Point(-1, 33);
            this.lbl_botFrameProfile.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_botFrameProfile.Name = "lbl_botFrameProfile";
            this.lbl_botFrameProfile.Size = new System.Drawing.Size(63, 15);
            this.lbl_botFrameProfile.TabIndex = 16;
            this.lbl_botFrameProfile.Text = "Article No.";
            // 
            // cmb_botFrameProfile
            // 
            this.cmb_botFrameProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_botFrameProfile.FormattingEnabled = true;
            this.cmb_botFrameProfile.Location = new System.Drawing.Point(62, 32);
            this.cmb_botFrameProfile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_botFrameProfile.Name = "cmb_botFrameProfile";
            this.cmb_botFrameProfile.Size = new System.Drawing.Size(91, 21);
            this.cmb_botFrameProfile.TabIndex = 15;
            this.cmb_botFrameProfile.SelectedValueChanged += new System.EventHandler(this.cmb_botFrameProfile_SelectedValueChanged);
            this.cmb_botFrameProfile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_botFrameProfile_KeyPress);
            this.cmb_botFrameProfile.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_botFrameProfile_Mousewheel);
            // 
            // FP_BottomFramePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_botFrameProfile);
            this.Controls.Add(this.cmb_botFrameProfile);
            this.Controls.Add(this.lbl_header);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FP_BottomFramePropertyUC";
            this.Size = new System.Drawing.Size(152, 58);
            this.Load += new System.EventHandler(this.FP_BottomFramePropertyUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_botFrameProfile;
        private System.Windows.Forms.ComboBox cmb_botFrameProfile;
    }
}
