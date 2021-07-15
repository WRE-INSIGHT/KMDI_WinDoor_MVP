namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_MotorizedPropertyUC
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
            this.lbl_motorized = new System.Windows.Forms.Label();
            this.chk_Motorized = new System.Windows.Forms.CheckBox();
            this.pnl_motorizedOptions = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_MotorizedMechanism = new System.Windows.Forms.ComboBox();
            this.pnl_chkMotorizedOptions = new System.Windows.Forms.Panel();
            this.pnl_motorizedOptions.SuspendLayout();
            this.pnl_chkMotorizedOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_motorized
            // 
            this.lbl_motorized.Location = new System.Drawing.Point(3, 3);
            this.lbl_motorized.Name = "lbl_motorized";
            this.lbl_motorized.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lbl_motorized.Size = new System.Drawing.Size(91, 24);
            this.lbl_motorized.TabIndex = 34;
            this.lbl_motorized.Text = "Motorized";
            this.lbl_motorized.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chk_Motorized
            // 
            this.chk_Motorized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Motorized.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Motorized.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_Motorized.FlatAppearance.BorderSize = 0;
            this.chk_Motorized.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_Motorized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Motorized.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Motorized.Location = new System.Drawing.Point(98, 6);
            this.chk_Motorized.Name = "chk_Motorized";
            this.chk_Motorized.Size = new System.Drawing.Size(50, 21);
            this.chk_Motorized.TabIndex = 35;
            this.chk_Motorized.Text = "No";
            this.chk_Motorized.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Motorized.UseVisualStyleBackColor = false;
            this.chk_Motorized.CheckedChanged += new System.EventHandler(this.chk_Motorized_CheckedChanged);
            // 
            // pnl_motorizedOptions
            // 
            this.pnl_motorizedOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_motorizedOptions.Controls.Add(this.label13);
            this.pnl_motorizedOptions.Controls.Add(this.cmb_MotorizedMechanism);
            this.pnl_motorizedOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_motorizedOptions.Location = new System.Drawing.Point(0, 31);
            this.pnl_motorizedOptions.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnl_motorizedOptions.Name = "pnl_motorizedOptions";
            this.pnl_motorizedOptions.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnl_motorizedOptions.Size = new System.Drawing.Size(154, 41);
            this.pnl_motorizedOptions.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoEllipsis = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 8);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 27);
            this.label13.TabIndex = 19;
            this.label13.Text = "Motorized\r\nMechanism";
            // 
            // cmb_MotorizedMechanism
            // 
            this.cmb_MotorizedMechanism.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MotorizedMechanism.FormattingEnabled = true;
            this.cmb_MotorizedMechanism.Location = new System.Drawing.Point(78, 11);
            this.cmb_MotorizedMechanism.Name = "cmb_MotorizedMechanism";
            this.cmb_MotorizedMechanism.Size = new System.Drawing.Size(69, 21);
            this.cmb_MotorizedMechanism.TabIndex = 20;
            this.cmb_MotorizedMechanism.SelectedValueChanged += new System.EventHandler(this.cmb_MotorizedMechanism_SelectedValueChanged);
            // 
            // pnl_chkMotorizedOptions
            // 
            this.pnl_chkMotorizedOptions.Controls.Add(this.lbl_motorized);
            this.pnl_chkMotorizedOptions.Controls.Add(this.chk_Motorized);
            this.pnl_chkMotorizedOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_chkMotorizedOptions.Location = new System.Drawing.Point(0, 0);
            this.pnl_chkMotorizedOptions.Name = "pnl_chkMotorizedOptions";
            this.pnl_chkMotorizedOptions.Size = new System.Drawing.Size(154, 31);
            this.pnl_chkMotorizedOptions.TabIndex = 37;
            // 
            // PP_MotorizedPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_motorizedOptions);
            this.Controls.Add(this.pnl_chkMotorizedOptions);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PP_MotorizedPropertyUC";
            this.Size = new System.Drawing.Size(154, 72);
            this.Load += new System.EventHandler(this.PP_MotorizedPropertyUC_Load);
            this.pnl_motorizedOptions.ResumeLayout(false);
            this.pnl_chkMotorizedOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_motorized;
        private System.Windows.Forms.CheckBox chk_Motorized;
        private System.Windows.Forms.Panel pnl_motorizedOptions;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_MotorizedMechanism;
        private System.Windows.Forms.Panel pnl_chkMotorizedOptions;
    }
}
