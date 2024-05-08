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
            this.pnl_CenterProfilePanelSelect = new System.Windows.Forms.Panel();
            this.lbl_CenterProfilePanel = new System.Windows.Forms.Label();
            this.btn_SelectCPPanel = new System.Windows.Forms.Button();
            this.pnl_CenterProfilePanelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_CenterProfileArtNo
            // 
            this.cmb_CenterProfileArtNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_CenterProfileArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CenterProfileArtNo.FormattingEnabled = true;
            this.cmb_CenterProfileArtNo.Location = new System.Drawing.Point(81, 4);
            this.cmb_CenterProfileArtNo.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.cmb_CenterProfileArtNo.Name = "cmb_CenterProfileArtNo";
            this.cmb_CenterProfileArtNo.Size = new System.Drawing.Size(112, 24);
            this.cmb_CenterProfileArtNo.TabIndex = 40;
            this.cmb_CenterProfileArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_CenterProfileArtNo_SelectedValueChanged);
            this.cmb_CenterProfileArtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_CenterProfileArtNo_KeyPress);
            this.cmb_CenterProfileArtNo.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_CenterProfileArtNo_MouseWheel);
            // 
            // lbl_centerProfile
            // 
            this.lbl_centerProfile.Location = new System.Drawing.Point(-3, 0);
            this.lbl_centerProfile.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            this.lbl_centerProfile.Name = "lbl_centerProfile";
            this.lbl_centerProfile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_centerProfile.Size = new System.Drawing.Size(80, 38);
            this.lbl_centerProfile.TabIndex = 39;
            this.lbl_centerProfile.Text = "Center\r\nProfile\r\n";
            this.lbl_centerProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_CenterProfilePanelSelect
            // 
            this.pnl_CenterProfilePanelSelect.Controls.Add(this.lbl_CenterProfilePanel);
            this.pnl_CenterProfilePanelSelect.Controls.Add(this.btn_SelectCPPanel);
            this.pnl_CenterProfilePanelSelect.Location = new System.Drawing.Point(0, 34);
            this.pnl_CenterProfilePanelSelect.Name = "pnl_CenterProfilePanelSelect";
            this.pnl_CenterProfilePanelSelect.Size = new System.Drawing.Size(198, 38);
            this.pnl_CenterProfilePanelSelect.TabIndex = 41;
            // 
            // lbl_CenterProfilePanel
            // 
            this.lbl_CenterProfilePanel.AutoSize = true;
            this.lbl_CenterProfilePanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CenterProfilePanel.Location = new System.Drawing.Point(8, 8);
            this.lbl_CenterProfilePanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CenterProfilePanel.Name = "lbl_CenterProfilePanel";
            this.lbl_CenterProfilePanel.Size = new System.Drawing.Size(63, 19);
            this.lbl_CenterProfilePanel.TabIndex = 15;
            this.lbl_CenterProfilePanel.Text = "CP Panel";
            // 
            // btn_SelectCPPanel
            // 
            this.btn_SelectCPPanel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SelectCPPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectCPPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SelectCPPanel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_SelectCPPanel.Location = new System.Drawing.Point(80, 4);
            this.btn_SelectCPPanel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectCPPanel.Name = "btn_SelectCPPanel";
            this.btn_SelectCPPanel.Size = new System.Drawing.Size(113, 28);
            this.btn_SelectCPPanel.TabIndex = 16;
            this.btn_SelectCPPanel.Text = "Select Panel";
            this.btn_SelectCPPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SelectCPPanel.UseVisualStyleBackColor = false;
            this.btn_SelectCPPanel.Click += new System.EventHandler(this.btn_SelectCPPanel_Click);
            // 
            // PP_CenterProfilePropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_CenterProfilePanelSelect);
            this.Controls.Add(this.cmb_CenterProfileArtNo);
            this.Controls.Add(this.lbl_centerProfile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PP_CenterProfilePropertyUC";
            this.Size = new System.Drawing.Size(197, 35);
            this.Load += new System.EventHandler(this.PP_CenterProfilePropertyUC_Load);
            this.pnl_CenterProfilePanelSelect.ResumeLayout(false);
            this.pnl_CenterProfilePanelSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_CenterProfileArtNo;
        private System.Windows.Forms.Label lbl_centerProfile;
        private System.Windows.Forms.Panel pnl_CenterProfilePanelSelect;
        private System.Windows.Forms.Label lbl_CenterProfilePanel;
        private System.Windows.Forms.Button btn_SelectCPPanel;
    }
}
