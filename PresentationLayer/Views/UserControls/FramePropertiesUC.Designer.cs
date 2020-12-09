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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_frameName = new System.Windows.Forms.Label();
            this.rdBtn_Window = new System.Windows.Forms.RadioButton();
            this.rdBtn_Door = new System.Windows.Forms.RadioButton();
            this.rdBtn_Concrete = new System.Windows.Forms.RadioButton();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_fWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_fHeight = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_fWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.lbl_frameName);
            this.flowLayoutPanel1.Controls.Add(this.rdBtn_Window);
            this.flowLayoutPanel1.Controls.Add(this.rdBtn_Door);
            this.flowLayoutPanel1.Controls.Add(this.rdBtn_Concrete);
            this.flowLayoutPanel1.Controls.Add(this.lbl_Width);
            this.flowLayoutPanel1.Controls.Add(this.num_fWidth);
            this.flowLayoutPanel1.Controls.Add(this.lbl_Height);
            this.flowLayoutPanel1.Controls.Add(this.num_fHeight);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(185, 183);
            this.flowLayoutPanel1.TabIndex = 0;
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
            // FramePropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FramePropertiesUC";
            this.Size = new System.Drawing.Size(185, 183);
            this.Load += new System.EventHandler(this.FramePropertiesUC_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_fWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbl_frameName;
        private System.Windows.Forms.RadioButton rdBtn_Window;
        private System.Windows.Forms.RadioButton rdBtn_Door;
        private System.Windows.Forms.RadioButton rdBtn_Concrete;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_fWidth;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_fHeight;
    }
}
