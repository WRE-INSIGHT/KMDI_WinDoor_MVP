namespace PresentationLayer.Views.UserControls
{
    partial class FramePropertiesUC
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
            this.lbl_frameName = new System.Windows.Forms.Label();
            this.rdBtn_Window = new System.Windows.Forms.RadioButton();
            this.rdBtn_Concrete = new System.Windows.Forms.RadioButton();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_fWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_fHeight = new System.Windows.Forms.NumericUpDown();
            this.pnl_specs = new System.Windows.Forms.Panel();
            this.cmb_FrameReinf = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Specs = new System.Windows.Forms.Label();
            this.lbl_FrameProfile = new System.Windows.Forms.Label();
            this.lbl_FrameReinf = new System.Windows.Forms.Label();
            this.cmb_FrameProfile = new System.Windows.Forms.ComboBox();
            this.pnl_frameLbl = new System.Windows.Forms.Panel();
            this.pnl_rdBtnWdw = new System.Windows.Forms.Panel();
            this.rdBtn_Door = new System.Windows.Forms.RadioButton();
            this.pnl_rdBtnDoor = new System.Windows.Forms.Panel();
            this.pnl_rdBtnConcrete = new System.Windows.Forms.Panel();
            this.pnl_Body = new System.Windows.Forms.Panel();
            this.pnl_Dimensions = new System.Windows.Forms.Panel();
            this.pnl_frameProperties = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.num_fWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fHeight)).BeginInit();
            this.pnl_specs.SuspendLayout();
            this.pnl_frameLbl.SuspendLayout();
            this.pnl_rdBtnWdw.SuspendLayout();
            this.pnl_rdBtnDoor.SuspendLayout();
            this.pnl_rdBtnConcrete.SuspendLayout();
            this.pnl_Body.SuspendLayout();
            this.pnl_Dimensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_frameName
            // 
            this.lbl_frameName.AutoSize = true;
            this.lbl_frameName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_frameName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_frameName.Location = new System.Drawing.Point(0, 0);
            this.lbl_frameName.Name = "lbl_frameName";
            this.lbl_frameName.Size = new System.Drawing.Size(65, 21);
            this.lbl_frameName.TabIndex = 0;
            this.lbl_frameName.Text = "Frame 1";
            // 
            // rdBtn_Window
            // 
            this.rdBtn_Window.Location = new System.Drawing.Point(4, 0);
            this.rdBtn_Window.Name = "rdBtn_Window";
            this.rdBtn_Window.Size = new System.Drawing.Size(140, 23);
            this.rdBtn_Window.TabIndex = 1;
            this.rdBtn_Window.Text = "Window";
            this.rdBtn_Window.UseVisualStyleBackColor = true;
            this.rdBtn_Window.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // rdBtn_Concrete
            // 
            this.rdBtn_Concrete.Location = new System.Drawing.Point(4, 0);
            this.rdBtn_Concrete.Name = "rdBtn_Concrete";
            this.rdBtn_Concrete.Size = new System.Drawing.Size(140, 23);
            this.rdBtn_Concrete.TabIndex = 3;
            this.rdBtn_Concrete.TabStop = true;
            this.rdBtn_Concrete.Text = "Concrete";
            this.rdBtn_Concrete.UseVisualStyleBackColor = true;
            this.rdBtn_Concrete.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Location = new System.Drawing.Point(7, 2);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(35, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // num_fWidth
            // 
            this.num_fWidth.Location = new System.Drawing.Point(7, 18);
            this.num_fWidth.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fWidth.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fWidth.Name = "num_fWidth";
            this.num_fWidth.Size = new System.Drawing.Size(135, 20);
            this.num_fWidth.TabIndex = 5;
            this.num_fWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fWidth.ValueChanged += new System.EventHandler(this.num_fWidth_ValueChanged);
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Location = new System.Drawing.Point(7, 42);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(38, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // num_fHeight
            // 
            this.num_fHeight.Location = new System.Drawing.Point(7, 58);
            this.num_fHeight.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fHeight.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fHeight.Name = "num_fHeight";
            this.num_fHeight.Size = new System.Drawing.Size(135, 20);
            this.num_fHeight.TabIndex = 7;
            this.num_fHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fHeight.ValueChanged += new System.EventHandler(this.num_fHeight_ValueChanged_1);
            // 
            // pnl_specs
            // 
            this.pnl_specs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_specs.Controls.Add(this.cmb_FrameReinf);
            this.pnl_specs.Controls.Add(this.label1);
            this.pnl_specs.Controls.Add(this.lbl_Specs);
            this.pnl_specs.Controls.Add(this.lbl_FrameProfile);
            this.pnl_specs.Controls.Add(this.lbl_FrameReinf);
            this.pnl_specs.Controls.Add(this.cmb_FrameProfile);
            this.pnl_specs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_specs.Location = new System.Drawing.Point(0, 81);
            this.pnl_specs.Name = "pnl_specs";
            this.pnl_specs.Size = new System.Drawing.Size(154, 102);
            this.pnl_specs.TabIndex = 12;
            // 
            // cmb_FrameReinf
            // 
            this.cmb_FrameReinf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FrameReinf.FormattingEnabled = true;
            this.cmb_FrameReinf.Location = new System.Drawing.Point(47, 72);
            this.cmb_FrameReinf.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_FrameReinf.Name = "cmb_FrameReinf";
            this.cmb_FrameReinf.Size = new System.Drawing.Size(91, 21);
            this.cmb_FrameReinf.TabIndex = 14;
            this.cmb_FrameReinf.SelectedValueChanged += new System.EventHandler(this.cmb_FrameReinf_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Article No.";
            // 
            // lbl_Specs
            // 
            this.lbl_Specs.AutoSize = true;
            this.lbl_Specs.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_Specs.Location = new System.Drawing.Point(3, 4);
            this.lbl_Specs.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_Specs.Name = "lbl_Specs";
            this.lbl_Specs.Size = new System.Drawing.Size(129, 17);
            this.lbl_Specs.TabIndex = 12;
            this.lbl_Specs.Text = "Frame Specification";
            // 
            // lbl_FrameProfile
            // 
            this.lbl_FrameProfile.AutoSize = true;
            this.lbl_FrameProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FrameProfile.Location = new System.Drawing.Point(3, 51);
            this.lbl_FrameProfile.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_FrameProfile.Name = "lbl_FrameProfile";
            this.lbl_FrameProfile.Size = new System.Drawing.Size(41, 15);
            this.lbl_FrameProfile.TabIndex = 9;
            this.lbl_FrameProfile.Text = "Profile";
            // 
            // lbl_FrameReinf
            // 
            this.lbl_FrameReinf.AutoSize = true;
            this.lbl_FrameReinf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_FrameReinf.Location = new System.Drawing.Point(3, 78);
            this.lbl_FrameReinf.Margin = new System.Windows.Forms.Padding(3, 6, 7, 3);
            this.lbl_FrameReinf.Name = "lbl_FrameReinf";
            this.lbl_FrameReinf.Size = new System.Drawing.Size(34, 15);
            this.lbl_FrameReinf.TabIndex = 10;
            this.lbl_FrameReinf.Text = "Reinf";
            // 
            // cmb_FrameProfile
            // 
            this.cmb_FrameProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FrameProfile.FormattingEnabled = true;
            this.cmb_FrameProfile.Location = new System.Drawing.Point(47, 48);
            this.cmb_FrameProfile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.cmb_FrameProfile.Name = "cmb_FrameProfile";
            this.cmb_FrameProfile.Size = new System.Drawing.Size(91, 21);
            this.cmb_FrameProfile.TabIndex = 8;
            this.cmb_FrameProfile.SelectedValueChanged += new System.EventHandler(this.cmb_FrameProfile_SelectedValueChanged);
            // 
            // pnl_frameLbl
            // 
            this.pnl_frameLbl.Controls.Add(this.lbl_frameName);
            this.pnl_frameLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_frameLbl.Location = new System.Drawing.Point(0, 0);
            this.pnl_frameLbl.Name = "pnl_frameLbl";
            this.pnl_frameLbl.Size = new System.Drawing.Size(154, 21);
            this.pnl_frameLbl.TabIndex = 13;
            // 
            // pnl_rdBtnWdw
            // 
            this.pnl_rdBtnWdw.Controls.Add(this.rdBtn_Window);
            this.pnl_rdBtnWdw.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_rdBtnWdw.Location = new System.Drawing.Point(0, 21);
            this.pnl_rdBtnWdw.Name = "pnl_rdBtnWdw";
            this.pnl_rdBtnWdw.Size = new System.Drawing.Size(154, 26);
            this.pnl_rdBtnWdw.TabIndex = 14;
            // 
            // rdBtn_Door
            // 
            this.rdBtn_Door.Location = new System.Drawing.Point(4, 0);
            this.rdBtn_Door.Name = "rdBtn_Door";
            this.rdBtn_Door.Size = new System.Drawing.Size(140, 23);
            this.rdBtn_Door.TabIndex = 2;
            this.rdBtn_Door.Text = "Door";
            this.rdBtn_Door.UseVisualStyleBackColor = true;
            this.rdBtn_Door.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // pnl_rdBtnDoor
            // 
            this.pnl_rdBtnDoor.Controls.Add(this.rdBtn_Door);
            this.pnl_rdBtnDoor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_rdBtnDoor.Location = new System.Drawing.Point(0, 47);
            this.pnl_rdBtnDoor.Name = "pnl_rdBtnDoor";
            this.pnl_rdBtnDoor.Size = new System.Drawing.Size(154, 26);
            this.pnl_rdBtnDoor.TabIndex = 15;
            // 
            // pnl_rdBtnConcrete
            // 
            this.pnl_rdBtnConcrete.Controls.Add(this.rdBtn_Concrete);
            this.pnl_rdBtnConcrete.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_rdBtnConcrete.Location = new System.Drawing.Point(0, 73);
            this.pnl_rdBtnConcrete.Name = "pnl_rdBtnConcrete";
            this.pnl_rdBtnConcrete.Size = new System.Drawing.Size(154, 26);
            this.pnl_rdBtnConcrete.TabIndex = 16;
            // 
            // pnl_Body
            // 
            this.pnl_Body.Controls.Add(this.pnl_specs);
            this.pnl_Body.Controls.Add(this.pnl_Dimensions);
            this.pnl_Body.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Body.Location = new System.Drawing.Point(0, 99);
            this.pnl_Body.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Body.Name = "pnl_Body";
            this.pnl_Body.Size = new System.Drawing.Size(154, 186);
            this.pnl_Body.TabIndex = 17;
            // 
            // pnl_Dimensions
            // 
            this.pnl_Dimensions.Controls.Add(this.lbl_Width);
            this.pnl_Dimensions.Controls.Add(this.num_fHeight);
            this.pnl_Dimensions.Controls.Add(this.num_fWidth);
            this.pnl_Dimensions.Controls.Add(this.lbl_Height);
            this.pnl_Dimensions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Dimensions.Location = new System.Drawing.Point(0, 0);
            this.pnl_Dimensions.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Dimensions.Name = "pnl_Dimensions";
            this.pnl_Dimensions.Size = new System.Drawing.Size(154, 81);
            this.pnl_Dimensions.TabIndex = 13;
            // 
            // pnl_frameProperties
            // 
            this.pnl_frameProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_frameProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_frameProperties.Location = new System.Drawing.Point(0, 285);
            this.pnl_frameProperties.Name = "pnl_frameProperties";
            this.pnl_frameProperties.Size = new System.Drawing.Size(154, 6);
            this.pnl_frameProperties.TabIndex = 18;
            // 
            // FramePropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_frameProperties);
            this.Controls.Add(this.pnl_Body);
            this.Controls.Add(this.pnl_rdBtnConcrete);
            this.Controls.Add(this.pnl_rdBtnDoor);
            this.Controls.Add(this.pnl_rdBtnWdw);
            this.Controls.Add(this.pnl_frameLbl);
            this.Name = "FramePropertiesUC";
            this.Size = new System.Drawing.Size(154, 291);
            this.Load += new System.EventHandler(this.FramePropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_fWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fHeight)).EndInit();
            this.pnl_specs.ResumeLayout(false);
            this.pnl_specs.PerformLayout();
            this.pnl_frameLbl.ResumeLayout(false);
            this.pnl_frameLbl.PerformLayout();
            this.pnl_rdBtnWdw.ResumeLayout(false);
            this.pnl_rdBtnDoor.ResumeLayout(false);
            this.pnl_rdBtnConcrete.ResumeLayout(false);
            this.pnl_Body.ResumeLayout(false);
            this.pnl_Dimensions.ResumeLayout(false);
            this.pnl_Dimensions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_frameName;
        private System.Windows.Forms.RadioButton rdBtn_Window;
        private System.Windows.Forms.RadioButton rdBtn_Concrete;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_fWidth;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_fHeight;
        private System.Windows.Forms.ComboBox cmb_FrameProfile;
        private System.Windows.Forms.Label lbl_FrameProfile;
        private System.Windows.Forms.Label lbl_FrameReinf;
        private System.Windows.Forms.Panel pnl_specs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Specs;
        private System.Windows.Forms.ComboBox cmb_FrameReinf;
        private System.Windows.Forms.Panel pnl_frameLbl;
        private System.Windows.Forms.Panel pnl_rdBtnWdw;
        private System.Windows.Forms.RadioButton rdBtn_Door;
        private System.Windows.Forms.Panel pnl_rdBtnDoor;
        private System.Windows.Forms.Panel pnl_rdBtnConcrete;
        private System.Windows.Forms.Panel pnl_Body;
        private System.Windows.Forms.Panel pnl_frameProperties;
        private System.Windows.Forms.Panel pnl_Dimensions;
    }
}
