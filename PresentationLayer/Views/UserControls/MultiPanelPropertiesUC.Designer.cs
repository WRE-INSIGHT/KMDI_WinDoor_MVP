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
            this.lbl_MultiPanelName = new System.Windows.Forms.Label();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_MultiPanelProperties = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_MultiPanelName
            // 
            this.lbl_MultiPanelName.AutoSize = true;
            this.lbl_MultiPanelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MultiPanelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_MultiPanelName.Location = new System.Drawing.Point(3, 3);
            this.lbl_MultiPanelName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbl_MultiPanelName.Name = "lbl_MultiPanelName";
            this.lbl_MultiPanelName.Size = new System.Drawing.Size(109, 21);
            this.lbl_MultiPanelName.TabIndex = 0;
            this.lbl_MultiPanelName.Text = "MultiMullion_1";
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Location = new System.Drawing.Point(3, 34);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(35, 13);
            this.lbl_Width.TabIndex = 4;
            this.lbl_Width.Text = "Width";
            // 
            // num_Width
            // 
            this.num_Width.Enabled = false;
            this.num_Width.Location = new System.Drawing.Point(3, 50);
            this.num_Width.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Width.Name = "num_Width";
            this.num_Width.Size = new System.Drawing.Size(135, 20);
            this.num_Width.TabIndex = 5;
            this.num_Width.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Location = new System.Drawing.Point(3, 75);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(38, 13);
            this.lbl_Height.TabIndex = 6;
            this.lbl_Height.Text = "Height";
            // 
            // num_Height
            // 
            this.num_Height.Enabled = false;
            this.num_Height.Location = new System.Drawing.Point(3, 91);
            this.num_Height.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_Height.Name = "num_Height";
            this.num_Height.Size = new System.Drawing.Size(135, 20);
            this.num_Height.TabIndex = 7;
            this.num_Height.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_MultiPanelName);
            this.panel1.Controls.Add(this.lbl_Width);
            this.panel1.Controls.Add(this.lbl_Height);
            this.panel1.Controls.Add(this.num_Height);
            this.panel1.Controls.Add(this.num_Width);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 120);
            this.panel1.TabIndex = 8;
            // 
            // pnl_MultiPanelProperties
            // 
            this.pnl_MultiPanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MultiPanelProperties.Location = new System.Drawing.Point(0, 120);
            this.pnl_MultiPanelProperties.Name = "pnl_MultiPanelProperties";
            this.pnl_MultiPanelProperties.Size = new System.Drawing.Size(154, 9);
            this.pnl_MultiPanelProperties.TabIndex = 9;
            // 
            // MultiPanelPropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_MultiPanelProperties);
            this.Controls.Add(this.panel1);
            this.Name = "MultiPanelPropertiesUC";
            this.Size = new System.Drawing.Size(154, 129);
            this.Load += new System.EventHandler(this.MultiPanelPropertiesUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_MultiPanelName;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown num_Height;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_MultiPanelProperties;
    }
}
