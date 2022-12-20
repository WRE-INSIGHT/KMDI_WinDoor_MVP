namespace PresentationLayer.Views.UserControls.FrameProperties_Modules
{
    partial class FP_SlidingRailsPropertyUC
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
            this.lbl_header = new System.Windows.Forms.Label();
            this.nud_RailsQty = new System.Windows.Forms.NumericUpDown();
            this.lbl_RailsQty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RailsQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbl_header.Location = new System.Drawing.Point(3, 3);
            this.lbl_header.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(37, 17);
            this.lbl_header.TabIndex = 14;
            this.lbl_header.Text = "Rails";
            // 
            // nud_RailsQty
            // 
            this.nud_RailsQty.Location = new System.Drawing.Point(64, 22);
            this.nud_RailsQty.Name = "nud_RailsQty";
            this.nud_RailsQty.Size = new System.Drawing.Size(85, 20);
            this.nud_RailsQty.TabIndex = 43;
            this.nud_RailsQty.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_RailsQty.ValueChanged += new System.EventHandler(this.nud_RailsQty_ValueChanged);
            // 
            // lbl_RailsQty
            // 
            this.lbl_RailsQty.AutoSize = true;
            this.lbl_RailsQty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RailsQty.Location = new System.Drawing.Point(4, 25);
            this.lbl_RailsQty.Name = "lbl_RailsQty";
            this.lbl_RailsQty.Size = new System.Drawing.Size(51, 13);
            this.lbl_RailsQty.TabIndex = 42;
            this.lbl_RailsQty.Text = "Rails Qty";
            // 
            // FP_SlidingRailsPropertyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nud_RailsQty);
            this.Controls.Add(this.lbl_RailsQty);
            this.Controls.Add(this.lbl_header);
            this.Name = "FP_SlidingRailsPropertyUC";
            this.Size = new System.Drawing.Size(152, 45);
            this.Load += new System.EventHandler(this.FP_SlidingRailsPropertyUC_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FP_SlidingRailsPropertyUC_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.nud_RailsQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.NumericUpDown nud_RailsQty;
        private System.Windows.Forms.Label lbl_RailsQty;
    }
}
