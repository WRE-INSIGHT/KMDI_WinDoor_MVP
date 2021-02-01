namespace PresentationLayer.Views.UserControls
{
    partial class MultiPanelPropertiesUC
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
            this.flp_MultiPanelProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_MultiPanelName = new System.Windows.Forms.Label();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.flp_MultiPanelProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // flp_MultiPanelProperties
            // 
            this.flp_MultiPanelProperties.AutoSize = true;
            this.flp_MultiPanelProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_MultiPanelProperties.Controls.Add(this.lbl_MultiPanelName);
            this.flp_MultiPanelProperties.Controls.Add(this.lbl_Width);
            this.flp_MultiPanelProperties.Controls.Add(this.num_Width);
            this.flp_MultiPanelProperties.Controls.Add(this.lbl_Height);
            this.flp_MultiPanelProperties.Controls.Add(this.num_Height);
            this.flp_MultiPanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_MultiPanelProperties.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.flp_MultiPanelProperties.Location = new System.Drawing.Point(0, 0);
            this.flp_MultiPanelProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp_MultiPanelProperties.Name = "flp_MultiPanelProperties";
            this.flp_MultiPanelProperties.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.flp_MultiPanelProperties.Size = new System.Drawing.Size(154, 129);
            this.flp_MultiPanelProperties.TabIndex = 1;
            // 
            // lbl_MultiPanelName
            // 
            this.lbl_MultiPanelName.AutoSize = true;
            this.lbl_MultiPanelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MultiPanelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MultiPanelName.Location = new System.Drawing.Point(3, 7);
            this.lbl_MultiPanelName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbl_MultiPanelName.Name = "lbl_MultiPanelName";
            this.lbl_MultiPanelName.Size = new System.Drawing.Size(109, 21);
            this.lbl_MultiPanelName.TabIndex = 0;
            this.lbl_MultiPanelName.Text = "MultiMullion_1";
            // 
            // lbl_Width
            // 
            this.lbl_Width.Location = new System.Drawing.Point(3, 38);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(150, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // num_Width
            // 
            this.num_Width.Location = new System.Drawing.Point(3, 54);
            this.num_Width.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Width.Name = "num_Width";
            this.num_Width.Size = new System.Drawing.Size(135, 22);
            this.num_Width.TabIndex = 5;
            this.num_Width.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Width.ValueChanged += new System.EventHandler(this.num_Width_ValueChanged);
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Location = new System.Drawing.Point(3, 79);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(42, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // num_Height
            // 
            this.num_Height.Location = new System.Drawing.Point(3, 95);
            this.num_Height.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Height.Name = "num_Height";
            this.num_Height.Size = new System.Drawing.Size(135, 22);
            this.num_Height.TabIndex = 7;
            this.num_Height.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Height.ValueChanged += new System.EventHandler(this.num_Height_ValueChanged);
            // 
            // MultiPanelPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flp_MultiPanelProperties);
            this.Name = "MultiPanelPropertiesUC";
            this.Size = new System.Drawing.Size(154, 129);
            this.Load += new System.EventHandler(this.MultiPanelPropertiesUC_Load);
            this.SizeChanged += new System.EventHandler(this.MultiPanelPropertiesUC_SizeChanged);
            this.flp_MultiPanelProperties.ResumeLayout(false);
            this.flp_MultiPanelProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_MultiPanelProperties;
        private System.Windows.Forms.Label lbl_MultiPanelName;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_Height;
    }
}
