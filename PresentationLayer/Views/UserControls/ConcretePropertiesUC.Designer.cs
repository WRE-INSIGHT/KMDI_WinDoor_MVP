namespace PresentationLayer.Views.UserControls
{
    partial class ConcretePropertiesUC
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
            this.pnl_ConcreteLbl = new System.Windows.Forms.Panel();
            this.lbl_ConcreteName = new System.Windows.Forms.Label();
            this.pnl_Dimensions = new System.Windows.Forms.Panel();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.num_cHeight = new System.Windows.Forms.NumericUpDown();
            this.num_cWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.pnl_ConcreteLbl.SuspendLayout();
            this.pnl_Dimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_cHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_ConcreteLbl
            // 
            this.pnl_ConcreteLbl.Controls.Add(this.lbl_ConcreteName);
            this.pnl_ConcreteLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_ConcreteLbl.Location = new System.Drawing.Point(0, 0);
            this.pnl_ConcreteLbl.Name = "pnl_ConcreteLbl";
            this.pnl_ConcreteLbl.Size = new System.Drawing.Size(152, 21);
            this.pnl_ConcreteLbl.TabIndex = 14;
            // 
            // lbl_ConcreteName
            // 
            this.lbl_ConcreteName.AutoSize = true;
            this.lbl_ConcreteName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ConcreteName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_ConcreteName.Location = new System.Drawing.Point(0, 0);
            this.lbl_ConcreteName.Name = "lbl_ConcreteName";
            this.lbl_ConcreteName.Size = new System.Drawing.Size(83, 21);
            this.lbl_ConcreteName.TabIndex = 0;
            this.lbl_ConcreteName.Text = "Concrete 1";
            // 
            // pnl_Dimensions
            // 
            this.pnl_Dimensions.Controls.Add(this.lbl_Width);
            this.pnl_Dimensions.Controls.Add(this.num_cHeight);
            this.pnl_Dimensions.Controls.Add(this.num_cWidth);
            this.pnl_Dimensions.Controls.Add(this.lbl_Height);
            this.pnl_Dimensions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Dimensions.Location = new System.Drawing.Point(0, 21);
            this.pnl_Dimensions.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Dimensions.Name = "pnl_Dimensions";
            this.pnl_Dimensions.Size = new System.Drawing.Size(152, 81);
            this.pnl_Dimensions.TabIndex = 15;
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
            // num_cHeight
            // 
            this.num_cHeight.Location = new System.Drawing.Point(7, 58);
            this.num_cHeight.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_cHeight.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_cHeight.Name = "num_cHeight";
            this.num_cHeight.Size = new System.Drawing.Size(135, 20);
            this.num_cHeight.TabIndex = 7;
            this.num_cHeight.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_cHeight.ValueChanged += new System.EventHandler(this.num_cHeight_ValueChanged);
            // 
            // num_cWidth
            // 
            this.num_cWidth.Location = new System.Drawing.Point(7, 18);
            this.num_cWidth.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_cWidth.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_cWidth.Name = "num_cWidth";
            this.num_cWidth.Size = new System.Drawing.Size(135, 20);
            this.num_cWidth.TabIndex = 5;
            this.num_cWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.num_cWidth.ValueChanged += new System.EventHandler(this.num_cWidth_ValueChanged);
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
            // ConcretePropertiesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_Dimensions);
            this.Controls.Add(this.pnl_ConcreteLbl);
            this.Name = "ConcretePropertiesUC";
            this.Size = new System.Drawing.Size(152, 102);
            this.Load += new System.EventHandler(this.ConcretePropertiesUC_Load);
            this.pnl_ConcreteLbl.ResumeLayout(false);
            this.pnl_ConcreteLbl.PerformLayout();
            this.pnl_Dimensions.ResumeLayout(false);
            this.pnl_Dimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_cHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_cWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_ConcreteLbl;
        private System.Windows.Forms.Label lbl_ConcreteName;
        private System.Windows.Forms.Panel pnl_Dimensions;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown num_cHeight;
        private System.Windows.Forms.NumericUpDown num_cWidth;
        private System.Windows.Forms.Label lbl_Height;
    }
}
