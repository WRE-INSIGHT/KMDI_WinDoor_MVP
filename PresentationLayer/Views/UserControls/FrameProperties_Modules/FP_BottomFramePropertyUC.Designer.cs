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
            this.chk_botFrame = new System.Windows.Forms.CheckBox();
            this.lbl_botFrameProfile = new System.Windows.Forms.Label();
            this.cmb_botFrameProfile = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_header.Location = new System.Drawing.Point(4, 6);
            this.lbl_header.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(118, 21);
            this.lbl_header.TabIndex = 13;
            this.lbl_header.Text = "Bottom Frame";
            // 
            // chk_botFrame
            // 
            this.chk_botFrame.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_botFrame.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_botFrame.FlatAppearance.BorderSize = 0;
            this.chk_botFrame.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_botFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_botFrame.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_botFrame.Location = new System.Drawing.Point(130, 4);
            this.chk_botFrame.Margin = new System.Windows.Forms.Padding(4);
            this.chk_botFrame.Name = "chk_botFrame";
            this.chk_botFrame.Size = new System.Drawing.Size(67, 26);
            this.chk_botFrame.TabIndex = 14;
            this.chk_botFrame.Text = "Y";
            this.chk_botFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_botFrame.UseVisualStyleBackColor = false;
            this.chk_botFrame.CheckedChanged += new System.EventHandler(this.chk_botFrame_CheckedChanged);
            // 
            // lbl_botFrameProfile
            // 
            this.lbl_botFrameProfile.AutoSize = true;
            this.lbl_botFrameProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_botFrameProfile.Location = new System.Drawing.Point(-1, 41);
            this.lbl_botFrameProfile.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.lbl_botFrameProfile.Name = "lbl_botFrameProfile";
            this.lbl_botFrameProfile.Size = new System.Drawing.Size(79, 20);
            this.lbl_botFrameProfile.TabIndex = 16;
            this.lbl_botFrameProfile.Text = "Article No.";
            // 
            // cmb_botFrameProfile
            // 
            this.cmb_botFrameProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_botFrameProfile.FormattingEnabled = true;
            this.cmb_botFrameProfile.Location = new System.Drawing.Point(83, 39);
            this.cmb_botFrameProfile.Margin = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.cmb_botFrameProfile.Name = "cmb_botFrameProfile";
            this.cmb_botFrameProfile.Size = new System.Drawing.Size(120, 24);
            this.cmb_botFrameProfile.TabIndex = 15;
            // 
            // FP_BottomFramePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_botFrameProfile);
            this.Controls.Add(this.cmb_botFrameProfile);
            this.Controls.Add(this.chk_botFrame);
            this.Controls.Add(this.lbl_header);
            this.Name = "FP_BottomFramePropertyUC";
            this.Size = new System.Drawing.Size(203, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.CheckBox chk_botFrame;
        private System.Windows.Forms.Label lbl_botFrameProfile;
        private System.Windows.Forms.ComboBox cmb_botFrameProfile;
    }
}
