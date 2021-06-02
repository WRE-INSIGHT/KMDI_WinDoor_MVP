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
            this.flp_frameProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_frameName = new System.Windows.Forms.Label();
            this.rdBtn_Window = new System.Windows.Forms.RadioButton();
            this.rdBtn_Door = new System.Windows.Forms.RadioButton();
            this.rdBtn_Concrete = new System.Windows.Forms.RadioButton();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_fWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_fHeight = new System.Windows.Forms.NumericUpDown();
            this.pbl_specs = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Specs = new System.Windows.Forms.Label();
            this.lbl_FrameProfile = new System.Windows.Forms.Label();
            this.txt_FrameReinf = new System.Windows.Forms.TextBox();
            this.lbl_FrameReinf = new System.Windows.Forms.Label();
            this.cmb_FrameProfile = new System.Windows.Forms.ComboBox();
            this.flp_frameProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_fWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fHeight)).BeginInit();
            this.pbl_specs.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_frameProperties
            // 
            this.flp_frameProperties.AutoSize = true;
            this.flp_frameProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_frameProperties.Controls.Add(this.lbl_frameName);
            this.flp_frameProperties.Controls.Add(this.rdBtn_Window);
            this.flp_frameProperties.Controls.Add(this.rdBtn_Door);
            this.flp_frameProperties.Controls.Add(this.rdBtn_Concrete);
            this.flp_frameProperties.Controls.Add(this.lbl_Width);
            this.flp_frameProperties.Controls.Add(this.num_fWidth);
            this.flp_frameProperties.Controls.Add(this.lbl_Height);
            this.flp_frameProperties.Controls.Add(this.num_fHeight);
            this.flp_frameProperties.Controls.Add(this.pbl_specs);
            this.flp_frameProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_frameProperties.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flp_frameProperties.Location = new System.Drawing.Point(0, 0);
            this.flp_frameProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp_frameProperties.Name = "flp_frameProperties";
            this.flp_frameProperties.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flp_frameProperties.Size = new System.Drawing.Size(154, 306);
            this.flp_frameProperties.TabIndex = 0;
            // 
            // lbl_frameName
            // 
            this.lbl_frameName.AutoSize = true;
            this.lbl_frameName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_frameName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_frameName.Location = new System.Drawing.Point(3, 7);
            this.lbl_frameName.Name = "lbl_frameName";
            this.lbl_frameName.Size = new System.Drawing.Size(65, 21);
            this.lbl_frameName.TabIndex = 0;
            this.lbl_frameName.Text = "Frame 1";
            // 
            // rdBtn_Window
            // 
            this.rdBtn_Window.Checked = true;
            this.rdBtn_Window.Location = new System.Drawing.Point(3, 31);
            this.rdBtn_Window.Name = "rdBtn_Window";
            this.rdBtn_Window.Size = new System.Drawing.Size(140, 23);
            this.rdBtn_Window.TabIndex = 1;
            this.rdBtn_Window.TabStop = true;
            this.rdBtn_Window.Text = "Window";
            this.rdBtn_Window.UseVisualStyleBackColor = true;
            this.rdBtn_Window.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // rdBtn_Door
            // 
            this.rdBtn_Door.Location = new System.Drawing.Point(3, 60);
            this.rdBtn_Door.Name = "rdBtn_Door";
            this.rdBtn_Door.Size = new System.Drawing.Size(140, 23);
            this.rdBtn_Door.TabIndex = 2;
            this.rdBtn_Door.Text = "Door";
            this.rdBtn_Door.UseVisualStyleBackColor = true;
            this.rdBtn_Door.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // rdBtn_Concrete
            // 
            this.rdBtn_Concrete.Location = new System.Drawing.Point(3, 89);
            this.rdBtn_Concrete.Name = "rdBtn_Concrete";
            this.rdBtn_Concrete.Size = new System.Drawing.Size(140, 23);
            this.rdBtn_Concrete.TabIndex = 3;
            this.rdBtn_Concrete.TabStop = true;
            this.rdBtn_Concrete.Text = "Concrete";
            this.rdBtn_Concrete.UseVisualStyleBackColor = true;
            this.rdBtn_Concrete.Visible = false;
            this.rdBtn_Concrete.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Location = new System.Drawing.Point(3, 115);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(39, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // num_fWidth
            // 
            this.num_fWidth.Location = new System.Drawing.Point(3, 131);
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
            this.num_fWidth.Size = new System.Drawing.Size(135, 22);
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
            this.lbl_Height.Location = new System.Drawing.Point(3, 156);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(42, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // num_fHeight
            // 
            this.num_fHeight.Location = new System.Drawing.Point(3, 172);
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
            this.num_fHeight.Size = new System.Drawing.Size(135, 22);
            this.num_fHeight.TabIndex = 7;
            this.num_fHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_fHeight.ValueChanged += new System.EventHandler(this.num_fHeight_ValueChanged_1);
            // 
            // pbl_specs
            // 
            this.pbl_specs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbl_specs.Controls.Add(this.label1);
            this.pbl_specs.Controls.Add(this.lbl_Specs);
            this.pbl_specs.Controls.Add(this.lbl_FrameProfile);
            this.pbl_specs.Controls.Add(this.txt_FrameReinf);
            this.pbl_specs.Controls.Add(this.lbl_FrameReinf);
            this.pbl_specs.Controls.Add(this.cmb_FrameProfile);
            this.pbl_specs.Location = new System.Drawing.Point(3, 200);
            this.pbl_specs.Name = "pbl_specs";
            this.pbl_specs.Size = new System.Drawing.Size(147, 102);
            this.pbl_specs.TabIndex = 12;
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
            // txt_FrameReinf
            // 
            this.txt_FrameReinf.Location = new System.Drawing.Point(47, 75);
            this.txt_FrameReinf.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.txt_FrameReinf.Name = "txt_FrameReinf";
            this.txt_FrameReinf.ReadOnly = true;
            this.txt_FrameReinf.Size = new System.Drawing.Size(92, 22);
            this.txt_FrameReinf.TabIndex = 11;
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
            // 
            // FramePropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flp_frameProperties);
            this.Name = "FramePropertiesUC";
            this.Size = new System.Drawing.Size(154, 306);
            this.Load += new System.EventHandler(this.FramePropertiesUC_Load);
            this.flp_frameProperties.ResumeLayout(false);
            this.flp_frameProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_fWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fHeight)).EndInit();
            this.pbl_specs.ResumeLayout(false);
            this.pbl_specs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_frameProperties;
        private System.Windows.Forms.Label lbl_frameName;
        private System.Windows.Forms.RadioButton rdBtn_Window;
        private System.Windows.Forms.RadioButton rdBtn_Door;
        private System.Windows.Forms.RadioButton rdBtn_Concrete;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_fWidth;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_fHeight;
        private System.Windows.Forms.ComboBox cmb_FrameProfile;
        private System.Windows.Forms.Label lbl_FrameProfile;
        private System.Windows.Forms.Label lbl_FrameReinf;
        private System.Windows.Forms.TextBox txt_FrameReinf;
        private System.Windows.Forms.Panel pbl_specs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Specs;
    }
}
