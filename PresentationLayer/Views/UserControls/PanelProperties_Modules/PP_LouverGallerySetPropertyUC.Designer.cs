namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    partial class PP_LouverGallerySetPropertyUC
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
            this.pnl_body = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_addLouver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmb_GalleryColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_HandleLocation = new System.Windows.Forms.ComboBox();
            this.lbl_HandleLocation = new System.Windows.Forms.Label();
            this.cmb_HandleType = new System.Windows.Forms.ComboBox();
            this.lbl_HandleType = new System.Windows.Forms.Label();
            this.nud_NoOfBladePerSet = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_BladeHeight = new System.Windows.Forms.ComboBox();
            this.lbl_BladeHeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_chkMotorizedOptions = new System.Windows.Forms.Panel();
            this.lbl_motorized = new System.Windows.Forms.Label();
            this.chk_Motorized = new System.Windows.Forms.CheckBox();
            this.pnl_body.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NoOfBladePerSet)).BeginInit();
            this.pnl_chkMotorizedOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_body
            // 
            this.pnl_body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_body.Controls.Add(this.panel4);
            this.pnl_body.Controls.Add(this.panel2);
            this.pnl_body.Controls.Add(this.pnl_chkMotorizedOptions);
            this.pnl_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_body.Location = new System.Drawing.Point(0, 0);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(150, 210);
            this.pnl_body.TabIndex = 65;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.btn_addLouver);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 180);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 27);
            this.panel4.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Add Gallery Set";
            // 
            // btn_addLouver
            // 
            this.btn_addLouver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addLouver.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_addLouver.Location = new System.Drawing.Point(95, 0);
            this.btn_addLouver.Name = "btn_addLouver";
            this.btn_addLouver.Size = new System.Drawing.Size(38, 27);
            this.btn_addLouver.TabIndex = 63;
            this.btn_addLouver.Text = "➕";
            this.btn_addLouver.UseVisualStyleBackColor = true;
            this.btn_addLouver.Click += new System.EventHandler(this.btn_addLouver_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmb_GalleryColor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmb_HandleLocation);
            this.panel2.Controls.Add(this.lbl_HandleLocation);
            this.panel2.Controls.Add(this.cmb_HandleType);
            this.panel2.Controls.Add(this.lbl_HandleType);
            this.panel2.Controls.Add(this.nud_NoOfBladePerSet);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_BladeHeight);
            this.panel2.Controls.Add(this.lbl_BladeHeight);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 149);
            this.panel2.TabIndex = 68;
            // 
            // cmb_GalleryColor
            // 
            this.cmb_GalleryColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_GalleryColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GalleryColor.FormattingEnabled = true;
            this.cmb_GalleryColor.Location = new System.Drawing.Point(75, 124);
            this.cmb_GalleryColor.Name = "cmb_GalleryColor";
            this.cmb_GalleryColor.Size = new System.Drawing.Size(70, 21);
            this.cmb_GalleryColor.TabIndex = 62;
            this.cmb_GalleryColor.SelectedValueChanged += new System.EventHandler(this.cmb_GalleryColor_SelectedValueChanged);
            this.cmb_GalleryColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_GalleryColor_KeyPress);
            this.cmb_GalleryColor.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_GalleryColor_MouseWheel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Color";
            // 
            // cmb_HandleLocation
            // 
            this.cmb_HandleLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_HandleLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HandleLocation.FormattingEnabled = true;
            this.cmb_HandleLocation.Location = new System.Drawing.Point(75, 97);
            this.cmb_HandleLocation.Name = "cmb_HandleLocation";
            this.cmb_HandleLocation.Size = new System.Drawing.Size(70, 21);
            this.cmb_HandleLocation.TabIndex = 60;
            this.cmb_HandleLocation.SelectedValueChanged += new System.EventHandler(this.cmb_HandleLocation_SelectedValueChanged);
            this.cmb_HandleLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_HandleLocation_KeyPress);
            this.cmb_HandleLocation.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_HandleLocation_MouseWheel);
            // 
            // lbl_HandleLocation
            // 
            this.lbl_HandleLocation.AutoSize = true;
            this.lbl_HandleLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HandleLocation.Location = new System.Drawing.Point(3, 101);
            this.lbl_HandleLocation.Name = "lbl_HandleLocation";
            this.lbl_HandleLocation.Size = new System.Drawing.Size(64, 13);
            this.lbl_HandleLocation.TabIndex = 59;
            this.lbl_HandleLocation.Text = "Handle Loc";
            // 
            // cmb_HandleType
            // 
            this.cmb_HandleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_HandleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HandleType.FormattingEnabled = true;
            this.cmb_HandleType.Location = new System.Drawing.Point(75, 70);
            this.cmb_HandleType.Name = "cmb_HandleType";
            this.cmb_HandleType.Size = new System.Drawing.Size(70, 21);
            this.cmb_HandleType.TabIndex = 58;
            this.cmb_HandleType.SelectedValueChanged += new System.EventHandler(this.cmb_HandleType_SelectedValueChanged);
            this.cmb_HandleType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_HandleType_KeyPress);
            this.cmb_HandleType.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_HandleType_MouseWheel);
            // 
            // lbl_HandleType
            // 
            this.lbl_HandleType.AutoSize = true;
            this.lbl_HandleType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HandleType.Location = new System.Drawing.Point(3, 73);
            this.lbl_HandleType.Name = "lbl_HandleType";
            this.lbl_HandleType.Size = new System.Drawing.Size(70, 13);
            this.lbl_HandleType.TabIndex = 57;
            this.lbl_HandleType.Text = "Handle Type";
            // 
            // nud_NoOfBladePerSet
            // 
            this.nud_NoOfBladePerSet.Location = new System.Drawing.Point(75, 44);
            this.nud_NoOfBladePerSet.Name = "nud_NoOfBladePerSet";
            this.nud_NoOfBladePerSet.Size = new System.Drawing.Size(72, 20);
            this.nud_NoOfBladePerSet.TabIndex = 56;
            this.nud_NoOfBladePerSet.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.nud_NoOfBladePerSet_MouseWheel);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "No. of Blades";
            // 
            // cmb_BladeHeight
            // 
            this.cmb_BladeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_BladeHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BladeHeight.FormattingEnabled = true;
            this.cmb_BladeHeight.Location = new System.Drawing.Point(75, 17);
            this.cmb_BladeHeight.Name = "cmb_BladeHeight";
            this.cmb_BladeHeight.Size = new System.Drawing.Size(70, 21);
            this.cmb_BladeHeight.TabIndex = 54;
            this.cmb_BladeHeight.SelectedValueChanged += new System.EventHandler(this.cmb_BladeHeight_SelectedValueChanged);
            this.cmb_BladeHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_BladeHeight_KeyPress);
            this.cmb_BladeHeight.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.cmb_BladeHeight_MouseWheel);
            // 
            // lbl_BladeHeight
            // 
            this.lbl_BladeHeight.AutoSize = true;
            this.lbl_BladeHeight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BladeHeight.Location = new System.Drawing.Point(4, 20);
            this.lbl_BladeHeight.Name = "lbl_BladeHeight";
            this.lbl_BladeHeight.Size = new System.Drawing.Size(73, 13);
            this.lbl_BladeHeight.TabIndex = 53;
            this.lbl_BladeHeight.Text = "Blade Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Gallery Set";
            // 
            // pnl_chkMotorizedOptions
            // 
            this.pnl_chkMotorizedOptions.Controls.Add(this.lbl_motorized);
            this.pnl_chkMotorizedOptions.Controls.Add(this.chk_Motorized);
            this.pnl_chkMotorizedOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_chkMotorizedOptions.Location = new System.Drawing.Point(0, 0);
            this.pnl_chkMotorizedOptions.Name = "pnl_chkMotorizedOptions";
            this.pnl_chkMotorizedOptions.Size = new System.Drawing.Size(148, 31);
            this.pnl_chkMotorizedOptions.TabIndex = 72;
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
            // PP_LouverGallerySetPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_body);
            this.Name = "PP_LouverGallerySetPropertyUC";
            this.Size = new System.Drawing.Size(150, 210);
            this.Load += new System.EventHandler(this.PP_LouverGallerySetPropertyUC_Load);
            this.pnl_body.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NoOfBladePerSet)).EndInit();
            this.pnl_chkMotorizedOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_addLouver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_GalleryColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_HandleLocation;
        private System.Windows.Forms.Label lbl_HandleLocation;
        private System.Windows.Forms.ComboBox cmb_HandleType;
        private System.Windows.Forms.Label lbl_HandleType;
        private System.Windows.Forms.NumericUpDown nud_NoOfBladePerSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_BladeHeight;
        private System.Windows.Forms.Label lbl_BladeHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_chkMotorizedOptions;
        private System.Windows.Forms.Label lbl_motorized;
        private System.Windows.Forms.CheckBox chk_Motorized;
    }
}
