namespace PresentationLayer.Views.UserControls
{
    partial class Panel_PropertiesUC
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
            this.lbl_pnlname = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.chk_Orientation = new System.Windows.Forms.CheckBox();
            this.num_BladeCount = new System.Windows.Forms.NumericUpDown();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.pnum_Width = new System.Windows.Forms.NumericUpDown();
            this.pnum_Height = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.lbl_PanelGlassID = new System.Windows.Forms.Label();
            this.flp_PanelSpecs = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_pnlSpecs = new System.Windows.Forms.Label();
            this.pnl_Sash = new System.Windows.Forms.Panel();
            this.cmb_SashReinf = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_SashProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_glassthick = new System.Windows.Forms.Label();
            this.cmb_GlassThick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_GlazingArtNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_FilmType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_BladeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Height)).BeginInit();
            this.flp_PanelSpecs.SuspendLayout();
            this.pnl_Sash.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_pnlname
            // 
            this.lbl_pnlname.AutoSize = true;
            this.lbl_pnlname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pnlname.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pnlname.Location = new System.Drawing.Point(7, 24);
            this.lbl_pnlname.Name = "lbl_pnlname";
            this.lbl_pnlname.Size = new System.Drawing.Size(90, 15);
            this.lbl_pnlname.TabIndex = 0;
            this.lbl_pnlname.Text = "FixedPanelUC_1";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Type.Location = new System.Drawing.Point(7, 45);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(87, 13);
            this.lbl_Type.TabIndex = 1;
            this.lbl_Type.Text = "Tilt&Turn Panel";
            this.lbl_Type.UseMnemonic = false;
            // 
            // chk_Orientation
            // 
            this.chk_Orientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Orientation.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Orientation.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chk_Orientation.FlatAppearance.BorderSize = 0;
            this.chk_Orientation.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.chk_Orientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_Orientation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Orientation.Location = new System.Drawing.Point(101, 41);
            this.chk_Orientation.Name = "chk_Orientation";
            this.chk_Orientation.Size = new System.Drawing.Size(50, 21);
            this.chk_Orientation.TabIndex = 2;
            this.chk_Orientation.Text = "Norm";
            this.chk_Orientation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Orientation.UseVisualStyleBackColor = false;
            this.chk_Orientation.CheckedChanged += new System.EventHandler(this.chk_Orientation_CheckedChanged);
            // 
            // num_BladeCount
            // 
            this.num_BladeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_BladeCount.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.num_BladeCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_BladeCount.Location = new System.Drawing.Point(101, 40);
            this.num_BladeCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_BladeCount.Name = "num_BladeCount";
            this.num_BladeCount.Size = new System.Drawing.Size(50, 22);
            this.num_BladeCount.TabIndex = 3;
            this.num_BladeCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_BladeCount.Visible = false;
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Width.Location = new System.Drawing.Point(7, 61);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(39, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // pnum_Width
            // 
            this.pnum_Width.Enabled = false;
            this.pnum_Width.Location = new System.Drawing.Point(7, 78);
            this.pnum_Width.Name = "pnum_Width";
            this.pnum_Width.Size = new System.Drawing.Size(135, 20);
            this.pnum_Width.TabIndex = 5;
            // 
            // pnum_Height
            // 
            this.pnum_Height.Enabled = false;
            this.pnum_Height.Location = new System.Drawing.Point(7, 118);
            this.pnum_Height.Name = "pnum_Height";
            this.pnum_Height.Size = new System.Drawing.Size(135, 20);
            this.pnum_Height.TabIndex = 7;
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Height.Location = new System.Drawing.Point(7, 102);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(42, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // lbl_PanelGlassID
            // 
            this.lbl_PanelGlassID.AutoSize = true;
            this.lbl_PanelGlassID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_PanelGlassID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PanelGlassID.Location = new System.Drawing.Point(7, 2);
            this.lbl_PanelGlassID.Name = "lbl_PanelGlassID";
            this.lbl_PanelGlassID.Size = new System.Drawing.Size(28, 21);
            this.lbl_PanelGlassID.TabIndex = 9;
            this.lbl_PanelGlassID.Text = "P1";
            // 
            // flp_PanelSpecs
            // 
            this.flp_PanelSpecs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_PanelSpecs.Controls.Add(this.lbl_pnlSpecs);
            this.flp_PanelSpecs.Controls.Add(this.pnl_Sash);
            this.flp_PanelSpecs.Controls.Add(this.lbl_glassthick);
            this.flp_PanelSpecs.Controls.Add(this.cmb_GlassThick);
            this.flp_PanelSpecs.Controls.Add(this.label1);
            this.flp_PanelSpecs.Controls.Add(this.cmb_GlazingArtNo);
            this.flp_PanelSpecs.Controls.Add(this.label2);
            this.flp_PanelSpecs.Controls.Add(this.cmb_FilmType);
            this.flp_PanelSpecs.Location = new System.Drawing.Point(7, 144);
            this.flp_PanelSpecs.Name = "flp_PanelSpecs";
            this.flp_PanelSpecs.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flp_PanelSpecs.Size = new System.Drawing.Size(147, 166);
            this.flp_PanelSpecs.TabIndex = 14;
            // 
            // lbl_pnlSpecs
            // 
            this.lbl_pnlSpecs.AutoSize = true;
            this.lbl_pnlSpecs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pnlSpecs.Location = new System.Drawing.Point(3, 4);
            this.lbl_pnlSpecs.Name = "lbl_pnlSpecs";
            this.lbl_pnlSpecs.Size = new System.Drawing.Size(112, 15);
            this.lbl_pnlSpecs.TabIndex = 8;
            this.lbl_pnlSpecs.Text = "Panel Specification";
            // 
            // pnl_Sash
            // 
            this.pnl_Sash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Sash.Controls.Add(this.cmb_SashReinf);
            this.pnl_Sash.Controls.Add(this.label4);
            this.pnl_Sash.Controls.Add(this.cmb_SashProfile);
            this.pnl_Sash.Controls.Add(this.label3);
            this.pnl_Sash.Location = new System.Drawing.Point(3, 22);
            this.pnl_Sash.Name = "pnl_Sash";
            this.pnl_Sash.Size = new System.Drawing.Size(140, 53);
            this.pnl_Sash.TabIndex = 15;
            // 
            // cmb_SashReinf
            // 
            this.cmb_SashReinf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SashReinf.FormattingEnabled = true;
            this.cmb_SashReinf.Location = new System.Drawing.Point(66, 27);
            this.cmb_SashReinf.Name = "cmb_SashReinf";
            this.cmb_SashReinf.Size = new System.Drawing.Size(72, 21);
            this.cmb_SashReinf.TabIndex = 12;
            this.cmb_SashReinf.SelectedValueChanged += new System.EventHandler(this.cmb_SashReinf_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sash Reinf";
            // 
            // cmb_SashProfile
            // 
            this.cmb_SashProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SashProfile.FormattingEnabled = true;
            this.cmb_SashProfile.Location = new System.Drawing.Point(66, 2);
            this.cmb_SashProfile.Name = "cmb_SashProfile";
            this.cmb_SashProfile.Size = new System.Drawing.Size(72, 21);
            this.cmb_SashProfile.TabIndex = 10;
            this.cmb_SashProfile.SelectedValueChanged += new System.EventHandler(this.cmb_SashProfile_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sash Profile";
            // 
            // lbl_glassthick
            // 
            this.lbl_glassthick.AutoSize = true;
            this.lbl_glassthick.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_glassthick.Location = new System.Drawing.Point(3, 81);
            this.lbl_glassthick.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_glassthick.Name = "lbl_glassthick";
            this.lbl_glassthick.Size = new System.Drawing.Size(64, 13);
            this.lbl_glassthick.TabIndex = 16;
            this.lbl_glassthick.Text = "Glass Thick";
            // 
            // cmb_GlassThick
            // 
            this.cmb_GlassThick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlassThick.FormattingEnabled = true;
            this.cmb_GlassThick.Location = new System.Drawing.Point(73, 78);
            this.cmb_GlassThick.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_GlassThick.Name = "cmb_GlassThick";
            this.cmb_GlassThick.Size = new System.Drawing.Size(68, 21);
            this.cmb_GlassThick.TabIndex = 17;
            this.cmb_GlassThick.SelectedValueChanged += new System.EventHandler(this.cmb_GlassThick_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Glazing Art.No";
            // 
            // cmb_GlazingArtNo
            // 
            this.cmb_GlazingArtNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GlazingArtNo.FormattingEnabled = true;
            this.cmb_GlazingArtNo.Items.AddRange(new object[] {
            "6-8mm",
            "10mm",
            "10.76-14mm",
            "16mm",
            "18mm",
            "20mm",
            "22mm",
            "25mm"});
            this.cmb_GlazingArtNo.Location = new System.Drawing.Point(73, 105);
            this.cmb_GlazingArtNo.Name = "cmb_GlazingArtNo";
            this.cmb_GlazingArtNo.Size = new System.Drawing.Size(68, 21);
            this.cmb_GlazingArtNo.TabIndex = 19;
            this.cmb_GlazingArtNo.SelectedValueChanged += new System.EventHandler(this.cmb_GlazingArtNo_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Film type";
            // 
            // cmb_FilmType
            // 
            this.cmb_FilmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FilmType.DropDownWidth = 100;
            this.cmb_FilmType.FormattingEnabled = true;
            this.cmb_FilmType.Location = new System.Drawing.Point(73, 134);
            this.cmb_FilmType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmb_FilmType.Name = "cmb_FilmType";
            this.cmb_FilmType.Size = new System.Drawing.Size(68, 21);
            this.cmb_FilmType.TabIndex = 21;
            this.cmb_FilmType.SelectedValueChanged += new System.EventHandler(this.cmb_FilmType_SelectedValueChanged);
            // 
            // Panel_PropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flp_PanelSpecs);
            this.Controls.Add(this.lbl_PanelGlassID);
            this.Controls.Add(this.pnum_Height);
            this.Controls.Add(this.lbl_Height);
            this.Controls.Add(this.pnum_Width);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_pnlname);
            this.Controls.Add(this.chk_Orientation);
            this.Controls.Add(this.num_BladeCount);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Panel_PropertiesUC";
            this.Size = new System.Drawing.Size(159, 315);
            this.Load += new System.EventHandler(this.PanelPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_BladeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnum_Height)).EndInit();
            this.flp_PanelSpecs.ResumeLayout(false);
            this.flp_PanelSpecs.PerformLayout();
            this.pnl_Sash.ResumeLayout(false);
            this.pnl_Sash.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pnlname;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.CheckBox chk_Orientation;
        private System.Windows.Forms.NumericUpDown num_BladeCount;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown pnum_Width;
        private System.Windows.Forms.NumericUpDown pnum_Height;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.Label lbl_PanelGlassID;
        private System.Windows.Forms.FlowLayoutPanel flp_PanelSpecs;
        private System.Windows.Forms.Label lbl_pnlSpecs;
        private System.Windows.Forms.Panel pnl_Sash;
        private System.Windows.Forms.ComboBox cmb_SashReinf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_SashProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_glassthick;
        private System.Windows.Forms.ComboBox cmb_GlassThick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_GlazingArtNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_FilmType;
    }
}
